using Stopky_C_;

class Program
{
    static void Main(string[] args)
    {
        StopwatchManager manager = new StopwatchManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("1: Start 2: Pause 3: Stop 4: Reset 5: Save Time 6: Load Times 7: Exit");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    manager.Start();
                    break;
                case ConsoleKey.D2:
                    manager.Pause();
                    break;
                case ConsoleKey.D3:
                    manager.Stop();
                    break;
                case ConsoleKey.D4:
                    manager.Reset();
                    break;
                case ConsoleKey.D5:
                    Console.WriteLine("\nEnter name to save time:");
                    string name = Console.ReadLine();
                    manager.SaveTime(name);
                    break;
                case ConsoleKey.D6:
                    var times = manager.LoadTimes();
                    foreach (var time in times)
                        Console.WriteLine($"{time.Key}: {time.Value}");
                    break;
                case ConsoleKey.D7:
                    running = false;
                    break;
            }
            Console.WriteLine($"Elapsed Time: {manager.GetElapsedTime()}");
        }
    }
}