
namespace KaydenWCompSci
{
    public class MovieThing
    {
        private static void Main()
        {
            
            Movie[] movies = 
                [new Movie("2001: A Space Odyssey", "Stanley Kubrick", 1968), 
                 new Movie("Interstellar", "Christopher Nolan", 2014), 
                 new Movie("Blade Runner","Ridley Scott",1982)];
            foreach (Movie movie in movies) 
                Console.WriteLine(movie);

            Theater[] theaters =
            [
                new Theater(30),
                new Theater(50),
                new Theater(60),
                new Theater(90),
                new Theater(100)
            ];
            
            
            foreach (Theater theater in theaters)
            {
                // go ahead... go ahead and pick a random movie ig
                Random random = new Random();
                theater.CurrentlyShowing = movies[random.Next(0,movies.Length)];
            }
            
            theaters[0].Price = 9.99;
            theaters[1].Price = 14.99;
            theaters[2].Price = 4.99;
            theaters[3].Price = 19.99;
            theaters[4].Price = 14.99;

            foreach (Theater theater in theaters)
            {
                Console.WriteLine(theater);
            }
        }
    }
}