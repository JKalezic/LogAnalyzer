public static class LogAnalyser
{
    public static Dictionary<string, int> CountBySeverity(List<LogEntry> entries)
    {
        var groups = entries.GroupBy(e => e.Severity);

        return groups.ToDictionary(g => g.Key, g => g.Count());
    }

    public static Dictionary<string, int> GetMostCommonErrors(List<LogEntry> entries, int topN)
    {
        var errorEntries = entries.Where(e => e.Severity == "ERROR");
        var groupedErrors = errorEntries.GroupBy(e => e.Message)
            .OrderByDescending(g => g.Count())
            .Take(topN);

        return groupedErrors.ToDictionary(g => g.Key, g => g.Count());
    }

    public static string GetSummary(List<LogEntry> entries)
    {
        var totalEntries = entries.Count;
        var firstEntry = entries.Min(e => e.Timestamp);
        var lastEntry = entries.Max(e => e.Timestamp);

        string summary = $"Total log entries: {totalEntries}\t|\tFrom: {firstEntry}\t|\tTo: {lastEntry}";
        return summary;
    }
}