namespace KimicuUtility
{
    public static partial class KiMath
    {
        /// <summary> Calculates the percentage ratio. </summary>
        /// <returns>Returns the percentage.</returns>
        public static double CalculatePercentage(double value, double total) => value / total * 100;

        /// <summary> Calculates the percentage ratio. </summary>
        /// <returns>Returns the percentage.</returns>
        public static float CalculatePercentage(float value, float total) => value / total * 100;
    }
}