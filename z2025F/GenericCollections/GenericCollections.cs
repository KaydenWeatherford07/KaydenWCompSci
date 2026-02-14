namespace CompSci.zClasswork.GenericCollections;

public static class GenericCollections
{
    private static void Main()
    {
        Console.WriteLine("List Demo:");
        ListDemo();
        Console.WriteLine();
        
        Console.WriteLine("Set Demo:");
        SetDemo();
        Console.WriteLine();
        
        Console.WriteLine("Map Demo:");
        MapDemo();
    }

    private static void ListDemo()
    {
        List<int> numbers = new List<int>(4);
        
        numbers.Add(10);
        numbers.Add(20);
        numbers.Add(30);
        numbers.Add(40);
        
        numbers.Add(50); // Force Resize

        // for (int i = 0; i < numbers.Count; i++)
        // {
        //     Console.Write(numbers[i] + " ");
        // }
        // Console.WriteLine();
        
        // IEnumerator<int> enumerator = numbers.GetEnumerator();
        // while (enumerator.MoveNext())
        // {
        //     Console.WriteLine(enumerator.Current);
        // }
        // Console.WriteLine();

        foreach (int number in numbers)
        {
            Console.WriteLine(number + " ");
        }
        Console.WriteLine();
    }

    private static void SetDemo()
    {
        HashSet<String> names = new HashSet<String>();
        names.Add("John");
        names.Add("Brian");
        names.Add("Jane");
        names.Add("Gria");
        
        Console.WriteLine(string.Join(", ", names));
        
        if(names.Contains("John")){
            Console.WriteLine("Yes, the set contains John");
        }
        else
        {
            Console.WriteLine("No, the set does not contain John");
        }
        names.Remove("John");
        
        Console.WriteLine(string.Join(", ", names));
        foreach (String name in names)
        {
            Console.WriteLine(name);
        }
        
    }

    private static void MapDemo()
    {
        Dictionary<int, string> namez = new Dictionary<int, string>();
        namez.Add(9876, "John");
        namez.Add(5000, "Brian");
        namez.Add(1234, "Jane");
        namez.Add(1997, "Gria");

        Console.WriteLine("Name  - ID");
        foreach (KeyValuePair<int, string> name in namez)
        {
            Console.WriteLine(name.Value + " - " + name.Key);
        }

        namez[1356] = "Kayden";
        Console.WriteLine(namez[1356]);
        
        namez.Remove(1234);
        
        Console.WriteLine();
        foreach (KeyValuePair<int, string> name in namez)
        {
            Console.WriteLine(name.Value + " - " + name.Key);
        }
        Console.WriteLine();
        
        
    }
}