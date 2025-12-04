namespace CompSci.zClasswork;

public class DelegatesPart1
{
    static void HelloWorld()
    {
        Console.WriteLine("Hello World!");
    }

    static int Square(int x)
    {
        return x * x;
    }
    
    static bool IsEven(int x)
    {
        return x % 2 == 0;
    }

    static bool IsPrime(int x)
    {
        if (x <= 1)
            return false;
        if (x == 2)
            return true;
        if (x % 2 == 0)
            return false;
        
        for (int i = 3; i <= Math.Sqrt(x); i += 2)
        {
            if (x % i == 0)
                return false;
        }
        
        return true;
    }

    public static void Main()
    {
        // Action hold methods that are void (No Return Type)
        // Func hold methods that return a value and can take in arguments.
        // Predicate holds a method and returns a bool if the argument
        //      meets the criteria of the held method.
        
        
        // Actions are a way to encapsulates void methods that have no return type.
        Action a1 = HelloWorld;
        Console.WriteLine("\nActions:");
        a1.Invoke();
        // ^ This is inefficient. Never do this.
        
        // Action a2 = Console.WriteLine;
        // a2.Invoke("Hello!"); This wont work. Doesn't allow arguments.
        
        Action<string> a2 = Console.WriteLine;
        a2.Invoke("Delegates are cool!");
        // ^ Dont use this for shorthands...

        Console.WriteLine("\nFuncs (Functions):");
        // Func's (Functions) are just actions but for methods that returns a value.
        // For a Func, the last value type is the output. The types before are the arguments.
        Func<int, int> f1 = Square;
        Console.WriteLine(f1.Invoke(4));
        
        Func<int, bool> f2 = IsEven;
        Console.WriteLine(f2(4));
        Console.WriteLine(f2(5));
        
        
        // Represents the method that defines a set of criteria and determines
        // whether the specified object meets those criteria.
        Predicate<int> p1 = IsEven;
        Console.WriteLine("\nPredicates:");
        Console.WriteLine(p1(4));
        Console.WriteLine(p1(5));
        
        p1 = IsPrime;
        Console.WriteLine(p1(4));
        Console.WriteLine(p1(5));
        
        
        Console.WriteLine("\nUse Cases Output:");
        List<int> nums = new List<int>(100);
        for (int i = 0; i < 100; i++)
        {
            nums.Add(i);
        }
        
        /*
            Console.WriteLine("Even Numbers:\n");
            foreach (int num in nums)
            {
                if (IsEven(num))
                    Console.Write(num + " ");
            }

            Console.WriteLine("\nPrime Numbers:\n");
            foreach (int num in nums)
            {
                if (IsPrime(num))
                    Console.Write(num + " ");

            }
            Console.WriteLine();
            
         #  While this is ok, it is inefficient. Using Enumerables, Actions, Funcs
            and Predicates can be really useful.
        */ 
        
        Console.WriteLine("Even Numbers:\n");
        PrintIf(nums, IsEven);
        
        Console.WriteLine("Prime Numbers:\n");
        PrintIf(nums, IsPrime);
    
        Predicate<int> p2 = x => x < 10;
                    //   (Returns x if x < 10)
        Console.WriteLine("Single Digit Numbers:\n");
        PrintIf(nums, x => x < 10);
        
        // Making a method like this is creditably efficient!
        static void PrintIf<T>(IEnumerable<T> values, Predicate<T> p)
        {
            foreach (T x in values)
            {
                if (p(x))
                    Console.Write(x + " ");
            }
            Console.WriteLine();
        }
        
        
    }
    
}