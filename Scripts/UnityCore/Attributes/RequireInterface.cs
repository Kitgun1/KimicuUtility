using System;
using UnityEngine;

namespace KiUtility.Attributes
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