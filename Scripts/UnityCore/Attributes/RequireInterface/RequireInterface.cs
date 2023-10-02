using System;
using UnityEngine;

namespace KimicuUtility
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