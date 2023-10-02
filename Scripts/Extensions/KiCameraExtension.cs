using UnityEngine;

namespace KimicuUtility
{
    public static class KiCameraExtension
    {
        private static Camera _camera;

        private static Camera Camera
        {
            get
            {
                TryInitializeCamera();
                return _camera;
            }
            set => _camera = value;
        }

        private static void TryInitializeCamera() => _camera ??= Camera.main;

        /// <summary> Sets the position of the transform in world space based on a screen position. </summary>
        /// <param name="component">The component to set the position of.</param>
        /// <param name="screenPosition">The screen position to set the position to.</param>
        /// <param name="z">The z-coordinate of the position in world space.</param>
        /// <remarks> If the z-coordinate is not specified, it defaults to the near clip plane of the camera. </remarks>
        public static void SetWorldSpace<T>(this T component, Vector2 screenPosition, float z = -1) where T : Component
        {
            if (z == -1) z = Camera.nearClipPlane;
            Vector3 position = new(screenPosition.x, screenPosition.y, z);
            component.transform.position = Camera.ScreenToWorldPoint(position);
        }

        /// <summary> Converts a 2D screen position to a 3D world position. </summary>
        /// <param name="screenPosition">The 2D screen position to convert.</param>
        /// <param name="z">The z-coordinate of the resulting 3D world position. Defaults to Camera.nearClipPlane.</param>
        /// <returns>The resulting 3D world position.</returns>
        public static Vector3 GetWorldSpace(this Vector2 screenPosition, float z = -1) => z == -1
            ? Camera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, Camera.nearClipPlane))
            : Camera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, z));

        /// <summary> Converts a screen position to a world space position using the camera. </summary>
        /// <param name="screenPosition">The screen position to convert.</param>
        /// <returns>The world space position.</returns>
        public static Vector3 GetWorldSpace(this Vector3 screenPosition)
            => Camera.ScreenToWorldPoint(screenPosition);

        /// <summary> Returns a ray from a screen point. </summary>
        /// <param name="screenPosition">The screen position to cast the ray from.</param>
        /// <returns>A ray from the screen point.</returns>
        public static Ray GetScreenPointToRay(this Vector2 screenPosition)
            => Camera.ScreenPointToRay(screenPosition);

        /// <summary> Returns a ray going from camera through a screen point. </summary>
        /// <param name="screenPosition">The position on the screen in pixels.</param>
        /// <returns>A ray going from camera through the screen point.</returns>
        public static Ray GetScreenPointToRay(this Vector3 screenPosition)
            => GetScreenPointToRay((Vector2)screenPosition);

        /// <summary> Calculates the bounds of a camera view, given percentages of the screen to include on each side. </summary>
        /// <param name="camera"> The camera to calculate the bounds for. </param>
        /// <returns> The bounds of the camera view. </returns>
        public static Bounds GetBoundsPercent(this Camera camera, float top, float right, float bottom, float left)
            => KiMath.GetBoundsPercent(camera, top, right, bottom, left);

        /// <summary> Returns the bounding box of the camera view in world space. </summary>
        /// <param name="camera">The camera to get the bounds for.</param>
        /// <returns>The bounding box of the camera view in world space.</returns>
        public static Bounds GetBoundsUnit(this Camera camera, float top, float right, float bottom, float left)
            => KiMath.GetBoundsUnit(camera, top, right, bottom, left);
    }
}