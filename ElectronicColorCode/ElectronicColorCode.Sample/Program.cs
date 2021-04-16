using System;

namespace ElectronicColorCode.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = new ResistorValueCalculator("Green", "blue", "black", "gold", "brown");
            Console.WriteLine(r);

            r = new ResistorValueCalculator("Red", "red", "orange", "gold");
            Console.WriteLine(r);

            r = new ResistorValueCalculator("Yellow", "violet", "brown", "gold");
            Console.WriteLine(r);

            r = new ResistorValueCalculator("Blue", "grey", "black", "gold");
            Console.WriteLine(r);

            Console.ReadKey();
        }
    }
}
