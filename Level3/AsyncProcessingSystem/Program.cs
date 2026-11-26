
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

Console.WriteLine("====================================");
Console.WriteLine("       ASYNC PROCESSING SYSTEM");
Console.WriteLine("====================================");

// Create logger.
AppLogger logger = new AppLogger();

logger.LogInfo("Application started.");

// Create cancellation controller.
using CancellationTokenSource cts = new();

// Ask the user how many records to process.
int totalRecords;

while (true)
{
    Console.Write("\nHow many records would you like to process? ");

    string? input = Console.ReadLine();

    if (int.TryParse(input, out totalRecords) && totalRecords > 0)
    {
        break;
    }

    Console.WriteLine(
        "Invalid input! Please enter a positive whole number.");
}

int processedRecords = 0;

Console.WriteLine($"\nProcessing {totalRecords} records...");
Console.WriteLine("Press C to cancel.");

Stopwatch stopwatch = Stopwatch.StartNew();

// Start asynchronous processing.
Task processingTask = ProcessDataAsync(
    cts.Token,
    logger,
    totalRecords,
    count => processedRecords = count
);

logger.LogInfo("Data processing started.");

// Monitor keyboard input.
while (!processingTask.IsCompleted)
{
    if (Console.KeyAvailable)
    {
        ConsoleKeyInfo key = Console.ReadKey(true);

        if (key.Key == ConsoleKey.C)
        {
            Console.Write("\nAre you sure you want to cancel? (Y/N): ");

            ConsoleKeyInfo confirmation = Console.ReadKey(true);

            if (confirmation.Key == ConsoleKey.Y)
            {
                cts.Cancel();
                logger.LogWarning("Cancellation requested.");
            }
            else
            {
                logger.LogInfo("Processing will continue.");
            }
        }
    }

    await Task.Delay(100);
}

// Handle completion.
try
{
    await processingTask;

    stopwatch.Stop();

    logger.LogInfo("All records processed successfully.");
    logger.LogInfo($"Total processing time: {stopwatch.Elapsed.TotalSeconds:F2} seconds");

    Console.WriteLine("\nAll records processed successfully!");

    GenerateReport(
        "COMPLETED",
        stopwatch.Elapsed.TotalSeconds,
        totalRecords,
        processedRecords,
        "All records were processed successfully.");
}
catch (OperationCanceledException)
{
    stopwatch.Stop();

    logger.LogWarning("Processing was cancelled by the user.");

    logger.LogInfo(
        $"Processing stopped after {stopwatch.Elapsed.TotalSeconds:F2} seconds");

    Console.WriteLine("\nProcessing was cancelled!");

    GenerateReport(
        "CANCELLED",
        stopwatch.Elapsed.TotalSeconds,
        totalRecords,
        processedRecords,
        "Processing was cancelled by the user.");
}
catch (Exception ex)
{
    stopwatch.Stop();

    logger.LogError($"Processing failed: {ex.Message}");

    Console.WriteLine("\nAn unexpected error occurred.");

    GenerateReport(
        "FAILED",
        stopwatch.Elapsed.TotalSeconds,
        totalRecords,
        processedRecords,
        ex.Message);
}

// Application finished.
logger.LogInfo("Application finished.");

// Asynchronous processing method.
static async Task ProcessDataAsync(
    CancellationToken token,
    AppLogger logger,
    int totalRecords,
    Action<int> updateProgress)
{
    for (int i = 1; i <= totalRecords; i++)
    {
        token.ThrowIfCancellationRequested();

        await Task.Delay(1000, token);

        int percentage = (i * 100) / totalRecords;
        int progressBlocks = percentage / 10;

        string progressBar =
            new string('#', progressBlocks) +
            new string('-', 10 - progressBlocks);

        Console.WriteLine(
            $"Record {i}/{totalRecords} [{progressBar}] {percentage}% completed");

        logger.LogInfo(
            $"Record {i} completed. Progress: {percentage}%");

        // Update successfully processed record count.
        updateProgress(i);
    }
}

// Generate processing report.
static void GenerateReport(
    string status,
    double processingTime,
    int totalRecords,
    int processedRecords,
    string details)
{
    string reportFile = "processing-report.txt";

    int remainingRecords = totalRecords - processedRecords;

    string report =
        "====================================\n" +
        "       PROCESSING REPORT\n" +
        "====================================\n" +
        $"Date: {DateTime.Now}\n" +
        $"Status: {status}\n" +
        $"Total Records: {totalRecords}\n" +
        $"Successfully Processed: {processedRecords}\n" +
        $"Remaining Records: {remainingRecords}\n" +
        $"Processing Time: {processingTime:F2} seconds\n" +
        $"Details: {details}\n" +
        "====================================\n\n";

    File.AppendAllText(reportFile, report);

    Console.WriteLine("\nProcessing report saved successfully!");

    Console.WriteLine($"Total Records: {totalRecords}");
    Console.WriteLine($"Successfully Processed: {processedRecords}");
    Console.WriteLine($"Remaining Records: {remainingRecords}");
}
