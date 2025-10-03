
public class prog52a
{
    private static void Main(string[] args)
    {
        int length = 143;
        int width = 82;
        
        int area = length * width;
        int perimeter = (length * 2) + (2 * width);
        
        
        Console.WriteLine("The Length is: " + length + 
                          "\nThe Width is: " + width + 
                          "\nThe Area is: " + area +
                          "\nThe Perimeter is: " + perimeter);
    }
}