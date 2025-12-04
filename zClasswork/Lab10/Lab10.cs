namespace CompSci.zClasswork.Lab10;

public class Lab10
{
    public static void Main()
    {
        /*
        Instantiate a Stack with the type argument string and a max size of 4 then do the following with it:
        Push the values "C++", "Python", "Java"
        Print the result of Pop
        Push "C#"
        Print the result of Peek
        Push "PHP"
        Print the result of Pop
        Print the result of Pop
        Instantiate a Stack with the type argument char and a max size of 8 then do the following with it:
        Push the values P, R, A, H, S, C
        While the stack's size is not zero, print the result of Pop
        Instantiate a Stack with the type argument int and a max size of 20 then do the following with it:
        Push the values 1, 7, 2, 2, 2, 1
        Compute the sum and average by popping of all value off of the stack
        Print the sum and average to the console
        */

        Stack<string> stuff = new Stack<string>(4);
        stuff.Push("C++");
        stuff.Push("Python");
        stuff.Push("Java");

        
        Console.WriteLine(stuff.Pop());
        
        stuff.Push("C#");
        
        Console.WriteLine(stuff.Peek());
        
        stuff.Push("PHP");

        Console.WriteLine(stuff.Pop());
        Console.WriteLine(stuff.Pop() + "\n");

        Stack<char> thing = new Stack<char>(8);
        thing.Push('P');
        thing.Push('R');
        thing.Push('A');
        thing.Push('H');
        thing.Push('S');
        thing.Push('C');

        while (thing.Size() != 0)
        {
            Console.WriteLine(thing.Pop());
        }
        
        Stack<int> stack = new Stack<int>(20);
        stack.Push(1);
        stack.Push(7);
        stack.Push(2);
        stack.Push(2);
        stack.Push(2);
        stack.Push(1);

        Console.WriteLine();
        
        int sum = 0;
        int amt = 0;
        while (stack.Size() != 0)
        {
            sum += stack.Pop();
            amt++;
        }
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {(double)sum / amt}");
    }
}