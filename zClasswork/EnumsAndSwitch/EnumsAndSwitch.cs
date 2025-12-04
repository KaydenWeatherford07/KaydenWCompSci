namespace CompSci.zClasswork.EnumsAndSwitch;

public static class EnumsAndSwitch
{
    private static void Main()
    {
        for (Day d = Day.Monday; d <= Day.Tuesday; d++)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine($"Thoughts on {d}?");
            TellItLikeItIs(d);   
        }
    }

    private static void TellItLikeItIs(Day day)
    {
        switch (day)
        {
            case Day.Monday:
                Console.WriteLine("Monday's are awful..");
                break;
            case Day.Tuesday:
                Console.WriteLine("Tuesday's are Great!");
                break;
            case Day.Wednesday:
                Console.WriteLine("Wednesday's are meh...");
                break;
            case Day.Thursday:
                Console.WriteLine("Thursday's are Great!");
                break;
            case Day.Friday:
                Console.WriteLine("Friday's are meh...");
                break;
            case Day.Saturday:
            case Day.Sunday:
                Console.WriteLine("WEEKENDS ARE AWESOME!!!!!!!");
                break;
            default:
                Console.WriteLine("Hmm whar..?");
                break;
        }
    }
}