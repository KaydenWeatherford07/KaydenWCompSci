public class FileIOLab
{
    private static int GetLineCount(string path)
    {
                    
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("File does not exist!");    
        }

        int count = 0;
        using StreamReader reader = new StreamReader(path);

        while (!reader.EndOfStream)
        {
            reader.ReadLine();
            count++;
        }
                    
        return count;
    }

    private static Movie[] ReadMoviesFromFile(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("Cant read albums from missing file!");
        }
                
        int LineCount = GetLineCount(path);
        Movie[] movies = new Movie[LineCount-1];
        
        using StreamReader reader = new StreamReader(path);
        reader.ReadLine();
                
        for (var i = 0; i < movies.Length; i++)
        {
            string line = reader.ReadLine();
                    
            string[] columns = line.Split(',');

            string title = columns[0];
            Name director = new Name(columns[2], columns[1]);
            int year = int.Parse(columns[3]);
            double rating = double.Parse(columns[4]);

            movies[i] = new Movie(title, year, director, rating);
        }

        return movies;
    }

    private static Movie[] SortRating(Movie[] movies, bool Ascending)
    {
        int N = movies.Length;
        Movie[] sMovies = movies;

        for (int i = 0; i < N-1; i++)
        {
            int min_index = i;
            for (int j = i + 1; j < sMovies.Length; j++)
            {
                if (sMovies[j].Rating < sMovies[min_index].Rating)
                {
                    min_index = j;
                }
            }
            if (min_index != i)
            {
                Movie temp = sMovies[i];
                sMovies[i] = sMovies[min_index];
                sMovies[min_index] = temp;
            }
        }
        
        
        if (Ascending) return sMovies;
        else
        {
            // I dont wanna hear about memory management qwq
            Movie[] decendingMovies = new Movie[N];
            for (int i = 0, j = decendingMovies.Length-1; i < decendingMovies.Length; i++, j--)
            {
                decendingMovies[i] = sMovies[j];
            }
            return decendingMovies;
        }
    }
    
    private static void WriteMoviesToFile(Movie[] movies, string path)
    {
        using StreamWriter writer = new StreamWriter(path, append:true);
        if (!File.Exists(path))
        {
            Console.WriteLine("File does not exist, Creating new file...");
        }
        writer.WriteLine("Title,Director Last Name,Director First Name,Year,Rating");
        
        foreach (Movie movie in movies)
        {
            string line = string.Join(',', movie.Title, movie.Director.last, movie.Director.first, movie.Year, movie.Rating);
            writer.WriteLine(line);
        }
    }
            
    
    private static void Main()
    {
        string path = "movies-007.csv";
        
        Movie[] movies = ReadMoviesFromFile(path);
        int lineCount = GetLineCount(path);

        Movie[] movies2 = SortRating(movies, false);
        
        for (int i = 0; i < movies.Length; i++)
        {
            Console.WriteLine(movies[i]);
        }
        Console.WriteLine();
        
        for (int i = 0; i < movies.Length; i++)
        {
            Console.WriteLine(movies2[i]);
        }
        Console.WriteLine();
        
        WriteMoviesToFile(movies2, "movies-007-SortedByRating.csv");
        
    }
}