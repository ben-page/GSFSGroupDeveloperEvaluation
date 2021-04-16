namespace ElectronicColorCode
{
    public class CalculateOhmValues : ICalculateOhmValues
    {
        /// <summary>
        /// Calculates the Ohm value of a resistor based on the band colors.
        /// </summary>
        /// <remarks>
        /// This method is flawed. It's unable to return decimal ohms value or tolerance values.
        /// </remarks>
        /// <param name="bandAColor">The color of the first figure of component value band.</param>
        /// <param name="bandBColor">The color of the second significant figure band.</param>
        /// <param name="bandCColor">The color of the decimal multiplier band.</param>
        /// <param name="bandDColor">The color of the tolerance value band.</param>
        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            var calculator = new ResistorValueCalculator(bandAColor, bandBColor, bandCColor, bandDColor);
            return (int)calculator.Ohms;
        }
    }
}
