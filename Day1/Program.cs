using System;
using System.Collections.Generic;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var lines = Helpers.Program.GetFileLinesAsStringList(1);
            var output = new List<int>();

            // ---------- PART 1 ----------

            // Loop through each line of the input file
            foreach (var line in lines)
            {
                // Find the needed fuel amount for the given module weight
                var value = FuelRequired(int.Parse(line));
                output.Add(value);
            }

            var fuelForModules = output.Sum();

            Console.WriteLine($"The sum of all fuel required for modules is {fuelForModules}");

            // ---------- PART 2 ----------

            output = new List<int>();

            // Loop through each line of the input file
            foreach (var line in lines)
            {
                // Find the needed fuel amount for the given module weight
                var initialFuelWeight = FuelRequired(int.Parse(line));
                // Recursively find out how much fuel is needed to the fuel needed for the module :-S
                var recursiveFuelValue = RecursiveFuelRequired(initialFuelWeight);

                output.Add(recursiveFuelValue);
            }

            var totalFuelRequired = output.Sum();

            Console.WriteLine($"The total amount of fuel needed for EVERYTHING is {totalFuelRequired}");
        }

        private static int FuelRequired(int moduleWeight)
        {
            // To find the required fuel: divide weight by 3, round down, and subtract 2
            var valueToRound = (float)moduleWeight / 3;
            var valueRounded = Math.Floor(valueToRound);

            return (int)valueRounded - 2;
        }

        private static int RecursiveFuelRequired(int initialFuelWeight)
        {
            int totalFuelWeight = initialFuelWeight;
            int fuelNeeded = initialFuelWeight;

            while (fuelNeeded > 0)
            {
                var fuelForFuel = FuelRequired(fuelNeeded);

                if (fuelForFuel <= 0)
                {
                    break;
                }

                totalFuelWeight += fuelForFuel;
                fuelNeeded = fuelForFuel;
            }

            return totalFuelWeight;
        }
    }
}
