// See https://aka.ms/new-console-template for more information

using ConsoleApp1;

IEnumerable<double> GetRowSums(IEnumerable<double> row)
{
    double sum = 0;
    return row.Select(x => sum += x);
}
List<double> d = new List<double>() { 1, 2, 3, 4 };
var s = GetRowSums(d);
foreach(var k in s)
{
    Console.WriteLine(k);
}

AsyncTaskProcessor taskProcessor = new AsyncTaskProcessor();
taskProcessor.AddTask(async () =>
{
    Console.WriteLine("Task 1 started");
    await Task.Delay(1000);
    Console.WriteLine("Task 1 finished");
});

taskProcessor.AddTask(async () =>
{
    Console.WriteLine("Task 2 started");
    await Task.Delay(2000);
    Console.WriteLine("Task 2 finished");
});

await taskProcessor.WaitAllTasks();
Console.WriteLine("All tasks finished");

