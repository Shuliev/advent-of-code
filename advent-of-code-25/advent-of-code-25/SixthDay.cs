using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode25
{
    public static class SixthDay
    {
        private static List<string> input = AdventFileReader.ReadInputToList("SixthDay");

        public static string SolveFirstExercise()
        {
            //input = AdventFileReader.ReadInputToList("SixthDay", true);
            double result = 0;

            var listAllNumbers = new List<List<double>>();
            var listAllOperations = new List<string>();
            for (int i = 0; i < input.Count; i++)
            {
                var numbers = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (i == input.Count - 1)
                {
                    listAllOperations = new List<string>(numbers);
                    break;
                }

                var listLineNumbers = numbers.Select(x => double.Parse(x)).ToList<double>();
                listAllNumbers.Add(listLineNumbers);
            }

            for (int i = 0; i < listAllOperations.Count; i++)
            {
                double tempResult = 0;
                for (int j = 0; j < listAllNumbers.Count; j++)
                {
                    var number = listAllNumbers[j][i];
                    if (listAllOperations[i] == "*")
                    {
                        tempResult = tempResult == 0 ? 1 : tempResult;
                        tempResult *= number;
                    }
                    else
                    {
                        tempResult += number;
                    }
                }
                result += tempResult;
            }

            return result.ToString();
        }

        public static string SolveSecondExercise()
        {
            //input = AdventFileReader.ReadInputToList("SixthDay", true);
            double result = 0;

            var listAllNumbers = new List<List<double>>();

            var numbers = input[input.Count - 1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var listAllOperations = new List<string>(numbers);

            for (int k = 0; k < input.Count - 1; k++)
            {
                listAllNumbers.Add(new List<double>());
            }

            var index = 0;

            for (int i = 0; i < input[input.Count - 1].Length; i++)
            {
                var numberStr = string.Empty;
                for (int j = 0; j < input.Count - 1; j++)
                {
                    var actualSymbol = input[j][i];
                    numberStr += actualSymbol;
                }

                if (index < input.Count - 1)
                {
                    if (!double.TryParse(numberStr, out var number))
                    {
                        number = listAllOperations[listAllNumbers[0].Count - 1] == "*" ? 1 : 0;
                        i--;
                    }
                    listAllNumbers[index].Add(number);

                    index++;
                }
                else
                {
                    index = 0;
                }
            }

            for (int y = 0; y < input.Count - 1; y++)
            {
                if (listAllNumbers[y].Count < 1000)
                {
                    var number = listAllOperations[listAllNumbers[0].Count - 1] == "*" ? 1 : 0;
                    listAllNumbers[y].Add(number);
                }
            }

            for (int k = 0; k < listAllOperations.Count; k++)
            {
                double tempResult = 0;
                for (int z = 0; z < listAllNumbers.Count; z++)
                {
                    var number = listAllNumbers[z][k];
                    if (listAllOperations[k] == "*")
                    {
                        tempResult = tempResult == 0 ? 1 : tempResult;
                        tempResult *= number;
                    }
                    else
                    {
                        tempResult += number;
                    }
                }
                result += tempResult;
            }

            return result.ToString();
        }
    }
}
