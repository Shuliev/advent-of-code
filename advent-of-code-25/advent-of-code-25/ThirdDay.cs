using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode25
{
    public static class ThirdDay
    {
        private static List<string> input = AdventFileReader.ReadInputToList("ThirdDay");
        public static string SolveJoltageFirstExercise()
        {
            //input = AdventFileReader.ReadInputToList("ThirdDay", true);
            var result = 0;

            foreach (var block in input)
            {
                var tens = 0;
                var actuallyIndex = 0;
                for (int i = 0; i < block.Length - 1; i++)
                {
                    var number = int.Parse(block[i].ToString());
                    if (number > tens)
                    {
                        tens = number;
                        actuallyIndex = i + 1;
                    }
                }

                var units = 0;
                for (int j = actuallyIndex; j < block.Length; j++)
                {
                    var number = int.Parse(block[j].ToString());
                    if (number > units)
                    {
                        units = number;
                    }
                }

                result += (10 * tens + units);
            }

            return result.ToString();
        }

        public static string SolveJoltageSecondExercise()
        {
            //input = AdventFileReader.ReadInputToList("ThirdDay", true);
            double result = 0;

            foreach (var block in input) // for each block
            {
                var units = new double[12];
                var actuallyIndex = 0;

                for (int unitIndex = 0; unitIndex < 12; unitIndex++) // for each unit (1, 10, 100, 1000, ...)
                {
                    var distanceToEnd = 11 - unitIndex;
                    for (int blockIndex = actuallyIndex; blockIndex < block.Length - distanceToEnd; blockIndex++)
                    {
                        var number = int.Parse(block[blockIndex].ToString());
                        if (number > units[unitIndex])
                        {
                            units[unitIndex] = number;
                            actuallyIndex = blockIndex + 1;
                        }
                    }
                }

                for (var i = 0; i < units.Length; i++)
                {
                    var range = (i == 12) ? 1 : Math.Pow(10, (11 - i));
                    result += units[i] * range;
                }
            }


            return result.ToString();
        }
    }
}
