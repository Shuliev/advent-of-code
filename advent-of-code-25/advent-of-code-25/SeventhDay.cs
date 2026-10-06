using System.Text.RegularExpressions;

namespace AdventOfCode25
{
    public static class SeventhDay
    {
        private static List<string> input = AdventFileReader.ReadInputToList("SeventhDay");

        public static string SolveFirstExercise()
        {
            //input = AdventFileReader.ReadInputToList("SeventhDay", true);

            var result = 0;

            var splitters = new Dictionary<int, List<(int X, int Y)>>();
            var tachyons = new List<(int X, int Y)>();

            for (int i = 1; i < input.Count; i++)
            {
                var matches = Regex.Matches(input[i], @"\^");
                var splittersinI = new List<(int X, int Y)>();
                foreach (Match match in matches)
                {
                    splittersinI.Add(new(match.Index, i));
                }

                splitters.Add(i, splittersinI);
            }

            var startX = input[0].IndexOf("S");
            tachyons.Add(new(startX, 1));

            for (int i = 1; i < input.Count - 1; i++)
            {
                var nextTachyons = new List<(int X, int Y)>();
                var deleteTachyon = new List<(int X, int Y)>();

                var splittersinI = splitters[i];

                if (splittersinI.Count > 0)
                {
                    foreach (var tachyon in tachyons)
                    {
                        foreach (var splitter in splittersinI)
                        {
                            if (tachyon.X == splitter.X)
                            {
                                result++;
                                deleteTachyon.Add(tachyon);

                                if (tachyon.X > 0)
                                {
                                    nextTachyons.Add(new(tachyon.X - 1, i));
                                }

                                if (tachyon.X < input.Count - 1)
                                {
                                    nextTachyons.Add(new(tachyon.X + 1, i));
                                }
                            }
                        }
                    }
                }

                tachyons.RemoveAll(x => deleteTachyon.Contains(x));
                tachyons.AddRange(
                    nextTachyons.Where(next => !tachyons.Any(t => t.X == next.X)));
                tachyons = tachyons.Select(t => (t.X, t.Y + 1 )).ToList();
            }

            return result.ToString();
        }

        public static string SolveSecondExercise()
        {
            //input = AdventFileReader.ReadInputToList("SeventhDay", true);

            var result = 0;

            return result.ToString();
        }
    }
}
