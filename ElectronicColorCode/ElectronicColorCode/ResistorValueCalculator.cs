using System;

namespace ElectronicColorCode
{
    /// <summary>
    /// Calculates resistor value (ohms) and tolerance from IEC 60062:2016 color bands.
    /// </summary>
    public class ResistorValueCalculator
    {
        /// <summary>
        /// Resistor Value in ohms
        /// </summary>
        public decimal Ohms { get; }

        /// <summary>
        /// Resistor Tolerance as a percentage
        /// </summary>
        public decimal Tolerance { get; }

        /// <param name="aBand">The color of the A (first significant figure of resistance value) band.</param>
        /// <param name="bBand">The color of the B (second significant figure of resistance value) band.</param>1
        /// <param name="cBand">The color of the C (multiplier) band.</param>
        /// <param name="dBand">The color of the D (tolerance) band.</param>
        public ResistorValueCalculator(string aBand, string bBand, string cBand, string dBand)
        {
            int figure1;
            int figure2;
            int multiplier;
            try
            {
                figure1 = BandParser.ParseResistorSignificantFigureColor(aBand);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message, nameof(aBand), ex);
            }

            try
            {
                figure2 = BandParser.ParseResistorSignificantFigureColor(bBand);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message, nameof(bBand), ex);
            }

            try
            {
                multiplier = BandParser.ParseResistorMultiplierColor(cBand);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message, nameof(cBand), ex);
            }

            var value = figure1 * 10 + figure2;
            this.Ohms = value * Pow(10, multiplier);

            try
            {
                this.Tolerance = BandParser.ParseResistorToleranceColor(dBand);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message, nameof(dBand), ex);
            }
        }

        /// <param name="aBand">The color of the A band (first significant figure of resistance value).</param>
        /// <param name="bBand">The color of the B band (second significant figure of resistance value).</param>
        /// <param name="cBand">The color of the C band (third significant figure of resistance value).</param>
        /// <param name="dBand">The color of the D band (multiplier).</param>
        /// <param name="eBand">The color of the E band (tolerance).</param>
        /// <exception cref="ArgumentException"></exception>
        public ResistorValueCalculator(string aBand, string bBand, string cBand, string dBand, string eBand)
        {
            int figure1;
            int figure2;
            int figure3;
            int multiplier;

            try
            {
                figure1 = BandParser.ParseResistorSignificantFigureColor(aBand);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message, nameof(aBand), ex);
            }

            try
            {
                figure2 = BandParser.ParseResistorSignificantFigureColor(bBand);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message, nameof(bBand), ex);
            }

            try
            {
                figure3 = BandParser.ParseResistorSignificantFigureColor(cBand);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message, nameof(cBand), ex);
            }

            try
            {
                multiplier = BandParser.ParseResistorMultiplierColor(dBand);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message, nameof(dBand), ex);
            }

            var value = figure1 * 100 + figure2 * 10 + figure3;
            this.Ohms = value * Pow(10, multiplier);

            try
            {
                this.Tolerance = BandParser.ParseResistorToleranceColor(eBand);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message, nameof(eBand), ex);
            }
        }


        #region parsing

        #endregion

        #region calculation

        /// <summary>
        /// Performs an integer exponentiation operation.
        /// This is faster and more precise than using Math.pow(), which uses floating point values.
        /// </summary>
        /// <param name="base">The base value</param>
        /// <param name="exponent">The exponent value</param>
        /// <returns>The base raised to the power of the exponent</returns>
        private static decimal Pow(int @base, int exponent)
        {
            if (exponent >= 0)
            {
                var result = 1;
                for (var i = 0; i < exponent; i++)
                    result *= @base;
                return result;
            }
            else
            {
                var result = 1m;
                for (var i = exponent; i < 0; i++)
                    result /= @base;
                return result;
            }
        }

        #endregion

        /// <summary>
        /// Converts the value of this instance to a string
        /// </summary>
        /// <returns>A string containing the resistance and tolerance of the resistor.</returns>
        public override string ToString()
        {
            return $"{this.Ohms} ohms ±{this.Tolerance}%";
        }
    }
}
