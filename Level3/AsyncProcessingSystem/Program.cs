
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

Console.WriteLine("====================================");
Console.WriteLine("       ASYNC PROCESSING SYSTEM");
Console.WriteLine("====================================");

Console.WriteLine("Select the tasks you want to process:");
Console.WriteLine("1. Student Records");
Console.WriteLine("2. Payment Records");
Console.WriteLine("3. Employee Records");

Console.Write("\nEnter your choices separated by commas (e.g. 1,2,3): ");

string? input = Console.ReadLine();

string[] choices = (input ?? "").Split(',');

List<Task> tasks = new List<Task>();

foreach (string choice in choices)
{
    string selectedTask = choice.Trim();

    switch (selectedTask)
    {
        case "1":
            tasks.Add(ProcessDataAsync("Student Records", 3000));
            break;

        case "2":
            tasks.Add(ProcessDataAsync("Payment Records", 2000));
            break;

        case "3":
            tasks.Add(ProcessDataAsync("Employee Records", 1000));
            break;

        default:
            Console.WriteLine($"Invalid option: {selectedTask}");
            break;
    }
}

if (tasks.Count > 0)
{
    try
    {
        await Task.WhenAll(tasks);
        Console.WriteLine("\nAll selected tasks completed!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\nProcessing error: {ex.GetBaseException().Message}");
    }
}
else
{
    Console.WriteLine("No valid tasks were selected.");
}

static async Task ProcessDataAsync(string taskName, int delay)
{
    Console.WriteLine($"{taskName}: Processing started...");

    await Task.Delay(delay);

    Console.WriteLine($"{taskName}: Processing completed!");
}
