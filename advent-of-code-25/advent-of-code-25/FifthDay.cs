namespace AdventOfCode25
{
    public static class FifthDay
    {
        private static List<string> input = AdventFileReader.ReadInputToList("FifthDay");

        public static string SolveFirstExercise()
        {
            //input = AdventFileReader.ReadInputToList("FifthDay", true);

            var result = 0;

            var indexOfSeparator = input.FindIndex(line => string.IsNullOrWhiteSpace(line));

            var range = new List<(long A, long B)>();
            var values = new List<long>();

            for (int i = 0; i < indexOfSeparator; i++)
            {
                var index = input[i].IndexOf('-');
                var firstNumber = input[i].Substring(0, index);
                var secondNumber = input[i].Substring(index, input[i].Length - index).Replace("-", "").Trim();

                range.Add(
                    new(long.Parse(firstNumber), long.Parse(secondNumber))
                    );
            }

            for (int i = indexOfSeparator + 1; i < input.Count; i++)
            {
                values.Add(long.Parse(input[i]));
            }

            foreach (var value in values)
            {
                var isValid = false;
                foreach (var (A, B) in range)
                {
                    if (value >= A && value <= B)
                    {
                        isValid = true;
                        break;
                    }
                }
                if (isValid)
                {
                    result++;
                }
            }

            return result.ToString(); //442
        }

        public static string SolveSecondExercise()
        {
            //input = AdventFileReader.ReadInputToList("FifthDay", true);

            long result = 0;

            var indexOfSeparator = input.FindIndex(line => string.IsNullOrWhiteSpace(line));

            var range = new List<(long A, long B)>();

            for (int i = 0; i < indexOfSeparator; i++)
            {
                var index = input[i].IndexOf('-');
                var firstNumberStr = input[i].Substring(0, index);
                var secondNumberStr = input[i].Substring(index, input[i].Length - index).Replace("-", "").Trim();

                var firstNumber = long.Parse(firstNumberStr);
                var secondNumber = long.Parse(secondNumberStr);

                range.Add(new (firstNumber, secondNumber));
                range.Sort();
            }

            long tempResult = 0;
            for (int i = 0; i < range.Count; i++)
            {
                if (i ==  range.Count - 1)
                {
                    result += tempResult + range[i].B - range[i].A + 1;
                    break;
                }

                var actual = range[i];
                var next = range[i + 1];

                var areSeparated = next.A > actual.B; // Act separate from Nex
                var areIntersected = next.A <= actual.B && next.B > actual.B; // Act insterected Nex
                var isActIncludedNext = next.A == actual.A && next.B >= actual.B;  // Act-set in Nex-set
                var isNextIncludedAct = next.A > actual.A && next.B <= actual.B; // Nex-set in Act-set

                if (areSeparated)
                {
                    result += tempResult + actual.B - actual.A + 1;
                    tempResult = 0;
                }
                else
                {
                    if (areIntersected)
                    {
                        tempResult += (actual.B - actual.A + 1) - (actual.B - next.A + 1);
                    }
                    else
                    {
                        if (isActIncludedNext) // together they are true for all options
                        {
                            Console.WriteLine($"*");
                        }
                        else if (isNextIncludedAct)
                        {
                            range[i + 1] = actual;
                            range[i] = next;

                            Console.WriteLine($"+");
                        }
                    }
                }
            }

            return result.ToString();
        }
    }
}
