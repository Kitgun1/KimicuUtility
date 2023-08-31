using UnityEngine;

namespace KiUtility
{
    public static class KiCameraExtension
    {
        private static readonly Camera Camera = Camera.main;

        /// <summary> Устанавливает позицию объекта относительно позиции на экране. </summary>
        /// <param name="component">Любой Компонент. </param>
        /// <param name="screenPosition">Позиция на экране. </param>
        /// <param name="z"> Дальность позиции. По умолчанию равно Camera.nearClipPlane. </param>
        public static void SetWorldSpace<T>(this T component, Vector2 screenPosition, float z = -1) where T : Component
        {
            if (z == -1) z = Camera.nearClipPlane;
            Vector3 position = new(screenPosition.x, screenPosition.y, z);
            component.transform.position = Camera.ScreenToWorldPoint(position);
        }

        /// <summary>
        /// Получить мировую точку
        /// </summary>
        /// <param name="screenPosition">Позиция на экране. </param>
        /// <param name="z"> Дальность позиции. По умолчанию равно Camera.nearClipPlane. </param>
        /// <returns>Vector3 мировой позиции</returns>
        public static Vector3 GetWorldSpace(this Vector2 screenPosition, float z = -1)
        {
            return z == -1
                ? Camera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, Camera.nearClipPlane))
                : Camera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, z));
        }

        /// <summary>
        /// Получить мировую точку
        /// </summary>
        /// <param name="screenPosition">Позиция на экране. </param>
        /// <param name="z"> Дальность позиции. По умолчанию равно Camera.nearClipPlane. </param>
        /// <returns>Vector3 мировой позиции</returns>
        public static Vector3 GetWorldSpace(this Vector3 screenPosition)
        {
            return Camera.ScreenToWorldPoint(screenPosition);
        }
        
        /// <param name="screenPosition">
        /// Трехмерная точка с координатами x и y, содержащая точку двухмерного экранного пространства в пикселях.
        /// Нижний левый пиксель экрана — (0,0). Правый верхний пиксель экрана равен (ширина экрана в пикселях – 1,
        /// высота экрана в пикселях – 1).
        /// </param>
        /// <returns>Возвращает луч, идущий от камеры через точку экрана.</returns>
        public static Ray GetScreenPointToRay(this Vector2 screenPosition)
        {
            return Camera.ScreenPointToRay(screenPosition);
        }

        /// <param name="screenPosition">
        /// Трехмерная точка с координатами x и y, содержащая точку двухмерного экранного пространства в пикселях.
        /// Нижний левый пиксель экрана — (0,0). Правый верхний пиксель экрана равен (ширина экрана в пикселях – 1,
        /// высота экрана в пикселях – 1). Unity игнорирует координату z.
        /// </param>
        /// <returns>Возвращает луч, идущий от камеры через точку экрана.</returns>
        public static Ray GetScreenPointToRay(this Vector3 screenPosition)
        {
            return GetScreenPointToRay((Vector2)screenPosition);
        }
    }
}