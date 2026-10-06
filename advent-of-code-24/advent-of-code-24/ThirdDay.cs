using System;
using System.Text.RegularExpressions;

namespace AdventOfCode24
{
    public static class ThirdDay
    {
        private static string input = File.ReadAllText(@"..\..\..\Resources\ThirdDayOfAdventCode.txt");

        public static string SolveFirstExercise()
        {
            //input = File.ReadAllText(@"..\..\..\Resources\ThirdDayExample.txt");
            var result = 0;

            var pattern = @"(mul\((\d+),(\d+)\))";
            var matches = Regex.Matches(input, pattern);

            var firstNumber = new List<int>();
            var secondNumber = new List<int>();

            foreach (Match match in matches)
            {
                firstNumber.Add(int.Parse(match.Groups[2].Value));
                secondNumber.Add(int.Parse(match.Groups[3].Value));
            }

            for (int i = 0; i < firstNumber.Count; i++)
            {
                result += firstNumber[i] * secondNumber[i];
            }

            return result.ToString();
        }

        public static string SolveSecondExercise()
        {
            //input = File.ReadAllText(@"..\..\..\Resources\ThirdDayExample.txt");
            var result = 0;

            var pattern = @"mul\((?<num1>\d+),(?<num2>\d+)\)|(?<do>do\(\))|(?<dont>don't\(\))";

            var matchesNum = Regex.Matches(input, pattern);

            var numbers = new List<(int Index, int A, int B)>();
            var ops = new List<(int Index, string Operation)>();

            foreach (Match match in matchesNum)
            {
                if (match.Groups["num1"].Success)
                {
                    numbers.Add(new(match.Index,
                        int.Parse(match.Groups["num1"].Value),
                        int.Parse(match.Groups["num2"].Value)));
                }
                else if (match.Groups["do"].Success) 
                {
                    ops.Add(new(match.Index, "do"));
                }
                else if (match.Groups["don't"].Success)
                {
                    ops.Add(new(match.Index, "don't"));
                }
            }

            ops.Sort();
            var indexActualOperation = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (indexActualOperation == ops.Count && ops[indexActualOperation - 1].Operation == "do")
                {
                    result += numbers[i].A * numbers[i].B;
                }
                else
                {
                    if (numbers[i].Index < ops[indexActualOperation].Index)
                    {
                        if (indexActualOperation == 0 || indexActualOperation > 0 && ops[indexActualOperation - 1].Operation == "do")
                        {
                            result += numbers[i].A * numbers[i].B;
                        }
                    }
                    else
                    {
                        indexActualOperation++;
                        i--;
                    }
                }

            }

            return result.ToString();
        }
    }
}
