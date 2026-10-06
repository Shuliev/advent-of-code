using System.Text.RegularExpressions;

namespace AdventOfCode25
{
    public static class FirstDay
    {
        private static List<string> input = AdventFileReader.ReadInputToList("FirstDay");

        public static string SolvePasswordFirstExercise()
        {
            //input = AdventFileReader.ReadInputToList("FirstDay", true);

            int password = 0;
            var i = 50;
            var pattern = @"^([A-Za-z])(\d{1,3})$";
            foreach (string item in input)
            {
                var match = Regex.Match(item, pattern);
                var direction = match.Groups[1].Value;
                var value = int.Parse(match.Groups[2].Value);

                var i2 = 0;

                if (direction == "L")
                {
                    i2 = i - value % 100;
                }
                else
                {
                    i2 = i + value % 100;
                }

                switch (i2)
                {
                    case 0 :
                    case 100:
                        i = 0;
                        password++;
                        break;

                    case < 0:
                        i = i2 + 100;
                        break;

                    case > 100:
                        i = i2 - 100;
                        break;

                    default:
                        i = i2;
                        break;
                }

            }

            return password.ToString();
        }

        public static string SolvePasswordSecondExercise()
        {
            //input = AdventFileReader.ReadInputToList("FirstDay", true);

            int password = 0;
            var i = 50;
            var pattern = @"^([A-Za-z])(\d{1,3})$";
            foreach (string item in input)
            {
                var match = Regex.Match(item, pattern);
                var direction = match.Groups[1].Value;
                var value = int.Parse(match.Groups[2].Value);

                var i2 = 0;

                if (direction == "L")
                {
                    i2 = i - value % 100;
                }
                else
                {
                    i2 = i + value % 100;
                }

                password += value / 100 + 1;

                switch (i2)
                {
                    case 0:
                    case 100:
                        i = 0;
                        break;

                    case < 0:
                        if (i == 0)
                        {
                            password--;
                        }
                        i = 100 + i2;
                        break;

                    case > 100:
                        if(i == 100)
                        {
                            password--;
                        }
                        i = i2 - 100;
                        break;

                    default:
                        i = i2;
                        password--;
                        break;
                }

            }

            return password.ToString();
        }
    }
}
