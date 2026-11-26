
using System;
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

Console.WriteLine("\nProcessing 10 records...");
Console.WriteLine("Press C to cancel.");

Stopwatch stopwatch = Stopwatch.StartNew();

// Start asynchronous processing.
Task processingTask = ProcessDataAsync(cts.Token, logger);

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
}
catch (OperationCanceledException)
{
    stopwatch.Stop();

    logger.LogWarning("Processing was cancelled by the user.");
    logger.LogInfo($"Processing stopped after {stopwatch.Elapsed.TotalSeconds:F2} seconds");

    Console.WriteLine("\nProcessing was cancelled!");
}
catch (Exception ex)
{
    stopwatch.Stop();

    logger.LogError($"Processing failed: {ex.Message}");

    Console.WriteLine("\nAn unexpected error occurred.");
}

// Application finished.
logger.LogInfo("Application finished.");

// Asynchronous processing method.
static async Task ProcessDataAsync(
    CancellationToken token,
    AppLogger logger)
{
    const int totalRecords = 10;

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
    }
}
