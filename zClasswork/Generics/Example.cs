using System.ComponentModel;

namespace CompSci.zClasswork.Generics;

public class Example
{
    public static void Main()
    {
        Container<int> c1 = new Container<int>();
        Container<string> c2 = new Container<string>();
        Container c3 = new Container();
        c1.Value = 1;
        c2.Value = "Two";
        
    }
}