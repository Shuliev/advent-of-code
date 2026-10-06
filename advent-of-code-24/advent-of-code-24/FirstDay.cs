namespace AdventOfCode24
{
    public static class FirstDay
    {
        private static List<string> input = File.ReadAllLines(@"..\..\..\Resources\FirstDayOfAdventCode.txt").ToList<string>();

        public static string SolveFirstExercise()
        {
            //input = File.ReadAllLines(@"..\..\..\Resources\FirstDayExample.txt").ToList<string>();

            var ersteSpalte = new List<int>();
            var zweiteSpalte = new List<int>();

            foreach (var block in input)
            {
                var numbers = block.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                ersteSpalte.Add(int.Parse(numbers[0]));
                zweiteSpalte.Add(int.Parse(numbers[1]));
            }

            ersteSpalte.Sort();
            zweiteSpalte.Sort();

            var summe = 0;

            for (int i = 0; i < ersteSpalte.Count; i++)
            {
                summe += Math.Abs(ersteSpalte[i] - zweiteSpalte[i]);
            }

            return summe.ToString();
        }

        public static string SolveSecondExercise()
        {
            //input = File.ReadAllLines(@"..\..\..\Resources\FirstDayExample.txt").ToList<string>();
            var ersteSpalte = new List<int>();
            var zweiteSpalte = new List<int>();

            foreach (var block in input)
            {
                var numbers = block.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                ersteSpalte.Add(int.Parse(numbers[0]));
                zweiteSpalte.Add(int.Parse(numbers[1]));
            }

            ersteSpalte.Sort();
            zweiteSpalte.Sort();
            var dictionaryOfNumbers = new Dictionary<int, int>();

            var summe = 0;

            for (int i = 0; i < ersteSpalte.Count; i++)
            {
                if (!dictionaryOfNumbers.ContainsKey(ersteSpalte[i]))
                {
                    var numberOfRepetitions = 0;

                    foreach (var number in zweiteSpalte)
                    {
                        if (number == ersteSpalte[i])
                        {
                            numberOfRepetitions++;

                        }
                    }

                    dictionaryOfNumbers.Add(ersteSpalte[i], numberOfRepetitions);
                }

                summe += ersteSpalte[i] * dictionaryOfNumbers[ersteSpalte[i]];
            }

            return summe.ToString();
        }
    }
}
