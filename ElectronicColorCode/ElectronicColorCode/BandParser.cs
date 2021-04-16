using System;

namespace ElectronicColorCode
{
    internal class BandParser
    {
        /// <summary>
        /// Parses the color string and returns a BandColor enum representing the parsed color.
        /// </summary>
        /// <param name="color">The Color to be parsed</param>
        /// <returns></returns>
        private static BandColor ParseBandColor(string color)
        {
            switch (color.ToLower())
            {
                case null:
                case "":
                case "None":
                    return BandColor.None;
                case "pink":
                case "pk":
                    return BandColor.Pink;
                case "silver":
                case "sr":
                    return BandColor.Silver;
                case "gold":
                case "gd":
                    return BandColor.Gold;
                case "black":
                case "bk":
                    return BandColor.Black;
                case "brown":
                case "bn":
                    return BandColor.Brown;
                case "red":
                case "rd":
                    return BandColor.Red;
                case "orange":
                case "og":
                    return BandColor.Orange;
                case "yellow":
                case "yw":
                    return BandColor.Yellow;
                case "green":
                case "gn":
                    return BandColor.Green;
                case "blue":
                case "bu":
                    return BandColor.Blue;
                case "violet":
                case "vt":
                case "purple":
                    return BandColor.Violet;
                case "grey":
                case "gy":
                case "gray":
                    return BandColor.Grey;
                case "white":
                case "wh":
                    return BandColor.White;
                default:
                    return BandColor.Invalid;
            }
        }

        /// <summary>
        /// Parses the color string and ensures the value is a valid color code for a significant figure band.
        /// </summary>
        /// <param name="color">The Color to be parsed</param>
        /// <returns>The figure value</returns>
        public static int ParseResistorSignificantFigureColor(string color)
        {
            var bandColor = ParseBandColor(color);
            return bandColor switch
            {
                BandColor.Invalid =>
                    throw new ArgumentException($"'{color}' is not a recognized electronic color code"),
                < BandColor.Black => 
                    throw new ArgumentException($"'{color}' is not a valid color this band"),
                _ => (int) bandColor
            };
        }


        /// <summary>
        /// Parses the color string and ensures the value is a valid color code for a multiplier band.
        /// </summary>
        /// <param name="color">The Color to be parsed</param>
        /// <returns>The multiplier value</returns>
        public static int ParseResistorMultiplierColor(string color)
        {
            var bandColor = ParseBandColor(color);
            return bandColor switch
            {
                BandColor.Invalid =>
                    throw new ArgumentException($"'{color}' is not a recognized electronic color code"),
                < BandColor.Pink => 
                    throw new ArgumentException($"'{color}' is not a valid color this band"),
                _ => (int) bandColor
            };
        }

        /// <summary>
        /// Parses the color string and ensures the value is a valid color code for a tolerance band.
        /// </summary>
        /// <param name="color">The color to be parsed</param>
        /// <returns>The tolerance as a percentage.</returns>
        public static decimal ParseResistorToleranceColor(string color)
        {
            var bandColor = ParseBandColor(color);
            switch (bandColor)
            {
                case BandColor.None:
                    return 20;
                case BandColor.Silver:
                    return 10;
                case BandColor.Gold:
                    return 5;
                case BandColor.Brown:
                    return 1;
                case BandColor.Red:
                    return 2;
                case BandColor.Orange:
                    return 0.05m;
                case BandColor.Yellow:
                    return 0.02m;
                case BandColor.Green:
                    return 0.05m;
                case BandColor.Blue:
                    return 0.25m;
                case BandColor.Violet:
                    return 0.1m;
                case BandColor.Grey:
                    return 0.01m;
                default:
                    throw new ArgumentException($"'{color}' is not a valid color this band");
            }
        }
    }
}
