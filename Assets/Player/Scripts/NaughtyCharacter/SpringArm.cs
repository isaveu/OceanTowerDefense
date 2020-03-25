using UnityEngine;

namespace NaughtyCharacter
{
    public class SpringArm : MonoBehaviour
    {
        private Vector3 _socketVelocity;
        public Camera Camera;
        public float CameraViewportExtentsMultipllier = 1.0f;
        public LayerMask CollisionMask = 0;
        public float CollisionRadius = 0.25f;
        public Transform CollisionSocket;
        public float SpeedDamp;
        public float TargetLength = 3.0f;

        private void LateUpdate()
        {
            if (Camera != null)
            {
                CollisionRadius = GetCollisionRadiusForCamera(Camera);
                Camera.transform.localPosition = -Vector3.forward * Camera.nearClipPlane;
            }

            UpdateLength();
        }

        private float GetCollisionRadiusForCamera(Camera cam)
        {
            var halfFOV = cam.fieldOfView / 2.0f * Mathf.Deg2Rad; // vertical FOV in radians
            var nearClipPlaneHalfHeight = Mathf.Tan(halfFOV) * cam.nearClipPlane * CameraViewportExtentsMultipllier;
            var nearClipPlaneHalfWidth = nearClipPlaneHalfHeight * cam.aspect;
            var collisionRadius = new Vector2(nearClipPlaneHalfWidth, nearClipPlaneHalfHeight).magnitude; // Pythagoras

            return collisionRadius;
        }

        private float GetDesiredTargetLength()
        {
            var ray = new Ray(transform.position, -transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, Mathf.Max(0.001f, CollisionRadius), out hit, TargetLength, CollisionMask))
                return hit.distance;
            return TargetLength;
        }

        private void UpdateLength()
        {
            var targetLength = GetDesiredTargetLength();
            var newSocketLocalPosition = -Vector3.forward * targetLength;

            CollisionSocket.localPosition = Vector3.SmoothDamp(
                CollisionSocket.localPosition, newSocketLocalPosition, ref _socketVelocity, SpeedDamp);
        }

        private void OnDrawGizmos()
        {
            if (CollisionSocket != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, CollisionSocket.transform.position);
                DrawGizmoSphere(CollisionSocket.transform.position, CollisionRadius);
            }
        }

        private void DrawGizmoSphere(Vector3 pos, float radius)
        {
            var rot = Quaternion.Euler(-90.0f, 0.0f, 0.0f);

            var alphaSteps = 8;
            var betaSteps = 16;

            var deltaAlpha = Mathf.PI / alphaSteps;
            var deltaBeta = 2.0f * Mathf.PI / betaSteps;

            for (var a = 0; a < alphaSteps; a++)
            for (var b = 0; b < betaSteps; b++)
            {
                var alpha = a * deltaAlpha;
                var beta = b * deltaBeta;

                var p1 = pos + rot * GetSphericalPoint(alpha, beta, radius);
                var p2 = pos + rot * GetSphericalPoint(alpha + deltaAlpha, beta, radius);
                var p3 = pos + rot * GetSphericalPoint(alpha + deltaAlpha, beta - deltaBeta, radius);

                Gizmos.DrawLine(p1, p2);
                Gizmos.DrawLine(p2, p3);
            }
        }

        private Vector3 GetSphericalPoint(float alpha, float beta, float radius)
        {
            Vector3 point;
            point.x = radius * Mathf.Sin(alpha) * Mathf.Cos(beta);
            point.y = radius * Mathf.Sin(alpha) * Mathf.Sin(beta);
            point.z = radius * Mathf.Cos(alpha);

            return point;
        }
    }
}