using System.Diagnostics;

var syncStopwatch = Stopwatch.StartNew();
ProcessData("Файл 1");
ProcessData("Файл 2");
ProcessData("Файл 3");
syncStopwatch.Stop();

var asyncStopWatch = Stopwatch.StartNew();
await Task.WhenAll(ProcessDataAsync("АФайл 1"), ProcessDataAsync("АФайл 2"), ProcessDataAsync("АФайл 3"));
asyncStopWatch.Stop();

Console.WriteLine($"Синхронное выполнение заняло: {syncStopwatch.Elapsed.TotalSeconds}с.");
Console.WriteLine($"Асинхронное выполнение заняло: {asyncStopWatch.Elapsed.TotalSeconds}с.");

void ProcessData(string dataName)
{
    Thread.Sleep(3000);
    Console.WriteLine($"Обработка {dataName} завершина за 3 секунды");
}

async Task ProcessDataAsync(string dataName)
{
    await Task.Delay(3000);
    Console.WriteLine($"Обработка {dataName} завершина за 3 секунды");
}
