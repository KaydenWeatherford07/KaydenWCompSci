namespace CompSci.zClasswork.DelegatesPart2;

public class DelegatesPart2
{
    private static void Main()
    {
        List<string> words = ["fig", "kiwi", "cherry", "grape", "date", "mango", "lemon", "banana", "apple", "nectarine"];
        
        
        Console.WriteLine("Words: ");
        words.ForEach(Console.WriteLine);
        
        Console.WriteLine("\nSorted Words (Alphabetically): ");
        words.Sort();
        words.ForEach(Console.WriteLine);
        
        Console.WriteLine("\nSorted By Length: ");
        words.Sort((x, y) =>
        {
            if (x.Length > y.Length)
            {
                return -1;
            }

            if (x.Length < y.Length)
            {
                return 1;
            }
            return 0;
        });
        // ^ This is called a lambda expression. It's an unnamed method that uses the => operator.
        // You can also do:
        // words.Sort( (x,y) => x.Length.CompareTo(y.Length));
        words.ForEach(Console.WriteLine);
        
        Console.WriteLine("\nWords with 'i': ");
        words.FindAll(x => x.Contains('i')).ForEach(Console.WriteLine);
        // Or List<string> WithI = words.FindAll(x => x.Contains('i'));
        // WithI.ForEach(Console.WriteLine);
        
        Console.WriteLine("\nSorted By Last Character: ");
        words.Sort((a, b) =>
        {
            char lastCharA = a[^1];
            char lastCharB = b[^1];
            return lastCharA.CompareTo(lastCharB);
        });
        words.ForEach(Console.WriteLine);
        
        
        Console.WriteLine("\nCapitalized Words: ");
        words.ForEach(x =>
        {
            string upper = char.ToUpper(x[0]) + x[1..];
            Console.WriteLine(upper);
        });
        
        Console.WriteLine("\nTop 5 Longest Words: ");
        words.Sort((x,y) => y.Length.CompareTo(x.Length));
        int num = 1;
        words.ForEach(x =>
        {
            if (num <= 5)
            {
                Console.WriteLine(num + ": " + x);
                num++; 
             //  ^ this would be a compiler error in Java
            }
        });
        
    }
}