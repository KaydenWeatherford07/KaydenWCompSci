namespace CompSci451;

static class EventsDemo
{
    static void Main()
    {
        
        /*
        using FileSystemWatcher watcher = new FileSystemWatcher(@"C:\users\ihoph\desktop");
        watcher.EnableRaisingEvents = true;
        watcher.IncludeSubdirectories = true;
        
        watcher.Created += (sender, args) => Console.WriteLine($"File Created: {args.FullPath}");
        watcher.Deleted += (sender, args) => Console.WriteLine($"File Deleted: {args.FullPath}");
        watcher.Changed += (sender, args) => Console.WriteLine($"File Changed: {args.FullPath}");*/
        
        using var timer = new System.Timers.Timer(1000);
        timer.Start();
        timer.Elapsed += (sender, args) => Console.WriteLine($"Timer elapsed at {args.SignalTime}");
        
        
        
        
        Console.ReadKey(true);
    }
}