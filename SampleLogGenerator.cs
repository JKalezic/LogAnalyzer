public static class SampleLogGenerator
{
    public static void Generate(string filePath, int entryCount)
    {
        var random = new Random();

        string[] severities = { "INFO", "DEBUG", "WARNING", "ERROR" };
        string[] messages = { "Application started", "Processing request", "Low disk space", "Failed to connect to database" };
        var startTime = new DateTime(2024, 1, 15, 8, 0, 0);

        using (var writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < entryCount; i++)
            {
                string timestamp = startTime.AddSeconds(i * 3).ToString("yyyy-MM-dd HH:mm:ss");
                string severity = severities[random.Next(severities.Length)];
                string message = messages[random.Next(messages.Length)];
                writer.WriteLine($"{timestamp} [{severity}] {message}");
            }
        }
    }
}