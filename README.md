# Log Analyzer

## Overview
A CLI application that reads application log files and reports on their contents.
Built as part of a C# learning journey focusing on error handling and clean code structure.

## Features
- Parses log files with INFO, DEBUG, WARNING, and ERROR severity levels
- Reports entry counts by severity
- Identifies the most common error messages
- Displays a summary including total entries and date range

## How to Run
1. Open the solution in Visual Studio
2. Run the project — it generates a sample log file automatically and analyses it

## Edge Cases Handled
1. **Missing log file** — the app catches the exception and displays a clear error message instead of crashing
2. **Malformed log lines** — invalid lines are skipped with a warning; the rest of the file continues to parse normally
3. **Empty log file** — the app reports zero entries and exits cleanly
4. **Unexpected file content** — any line that doesn't match the expected format is treated as malformed and skipped
5. **File path flexibility** — the log file path is defined in one place, making it easy to change without touching multiple files

## What I Learned
- How to use try/catch blocks and when to throw vs catch exceptions
- The difference between handling errors at the file level vs the line level
- How to structure an app into focused classes instead of one large Program.cs
- How to use LINQ for grouping, filtering, and counting data