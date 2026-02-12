using System.Collections;

namespace CompSci451
{
    static class Extensions
    {
        static void Main()
        {
            IEnumerable<int> nums = [1, 2, 3, 4];
            IEnumerator enumerator = nums.GetEnumerator();


            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            nums.PrintAll();
            
            Console.WriteLine("Hello World".NumberOfVowels() + "\n");
            
            nums.ApplyToAll(Console.WriteLine);
        }

        static void PrintAll<T>(this IEnumerable<T> enumerable)
        {
            foreach (T value in enumerable)
            {
                Console.WriteLine(value);
            }
        }

        public static int NumberOfVowels(this string str)
        {
            int vowels = 0;
            foreach (char c in str)
            {
                if (c is 'A' or 'E' or 'I' or 'O' or 'U')
                {
                    vowels++;
                }
            }
            return vowels;
        }

        public static void ApplyToAll<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (T value in enumerable)
            {
                action.Invoke(value);
            }
        }
    }
}