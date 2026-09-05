string logFilePath = "sample.log";
try
{
    SampleLogGenerator.Generate(logFilePath, 1200);
    Console.WriteLine("Log file generated.\n");

    var entries = LogParser.Parse(logFilePath);
    Console.WriteLine($"Parsed {entries.Count} entries.\n");

    Console.WriteLine("--- Summary ---");
    Console.WriteLine(LogAnalyser.GetSummary(entries));

    Console.WriteLine("\n--- Severity Counts ---");
    var counts = LogAnalyser.CountBySeverity(entries);
    foreach (var c in counts)
    {
        Console.WriteLine($"{c.Key}: {c.Value}");
    }

    Console.WriteLine("\n--- Top 3 Most Common Errors ---");
    var topErrors = LogAnalyser.GetMostCommonErrors(entries, 3);
    foreach (var c in topErrors)
    {
        Console.WriteLine($"{c.Value}x {c.Key}");
    }
}

catch (FileNotFoundException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    Console.WriteLine("Please check the file path and try again.");
}