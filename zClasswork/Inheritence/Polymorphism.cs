namespace Inheritence;

public class Polymorphism
{
    private static void Main()
    {
        Animal[] animals = [
            new Cat("Michael", 4),
            new Dog("Abbey", 4),
            new Cat("Salt", 6),
            new Dog("Cerberus", 3),
            new Dog("Peter", 4),
            new Dog("Brian", 4),
            new Cat("Dave The Magical Cheese Wizard", 9),
            new Cat("Uni", 7)
        ];


        for (int i = 0; i < animals.Length; i++)
        {
            Console.WriteLine(animals[i]);
            animals[i].Speak();
            
            Console.WriteLine("Bath Time!");

            Console.WriteLine($"Hey, {animals[i]}, want to go play fetch?");
            if (animals[i] is Dog d)
            {
                d.PlayFetch();
            }
            else
            {
                Console.WriteLine($"Can't play fetch with {animals[i]}");
            }
        }
    }
}