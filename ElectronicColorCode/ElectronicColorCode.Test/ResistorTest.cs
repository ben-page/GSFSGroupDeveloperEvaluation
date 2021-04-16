using System;
using Xunit;

namespace ElectronicColorCode.Test
{
    public class ResistorTest
    {
        [Theory]
        [InlineData("Red", "yellow", "orange", "gold", "24000 ohms ±5%")]
        [InlineData("Blue", "gray", "gold", "silver", "6.8 ohms ±10%")]
        public void FourBand(string color1, string color2, string color3, string color4, string expected)
        {
            var calculator = new ResistorValueCalculator(color1, color2, color3, color4);
            Assert.Equal(expected, calculator.ToString());
        }

        [Theory]
        [InlineData("Green", "blue", "black", "black", "brown", "560 ohms ±1%")]
        [InlineData("Yellow", "Violet", "black", "Green", "Blue", "47000000 ohms ±0.25%")]
        public void FiveBand(string color1, string color2, string color3, string color4, string color5, string expected)
        {
            var calculator = new ResistorValueCalculator(color1, color2, color3, color4, color5);
            Assert.Equal(expected, calculator.ToString());
        }

        [Theory]
        [InlineData("silver", "yellow", "orange", "gold", "'silver' is not a valid color this band (Parameter 'aBand')")]
        [InlineData("Blue", "gray", "gld", "silver", "'gld' is not a recognized electronic color code (Parameter 'cBand')")]
        [InlineData("Blue", "gray", "gold", "pink", "'pink' is not a valid color this band (Parameter 'dBand')")]
        public void Exceptions(string color1, string color2, string color3, string color4, string expected)
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                new ResistorValueCalculator(color1, color2, color3, color4);
            });

            Assert.Equal(expected, ex.Message);
        }

        [Theory]
        [InlineData("Red", "yellow", "orange", "gold", "24000")]
        [InlineData("Blue", "gray", "gold", "silver", "6")]
        public void CalculateOhmValues(string color1, string color2, string color3, string color4, string expectedString)
        {
            var expected = int.Parse(expectedString);
            var calculator = new CalculateOhmValues();
            var actual = calculator.CalculateOhmValue(color1, color2, color3, color4);
            Assert.Equal(expected, actual);
        }
    }
}
