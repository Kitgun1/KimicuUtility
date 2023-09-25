using System;

namespace KiUtility
{
    [Serializable]
    public struct Bounds
    {
        public float XMin;
        public float XMax;
        public float YMin;
        public float YMax;

        public Bounds(float xMin, float xMax, float yMin, float yMax)
        {
            XMin = xMin;
            XMax = xMax;
            YMin = yMin;
            YMax = yMax;
        }
    }
}