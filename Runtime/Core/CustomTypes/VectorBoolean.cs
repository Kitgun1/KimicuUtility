using System;

namespace KimicuUtility
{
    [Serializable]
    public class VectorBoolean3
    {
        public bool X;
        public bool Y;
        public bool Z;

        public VectorBoolean3(bool x, bool y, bool z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    [Serializable]
    public class VectorBoolean2
    {
        public bool X;
        public bool Y;

        public VectorBoolean2(bool x, bool y)
        {
            X = x;
            Y = y;
        }
    }

    [Serializable]
    public class VectorBoolean4
    {
        public bool X;
        public bool Y;
        public bool Z;
        public bool W;

        public VectorBoolean4(bool x, bool y, bool z, bool w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
    }
}