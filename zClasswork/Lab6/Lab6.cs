namespace CompSci.zClasswork.Lab6;

public class Lab6
{
    public static void Main()
    {
        item[] items =
        [
            new Television(1097.99, "Q60B", "Samsung", 75),
            new Television(179.99, "F20", "Insignia", 32),
            new Television(1097.99, "QN90A", "Samsung", 98),
            
            new Desktop(2229.39, "Z2G4", "HP", 1024),
            new Desktop(699.99, "Inspiron 3910", "Dell", 256),
            new Desktop(204.62, "M92p", "Lenovo", 3072),
            
            new Laptop(1093.60, "EliteBook 850 G8", "HP", 512, 4),
            new Laptop(1879.00, "XPS 17", "Dell", 1024, 10),
            new Laptop(169.99, "A4-9120e", "Gateway", 64, 8),
            new Laptop(2399.99, "ROG STRIX G16", "ASUS", 3072, 2)

        ];
        
        Console.WriteLine("ITEMS AVAILABLE FOR SALE:");
        for (int i = 0; i < items.Length; i++)
        {
            Console.WriteLine($"{items[i]}");
        }
        
        Console.WriteLine("\nALL COMPUTERS ON SALE THIS WEEKEND!!!!!!! 25% OFF!!!!!\n");

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] is Computer c)
            {
                c.Price *= 0.75;
            }
        }

        for (int i = 0; i < items.Length; i++)
        {
            Console.WriteLine($"{items[i]}");
        }
    }
}