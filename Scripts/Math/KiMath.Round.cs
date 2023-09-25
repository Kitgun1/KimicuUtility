using System;

namespace KiUtility
{
    public static partial class KiMath
    {
        /// <summary> Returns the string format for a decimal value. </summary>
        /// <param name="value"> The decimal value to format. </param>
        /// <returns> The string format for the decimal value. </returns>
        /// <exception cref="ArgumentException"> Thrown when the value is invalid. </exception>
        public static ValueStringFormat OptimalStringFormat(this float value)
        {
            int decimalPlaces = BitConverter.GetBytes(decimal.GetBits((decimal)value)[3])[2];
            return decimalPlaces switch
            {
                0 => ValueStringFormat.F0,
                1 => ValueStringFormat.F1,
                2 => ValueStringFormat.F2,
                3 => ValueStringFormat.F3,
                4 => ValueStringFormat.F4,
                5 => ValueStringFormat.F5,
                6 => ValueStringFormat.F6,
                _ => throw new ArgumentException("Invalid value")
            };
        }

        /// <summary> Rounds a floating point number value to the specified number of decimal places. </summary>
        /// <param name="format"> The format that specifies the maximum number of decimal places to round to. </param>
        public static float Round(this float value, ValueStringFormat format)
        {
            int digits = int.Parse(format.ToString()[1..]);
            return (float)Math.Round(value, digits);
        }
    }
}