using System.Diagnostics;

var syncStopwatch = Stopwatch.StartNew();
Console.WriteLine(ProcessData("Файл 1"));
Console.WriteLine(ProcessData("Файл 2"));
Console.WriteLine(ProcessData("Файл 3"));
syncStopwatch.Stop();

var asyncStopWatch = Stopwatch.StartNew();

var task1 = ProcessDataAsync("АФайл 1").ContinueWith(t => Console.WriteLine(t.Result));
var task2 = ProcessDataAsync("АФайл 2").ContinueWith(t => Console.WriteLine(t.Result));
var task3 = ProcessDataAsync("АФайл 3").ContinueWith(t => Console.WriteLine(t.Result));

await Task.WhenAll(task1, task2, task3);
asyncStopWatch.Stop();
Console.WriteLine($"Синхронное выполнение заняло: {syncStopwatch.Elapsed.TotalSeconds}с.");
Console.WriteLine($"Асинхронное выполнение заняло: {asyncStopWatch.Elapsed.TotalSeconds}с.");

string ProcessData(string dataName)
{
    Thread.Sleep(3000);
    return $"Обработка {dataName} завершина за 3 секунды";
}

async Task<string> ProcessDataAsync(string dataName)
{
    await Task.Delay(3000);
    return $"Обработка {dataName} завершина за 3 секунды";
}
