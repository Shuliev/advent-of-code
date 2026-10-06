namespace AdventOfCode25
{
    public static class FourthDay
    {
        private static List<string> inputBlocks = AdventFileReader.ReadInputToList("Fourth");

        public static string SolveFirstExercise()
        {
            //inputBlocks = AdventFileReader.ReadInputToList("Fourth", true);
            var result = 0;

            for (int i = 0; i < inputBlocks.Count; i++) // analyze each row
            {
                char[,] section = new char[3, inputBlocks.Count];

                if (i > 0 && i < inputBlocks.Count - 1)
                {
                    var topLine = inputBlocks[i - 1];
                    var actualLine = inputBlocks[i];
                    var bottomLine = inputBlocks[i + 1];

                    for (int j = 0; j < inputBlocks[i].Length; j++) // build 3 rows
                    {
                        section[0, j] = topLine[j];
                        section[1, j] = actualLine[j];
                        section[2, j] = bottomLine[j];
                    }

                    for (int k = 0; k < inputBlocks.Count; k++) // get each item
                    {
                        if (section[1, k] != '.')
                        {
                            var sumOfNeighbors = 0;
                            for (int z = k - 1; z < k + 2; z++) // analyze neighbors
                            {
                                var valid = z >= 0 && z < inputBlocks.Count; // begin or end
                                if (valid) // other one
                                {
                                    sumOfNeighbors += (section[0, z] == '@') ? 1 : 0;

                                    if (z != k)
                                    {
                                        sumOfNeighbors += (section[1, z] == '@') ? 1 : 0;
                                    }

                                    sumOfNeighbors += (section[2, z] == '@') ? 1 : 0;
                                }
                            }

                            if (sumOfNeighbors < 4)
                            {
                                result++;
                            }
                        }
                    }
                }
                else
                {
                    section = new char[2, inputBlocks.Count];

                    var actualLine = inputBlocks[i];
                    var otherLine = i == 0 ? inputBlocks[i + 1] : inputBlocks[i - 1];

                    for (int j = 0; j < inputBlocks[i].Length; j++) // build 2 rows
                    {
                        section[0, j] = actualLine[j];
                        section[1, j] = otherLine[j];

                    }

                    for (int k = 0; k < inputBlocks.Count; k++) // get each item
                    {
                        if (section[0, k] != '.')
                        {
                            var sumOfNeighbors = 0;
                            for (int z = k - 1; z < k + 2; z++) // analyze neighbors
                            {
                                var valid = z >= 0 && z < inputBlocks.Count; // begin or end
                                if (valid) // other one
                                {
                                    if (z != k)
                                    {
                                        sumOfNeighbors += (section[0, z] == '@') ? 1 : 0;
                                    }

                                    sumOfNeighbors += (section[1, z] == '@') ? 1 : 0;
                                }
                            }

                            if (sumOfNeighbors < 4)
                            {
                                result++;
                            }
                        }
                    }
                }
            }

            return result.ToString();
        }

        public static string SolveSecondExercise()
        {
            //inputBlocks = AdventFileReader.ReadInputToList("Fourth", true);
            var tempInputBlocks = new List<string>(inputBlocks);
            var result = 0;
            var resultTemp = 0;

            do
            {
                inputBlocks = new List<string>(tempInputBlocks);
                result = resultTemp;
                for (int i = 0; i < inputBlocks.Count; i++) // analyze each row
                {
                    char[,] section = new char[3, inputBlocks.Count];

                    if (i > 0 && i < inputBlocks.Count - 1)
                    {
                        var topLine = inputBlocks[i - 1];
                        var actualLine = inputBlocks[i];
                        var bottomLine = inputBlocks[i + 1];

                        for (int j = 0; j < inputBlocks[i].Length; j++) // build 3 rows
                        {
                            section[0, j] = topLine[j];
                            section[1, j] = actualLine[j];
                            section[2, j] = bottomLine[j];
                        }

                        for (int k = 0; k < inputBlocks.Count; k++) // get each item
                        {
                            if (section[1, k] != '.')
                            {
                                var sumOfNeighbors = 0;
                                for (int z = k - 1; z < k + 2; z++) // analyze neighbors
                                {
                                    var valid = z >= 0 && z < inputBlocks.Count; // begin or end
                                    if (valid) // other one
                                    {
                                        sumOfNeighbors += (section[0, z] == '@') ? 1 : 0;

                                        if (z != k)
                                        {
                                            sumOfNeighbors += (section[1, z] == '@') ? 1 : 0;
                                        }

                                        sumOfNeighbors += (section[2, z] == '@') ? 1 : 0;
                                    }
                                }

                                if (sumOfNeighbors < 4)
                                {
                                    resultTemp++;
                                    tempInputBlocks[i] = tempInputBlocks[i].Remove(k, 1).Insert(k, ".");
                                }
                            }
                        }
                    }
                    else
                    {
                        section = new char[2, inputBlocks.Count];

                        var actualLine = inputBlocks[i];
                        var otherLine = i == 0 ? inputBlocks[i + 1] : inputBlocks[i - 1];

                        for (int j = 0; j < inputBlocks[i].Length; j++) // build 2 rows
                        {
                            section[0, j] = actualLine[j];
                            section[1, j] = otherLine[j];

                        }

                        for (int k = 0; k < inputBlocks.Count; k++) // get each item
                        {
                            if (section[0, k] != '.')
                            {
                                var sumOfNeighbors = 0;
                                for (int z = k - 1; z < k + 2; z++) // analyze neighbors
                                {
                                    var valid = z >= 0 && z < inputBlocks.Count; // begin or end
                                    if (valid) // other one
                                    {
                                        if (z != k)
                                        {
                                            sumOfNeighbors += (section[0, z] == '@') ? 1 : 0;
                                        }

                                        sumOfNeighbors += (section[1, z] == '@') ? 1 : 0;
                                    }
                                }

                                if (sumOfNeighbors < 4)
                                {
                                    resultTemp++;
                                    tempInputBlocks[i] = tempInputBlocks[i].Remove(k, 1).Insert(k, ".");
                                }
                            }
                        }
                    }
                }


            } while (result != resultTemp);

            return result.ToString();
        }
    }
}
