namespace CompSci.zClasswork.FileIOPart2
{
    public class AlbumStuff {
    
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

            private static Album[] ReadAlbumsFromFile(string path)
            {
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException("Cant read albums from missing file!");
                }
                
                int LineCount = GetLineCount(path);
                Album[] albums = new Album[LineCount-1];

                using StreamReader reader = new StreamReader(path);
                reader.ReadLine();
                
                for (var i = 0; i < albums.Length; i++)
                {
                    string line = reader.ReadLine();
                    
                    string[] columns = line.Split(',');

                    int rank = int.Parse(columns[0]);
                    int year = int.Parse(columns[1]);
                    string title = columns[2];
                    string artist = columns[3];
                    string genre = columns[4];

                    albums[i] = new Album(title, artist, rank, year, genre);
                }

                return albums;
            }

            private static void WriteAlbumToFile(Album album, string path)
            {
                using StreamWriter writer = new StreamWriter(path, append:true);
                string line = string.Join(',', album.Rank, album.Year, album.Title, album.Artist, album.Genre);
                writer.WriteLine(line);
            }
            
            private static void Main()
            {
                string path = "Rolling-Stone-Top-500-Albums.csv";

                Album a = new Album("Animals", "Pink Floyd", 501, 1977, "Rock");
                WriteAlbumToFile(a, path);
                
                Album[] albums = ReadAlbumsFromFile(path);
                Console.WriteLine($"Top {albums.Length} Albums");

                for (int i = 0; i < albums.Length; i++)
                {
                    Console.WriteLine(albums[i]);
                }
                
            }
    }
}
