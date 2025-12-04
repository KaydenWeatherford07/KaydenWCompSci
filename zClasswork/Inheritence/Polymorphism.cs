namespace CompSci.zClasswork.Inheritence;

public class Polymorphism
{
    private static void Main()
    {
        Animal[] animals = [
            new Cat("Michael", 4, "Brown"),
            new Dog("Abbey", 4, "Black"),
            new Cat("Salt", 6, "White"),
            new Dog("Cerberus", 3, "Gray"),
            new Dog("Peter", 4, "Yellow"),
            new Dog("Brian", 4, "White"),
            new Cat("Dave The Magical Cheese Wizard", 9, "Gray"),
            new Cat("Uni", 7, "Black"),
            new Platypus("Bill", 4),
            new Platypus("Parry", 5),
            new Bird("Polly", 2)
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