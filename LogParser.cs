public static class LogParser
{
    public static List<LogEntry> Parse(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"The log file '{filePath}' does not exist.");
        }

        var entries = new List<LogEntry>();
        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            try
            {
                string timestampPart = line.Substring(0, 19);
                DateTime timestamp = DateTime.Parse(timestampPart);

                int severityStart = line.IndexOf('[') + 1;
                int severityEnd = line.IndexOf(']');
                string severity = line.Substring(severityStart, severityEnd - severityStart);

                string message = line.Substring(severityEnd + 2);

                entries.Add(new LogEntry
                {
                    Timestamp = timestamp,
                    Severity = severity,
                    Message = message
                });
            }
            catch
            {
                Console.WriteLine($"Skipping invalid log line: {line}");

            }
        }

        return entries;
    }
}
