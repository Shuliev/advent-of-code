namespace AdventOfCode25
{
    public static class SecondDay
    {
        private static string input = AdventFileReader.ReadInputToString("SecondDay");

        public static string SolveInvalidIdFirstExercise()
        {
            //input = AdventFileReader.ReadInputToString("SecondDay", true);
            var rawinput = input.Split(',', StringSplitOptions.RemoveEmptyEntries);

            double result = 0;
            foreach (var item in rawinput)
            {
                var pair = item.Split('-', StringSplitOptions.RemoveEmptyEntries);

                double first = double.Parse(pair[0]);
                double second = double.Parse(pair[1]);

                for (var i = first; i <= second; i++)
                {
                    var numberStr = i.ToString();
                    if (numberStr.Length % 2 == 0)
                    {
                        var part1 = numberStr.Substring(0, numberStr.Length / 2);
                        var part2 = numberStr.Substring(numberStr.Length / 2, numberStr.Length / 2);

                        if (part1 == part2)
                        {
                            result += i;
                        }
                    }
                }
            }

            return result.ToString();
        }

        public static string SolveInvalidIdSecondExercise()
        {
            //input = AdventFileReader.ReadInputToString("SecondDay", true);
            var rawinput = input.Split(',', StringSplitOptions.RemoveEmptyEntries);

            double result = 0;
            foreach (var item in rawinput) // for each range a - b
            {
                var pair = item.Split('-', StringSplitOptions.RemoveEmptyEntries);

                double first = double.Parse(pair[0]);
                double second = double.Parse(pair[1]);

                for (var i = first; i <= second; i++) // for each number in the range a - b
                {
                    var numberStr = i.ToString();
                    for (var j = 0; j < (numberStr.Length / 2); j++) // for each possible group (from length 1 to length n/2)
                    {
                        var sizeOfPart = j + 1;
                        var basedpart = numberStr.Substring(0, sizeOfPart);
                        var isEqual = true;
                        for (var k = j + 1; k < numberStr.Length; k += sizeOfPart) // for each possible next part
                        {
                            if (k + sizeOfPart > numberStr.Length)
                            {
                                isEqual = false;
                                break;
                            }

                            var part = numberStr.Substring(k, sizeOfPart);
                            if (part != basedpart)
                            {
                                isEqual = false;
                                break;
                            }
                        }

                        if (isEqual)
                        {
                            result += i;
                            break;
                        }
                    }
                }
            }

            return result.ToString();
        }
    }
}
