namespace CompSci.zClasswork.Generics;

public class Container<T>
{
    public T Value { get; set; }
}

public class Box<T2> : Container<T2> where T2 : struct
{
    
}