namespace AdventOfCode24
{
    public static class SecondDay
    {
        private static List<string> input = File.ReadAllLines(@"..\..\..\Resources\SecondDayOfAdventCode.txt").ToList<string>();

        public static string SolveFirstExercise()
        {
            //input = File.ReadAllLines(@"..\..\..\Resources\SecondDayExample.txt").ToList();
            var result = 0;

            foreach (var block in input)
            {
                var numbersSrt = block.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var numbers = numbersSrt.Select(x => int.Parse(x)).ToList();

                var isIncreasing = true;

                if (numbers[0] < numbers[1])
                {
                    isIncreasing = false;
                }

                result++;
                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        if (!isIncreasing)
                        {
                            result--;
                            break;
                        }
                    }
                    else
                    {
                        if (isIncreasing)
                        {
                            result--;
                            break;
                        }
                    }

                    if (Math.Abs(numbers[i] - numbers[i + 1]) > 3
                        || numbers[i] == numbers[i + 1])
                    {
                        result--;
                        break;
                    }
                }
            }

            return result.ToString();
        }

        public static string SolveSecondExercise()
        {
            //input = File.ReadAllLines(@"..\..\..\Resources\SecondDayExample.txt").ToList();
            var result = 0;

            foreach (var block in input)
            {
                var numbersSrt = block.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var numbers = numbersSrt.Select(x => int.Parse(x)).ToList();

                var isDecreasing = true;
                var firstTry = true;
                var firstDelete = true;

                var indexDecr = 0;
                var indexIncr = 0;

                for (int j = 0; j < numbers.Count - 1; j++)
                { 
                    if (numbers[j] < numbers[j + 1])
                    {
                        indexIncr++;
                    }
                    else
                    {
                        indexDecr++;
                    }
                }

                if (indexIncr > indexDecr)
                {
                    isDecreasing = false;
                }

                result++;
                var clone = new List<int>(numbers);
                var index = 0;

                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    var isFailed = false;
                    var invalidDistence = Math.Abs(numbers[i] - numbers[i + 1]) > 3
                        || numbers[i] == numbers[i + 1];

                    var invalidDirection = (numbers[i] > numbers[i + 1] && !isDecreasing)
                        || (numbers[i] < numbers[i + 1] && isDecreasing);

                    if (invalidDirection || invalidDistence)
                    {
                        isFailed = true;
                    }

                    if (isFailed)
                    {
                        if (!firstTry)
                        {
                            result--;
                            break;
                        }

                        if (firstDelete)
                        {
                            numbers.RemoveAt(i);
                            firstDelete = false;
                            index = i;
                        }
                        else
                        {
                            numbers = new List<int>(clone);
                            numbers.RemoveAt(index + 1);
                            firstTry = false;
                        }

                        i = -1;

                        isDecreasing = true;
                        if (numbers[0] < numbers[1])
                        {
                            isDecreasing = false;
                        }
                    }
                }
            }

            return result.ToString();
        }
    }
}
