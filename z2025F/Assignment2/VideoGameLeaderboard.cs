namespace CompSci.zClasswork.Assignment2;

public class VideoGameLeaderboard
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

    private static VideoGame[] ReadGamesFromFile(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("Cant read games from missing file!");
        }
        
        int LineCount = GetLineCount(path);
        VideoGame[] games = new VideoGame[LineCount-1];

        using StreamReader reader = new StreamReader(path);
        reader.ReadLine();
        
        for (var i = 0; i < games.Length; i++)
        {
            string line = reader.ReadLine();
            
            string[] columns = line.Split(',');
            
            String Title = columns[0];
            int Sales = int.Parse(columns[1]);
            String Platforms = columns[2];
            string ReleaseDate = columns[3];
            string Developer = columns[4];
            string Publisher = columns[5];

            games[i] = new VideoGame(Title,Sales, Platforms, ReleaseDate, Developer, Publisher);
        }

        return games;
    }

    private static void WriteAnythingToFile(String text, String path)
    {
        using StreamWriter writer = new StreamWriter(path, append:true);
        writer.WriteLine(text);
    }
    private static void WriteGamesToFile(VideoGame game, string path)
    {
        using StreamWriter writer = new StreamWriter(path, append:true);
        string line = string.Join(',', game.Title, game.Sales, game.Platforms, game.ReleaseDate, game.Developer, game.Publisher, $"{game.SalesToTitleLength():F2}" );
        writer.WriteLine(line);
    }
    
    private static void SortSalesToTitleLength(VideoGame[] games) {
        // Compares ratio of the amount of sales to the length of a title (Sales/Title Length)\
        // You said we get to choose how we sort. This may be dumb and impractical, but it's unique.
        // Sorted in Decending order
        
        for (int i = 1; i < games.Length; i++) {
            int j = i;
            VideoGame temp = games[i];

            while (j > 0 && temp.SalesToTitleLength() < games[j - 1].SalesToTitleLength()) {
                games[j] = games[j - 1]; // Takes one from behind and moves backwards
                j--; 
            }
            games[j] = temp;
        }

        Array.Reverse(games); //holy magic batman
    }
    
    private static void Main()
    {
        string path = "Top-Selling-Videogames.csv";
        VideoGame[] games = ReadGamesFromFile(path);
        
        Console.WriteLine($"Top {games.Length} Best-Selling Videogames");
        for (int i = 0; i < games.Length; i++)
        {
            Console.WriteLine(games[i]);
        }

        SortSalesToTitleLength(games);
        
        path = "Top-Selling-Videogames-S2TLR.csv";
        
        Console.WriteLine($"\nTop {games.Length} Best-Selling Videogames by Sales to Title Length Ratio");
        WriteAnythingToFile("Title,Sales,Platform(s),Initial Release Date,Developer(s),Publisher(s), Sales To Title Length Ratio", path);
        
        foreach (VideoGame game in games)
        {
            WriteGamesToFile(game, path);
            Console.WriteLine(game + ", " + $"{game.SalesToTitleLength():F2}");
        }
        
    }
}