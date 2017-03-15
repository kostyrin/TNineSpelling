using System;
using System.Collections.Generic;
using System.IO;
using TNine.Common;
using TNine.Processor.TNineAlphabet;
using TNine.Processor.TNineStringProcessor;

namespace TNine.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(TNineResource.EnterPathForInputFile);

            string path = System.Console.ReadLine();

            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException();

            if (!File.Exists(path)) throw new FileNotFoundException();

            bool isLargeDataSet = default(bool);

            System.Console.WriteLine(TNineResource.IsLargeDataSet);
            string isLargeDataSetAnswer = System.Console.ReadLine();
            if (!string.IsNullOrEmpty(isLargeDataSetAnswer)) isLargeDataSet = isLargeDataSetAnswer.Equals("y");

            var allLines = File.ReadAllLines(path);

            IList<string> outputList = new List<string>();

            for (int ind = 1; ind <= allLines.Length - 1; ind++ )
            {
                var currentLine = allLines[ind];
                if (string.IsNullOrEmpty(currentLine)) continue;

                using (var processor = new TNineStringProcessor(TNineAlhabetMapType.Latin))
                {
                    outputList.Add($"Case #{ind}: {processor.Process(currentLine, isLargeDataSet)}");
                }
            }

            string outPath = path + ".out";

            File.WriteAllLines(outPath, outputList);

            
        }
    }
}
