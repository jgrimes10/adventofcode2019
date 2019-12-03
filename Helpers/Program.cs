using System;
using System.Collections.Generic;
using System.IO;

namespace Helpers
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static List<string> GetFileLinesAsStringList(int dayNumber)
        {
            // Get all of the files in the root project directory with a txt extension
            var files = Directory.GetFiles(@"..\..\..\..\", "*.txt");
            var inputFileDirectory = "";
            var fileNameAndExtension = "";

            foreach (string fileName in files)
            {
                var constructedFileName = $"Day{dayNumber}Input";

                // Check if the filename contains the file for the checked day
                if (fileName.Contains(constructedFileName))
                {
                    inputFileDirectory = fileName;
                    fileNameAndExtension = $"{constructedFileName}.txt";

                } 
                else
                {
                    throw new Exception($"Could not find file name: {constructedFileName}.txt");
                }
            }

            string[] lines = System.IO.File.ReadAllLines(inputFileDirectory);

            if (lines.Length <= 0 && !String.IsNullOrEmpty(fileNameAndExtension))
            {
                throw new Exception($"File {fileNameAndExtension} cannot be empty.");
            }

            return new List<string>(lines);
        }
    }
}
