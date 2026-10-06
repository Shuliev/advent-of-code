namespace AdventOfCode25
{
    public static class AdventFileReader
    {
        private static readonly string BaseResourcesPath = Path.Combine("..", "..", "..", "Resources");

        public static List<string> ReadInputToList(string dayName, bool useExample = false, bool returnTypeText = false)
        {
            string fullPath = GetPath(dayName, useExample);

            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"File Not Founded: {fullPath}");

            return File.ReadAllLines(fullPath).ToList();
        }

        public static string ReadInputToString(string dayName, bool useExample = false, bool returnTypeText = false)
        {
            string fullPath = GetPath(dayName, useExample);

            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"File Not Founded: {fullPath}");

            return File.ReadAllText(fullPath);
        }

        private static string GetPath(string dayName, bool useExample)
        {
            string fileName = useExample
                ? $"{dayName}Example.txt"
                : $"{dayName}OfAdventCode.txt";

            return Path.Combine(BaseResourcesPath, dayName, fileName);
        }
    }
}
