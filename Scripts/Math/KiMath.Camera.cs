using UnityEngine;

namespace KiUtility
{
    public static partial class KiMath
    {
        /// <summary> Calculates the bounds of a camera view, given percentages of the screen to include on each side. </summary>
        /// <param name="camera"> The camera to calculate the bounds for. </param>
        /// <returns> The bounds of the camera view. </returns>
        public static Bounds GetBoundsPercent(Camera camera, float top, float right, float bottom, float left)
        {
            float cameraHeight = 2f * camera.orthographicSize;
            float cameraWidth = cameraHeight * camera.aspect;
            Vector3 cameraPos = camera.transform.position;
            float xMin = cameraPos.x - cameraWidth / 2 * (1 + left / 100);
            float xMax = cameraPos.x + cameraWidth / 2 * (1 + right / 100);
            float yMin = cameraPos.y - cameraHeight / 2 * (1 + bottom / 100);
            float yMax = cameraPos.y + cameraHeight / 2 * (1 + top / 100);

            return new Bounds(xMin, xMax, yMin, yMax);
        }

        /// <summary> Returns the bounding box of the camera view in world space. </summary>
        /// <param name="camera">The camera to get the bounds for.</param>
        /// <returns>The bounding box of the camera view in world space.</returns>
        public static Bounds GetBoundsUnit(Camera camera, float top, float right, float bottom, float left)
        {
            Vector3 cameraPos = camera.transform.position;
            float cameraHeight = 2f * camera.orthographicSize;
            float cameraWidth = cameraHeight * camera.aspect;
            float xMin = cameraPos.x - cameraWidth / 2 - left;
            float xMax = cameraPos.x + cameraWidth / 2 + right;
            float yMin = cameraPos.y - cameraHeight / 2 - bottom;
            float yMax = cameraPos.y + cameraHeight / 2 + top;

            return new Bounds(xMin, xMax, yMin, yMax);
        }
    }
}