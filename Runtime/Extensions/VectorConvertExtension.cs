using UnityEngine;

namespace KimicuUtility
{
    public static class VectorConvertExtension
    {
        public static Vector4 ToVector(this VectorBoolean4 vectorBoolean)
        {
            Vector4 result = new();
            if (vectorBoolean.X) result.x = 1;
            if (vectorBoolean.Y) result.y = 1;
            if (vectorBoolean.Z) result.z = 1;
            if (vectorBoolean.W) result.w = 1;
            return result;
        }

        public static VectorBoolean4 ToBoolean(this Vector4 vector)
        {
            VectorBoolean4 result = new(false, false, false, false);
            if (vector.x == 0) result.X = true;
            if (vector.y == 0) result.Y = true;
            if (vector.z == 0) result.Z = true;
            if (vector.w == 0) result.W = true;
            return result;
        }

        public static Vector3 ToVector(this VectorBoolean3 vectorBoolean)
        {
            Vector3 result = new();
            if (vectorBoolean.X) result.x = 1;
            if (vectorBoolean.Y) result.y = 1;
            if (vectorBoolean.Z) result.z = 1;

            return result;
        }

        public static VectorBoolean3 ToBoolean(this Vector3 vector)
        {
            VectorBoolean3 result = new(false, false, false);
            if (vector.x == 0) result.X = true;
            if (vector.y == 0) result.Y = true;
            if (vector.z == 0) result.Z = true;
            return result;
        }

        public static Vector2 ToVector(this VectorBoolean2 vectorBoolean)
        {
            Vector2 result = new();
            if (vectorBoolean.X) result.x = 1;
            if (vectorBoolean.Y) result.y = 1;
            return result;
        }

        public static VectorBoolean2 ToBoolean(this Vector2 vector)
        {
            VectorBoolean2 result = new(false, false);
            if (vector.x == 0) result.X = true;
            if (vector.y == 0) result.Y = true;
            return result;
        }

        public static Vector4 ToVector4(this Vector3Int vector) => (Vector3)vector;
        public static Vector4 ToVector4(this Vector2Int vector) => (Vector3)(Vector2)vector;
        
        public static Vector3 ToVector3(this Vector2Int vector) => (Vector2)vector;
        
        public static Vector2 ToVector2(this Vector3Int vector) => (Vector3)vector;

        public static Vector3Int ToVector3Int(this Vector4 vector) => new((int)vector.x, (int)vector.y, (int)vector.z);
        public static Vector3Int ToVector3Int(this Vector3 vector) => new((int)vector.x, (int)vector.y, (int)vector.z);
        public static Vector3Int ToVector3Int(this Vector2Int vector) => new(vector.x, vector.y, 0);
        public static Vector3Int ToVector3Int(this Vector2 vector) => new((int)vector.x, (int)vector.y, 0);

        public static Vector2Int ToVector2Int(this Vector4 vector) => new((int)vector.x, (int)vector.y);
        public static Vector2Int ToVector2Int(this Vector3 vector) => new((int)vector.x, (int)vector.y);
        public static Vector2Int ToVector2Int(this Vector3Int vector) => new(vector.x, vector.y);
        public static Vector2Int ToVector2Int(this Vector2 vector) => new((int)vector.x, (int)vector.y);
    }
}