using System;
using UnityEngine;

namespace KiUtilities.Attributes
{
    public class RequireInterface : PropertyAttribute
    {
        public readonly Type RequireType;

        public RequireInterface(Type requireType)
        {
            RequireType = requireType;
        }
    }
}