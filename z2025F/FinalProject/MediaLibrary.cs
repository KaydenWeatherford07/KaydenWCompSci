namespace CompSci.zClasswork.FinalProject;

public class MediaLibrary
{
    #region Recycled Old Code

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

        private static void WriteMediaToFile(Media media, string path, bool app = true)
        {
            using StreamWriter writer = new StreamWriter(path, append: app);
            
            string[] fields;
            
            if (media is Track) // Track(string title, string creator, string album, int year, int duration, double rating)
            {
                fields = new string[7];
                fields[0] = "Track";
                fields[1] = media.Title;
                fields[2] = media.Creator;
                fields[3] = (media as Track).Album;
                fields[4] = media.Year.ToString();
                fields[5] = media.Duration.ToString();
                double temp = media.NormalizedRating * 5;
                fields[6] = temp.ToString();
                
                writer.WriteLine(string.Join(',', fields));
            }
            else if (media is AudioBook) // AudioBook(string title, string creator, int year, int duration, bool rating)
            {
                fields = new string[6];
                fields[0] = "AudioBook";
                fields[1] = media.Title;
                fields[2] = media.Creator;
                fields[3] = media.Year.ToString();
                fields[4] = media.Duration.ToString();
                bool temp;
                if ((media as AudioBook).NormalizedRating == 0)
                    temp = false;
                else if ((media as AudioBook).NormalizedRating == 1)
                    temp = true;
                else
                {
                    goto quit;
                }
                fields[5] = temp.ToString();
                
                writer.WriteLine(string.Join(',', fields));
            }
            else if (media is Episode) 
                // Episode(string title, string showtitle, string creator, int year, int seasonnumber, int episodenumber, int duration, int rating)
            {
                fields = new string[9];
                fields[0] = "TVEpisode";
                fields[1] = media.Title;
                fields[2] = (media as Episode).ShowTitle;
                fields[3] = media.Creator;
                fields[4] = media.Year.ToString();
                fields[5] = (media as Episode).SeasonNumber.ToString();
                fields[6] = (media as Episode).EpisodeNumber.ToString();
                fields[7] = media.Duration.ToString();
                double temp = media.NormalizedRating * 10;
                fields[8] = temp.ToString();
                
                writer.WriteLine(string.Join(',', fields));
            }
            else
            {
                goto quit;
            }
            
            quit:
            writer.Close();
        }

        private static List<Media> ReadMediaFromFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Cant read from missing file!");
            }

            int LineCount = GetLineCount(path);
            List<Media> media = new List<Media>();

            using StreamReader reader = new StreamReader(path);
            for (int i = 0; i < LineCount; i++)
            {
                string[] fields = reader.ReadLine().Split(',');
                if (fields[0].ToUpper() == "TRACK")
                {
                    try
                    {
                        media.Add(new Track(fields[1], fields[2], fields[3],
                            int.Parse(fields[4]), int.Parse(fields[5]), double.Parse(fields[6])));
                    }
                    catch (Exception e)
                    {
                        // Unable to Read, Skips
                    }
                }
                else if (fields[0].ToUpper() == "AUDIOBOOK")
                {
                    bool skip = false;
                    try
                    {
                        media.Add(new AudioBook(fields[1], fields[2],
                            int.Parse(fields[3]), int.Parse(fields[4]), bool.Parse(fields[5])));
                    }
                    catch (Exception e)
                    {
                        // Unable to Read, Skips
                    }
                }
                else if (fields[0].ToUpper() == "TVEPISODE")
                {

                    // Attempt 4 at figuring out a solution.
                    // Edit: I did it I think qwq
                    try
                    {
                        media.Add(new Episode(
                            fields[1], fields[2], fields[3], int.Parse(fields[4]),
                            int.Parse(fields[5]), int.Parse(fields[6]), int.Parse(fields[7]), int.Parse(fields[8])));
                    }
                    catch (Exception e)
                    {
                        // Unable to Read, Skips
                    }
                }
            }
            
            // Only adds recognized values, will delete errors in the long run.
            // Poor Scalability, but it works for now.
            // Might Optimize Later
            return media;
        }

        private static void PrintMenu(string bottom, string? top = null)
        {
            Console.Clear();
            /*
                ||------------Media Manager 5000!----------||
                [
                                    output
                [
                ||-----------------------------------------||
             */
            // Default Response If No
            if (string.IsNullOrEmpty(bottom))
                bottom = "Type \"Help\" or \"Menu\" for a list of available commands.";
            
            
            Console.WriteLine("||------------Media Manager 5000!----------||\n[");
            
            if (top != null)
            {
                Console.WriteLine(top + "\n");
            }
            Console.WriteLine(bottom);

            Console.WriteLine("[\n||-----------------------------------------||");
        }

    #endregion

    #region Program Functions

        private static string ListCommands()
        {
            return
                "1. List Contents" +
                "\n2. List By Type" +
                "\n3. Search For Media" +
                "\n4. Sort Media" +
                "\n5. Media Management" +

                "\n\n0. Quit";
        }
        
        
        // These can SOOOOOOOOOO be improved, but I just don't have the time to do it in a better way atm.
        // The scalability of this program is awful, but in my current predicament, I don't have the time to go back and optimize.
        // Might come back and improve them later.
        private static void ListTypes(List<Media> media)
                {
                    PrintMenu("Please Type A Number Below,\nOr Type \"Menu\" or \"Exit\" to go back to the Menu.", $"--Which Type Would you Like?--\n" +
                                                   $"1.) Track\n" +
                                                   $"2.) AudioBook\n" +
                                                   $"3.) Episode");
                    
                    while (true)
                    {
                        string? input = Console.ReadLine();
                        if (string.IsNullOrEmpty(input))
                        {
                            continue;
                        }
        
                        if (input.ToUpper() == "MENU" || input.ToUpper() == "EXIT" || input.ToUpper() == "BACK" || input.ToUpper() == "B")
                        {
                            break;
                        }
                        if (int.TryParse(input, out int num))
                        {
                            if (num < 1 || num > 3)
                            {
                                PrintMenu("Please Type A Number Below,\nOr Type \"Menu\" or \"Exit\" to go back to the Menu.\nInvalid Response!", $"--Which Type Would you Like?--\n" +
                                                                                                                                                  $"1.) Track\n" +
                                                                                                                                                  $"2.) AudioBook\n" +
                                                                                                                                                  $"3.) Episode");
                            }
                            else
                            {
                                ListAll(media, num);
                                PrintMenu("Please Type A Number Below,\nOr Type \"Menu\" or \"Exit\" to go back to the Menu.", $"--Which Type Would you Like?--\n" +
                                                                                                                                                  $"1.) Track\n" +
                                                                                                                                                  $"2.) AudioBook\n" +
                                                                                                                                                  $"3.) Episode");
                            }
                        }
                    }
                    
                    
                } // FIRST PAGE

        private static void ListAll(List<Media> media, int? type = 0)
        {
            int j = 0;
            int pages = 0;
            switch (type)
            {
                case 0:
                    if (media.Count % 10 > 0)
                        j = 1;
                    pages = (media.Count/10) + j;
                    break;
                case 1:
                    if (media.OfType<Track>().Count() % 10 > 0)
                        j = 1;
                    pages = (media.OfType<Track>().Count()/10) + j;
                    break;
                case 2:
                    if (media.OfType<AudioBook>().Count() % 10 > 0)
                        j = 1;
                    pages = (media.OfType<Track>().Count()/10) + j;
                    break;
                case 3:
                    if (media.OfType<Episode>().Count() % 10 > 0)
                        j = 1;
                    pages = (media.OfType<Track>().Count()/10) + j;
                    break;
                    
            }
            
            PrintMenu(ListPages(0, media, type), $"--Page [1/{pages}]--\n" +
                                                 $"--Type a Page Number to Go to a Page--\n" +
                                                 $"--Type \"Menu\" or \"Back\" to go back to the Menu.");
            
            while (true)
            {
                string? input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    continue;
                }

                if (input.ToUpper() == "MENU" || input.ToUpper() == "EXIT" || input.ToUpper() == "BACK" || input.ToUpper() == "B")
                {
                    break;
                }
                
                if (int.TryParse(input, out int num))
                {
                    if (num < 1 || num > pages)
                    {
                        PrintMenu(ListPages(0, media, type) + "\n\nInvalid Command!",   $"--Page [1/{pages}]--\n" +
                                                        $"--Type a Page Number to Go to a Page--\n" +
                                                        $"--Type \"Menu\" or \"Back\" to go back to the Menu.");
                    }
                    else
                    {
                        PrintMenu(ListPages((num - 1), media, type),   $"--Page [{num}/{pages}]--\n" +
                                                                       $"--Type a Page Number to Go to a Page--\n" +
                                                                       $"--Type \"Menu\" or \"Back\" to go back to the Menu.");
                    }
                }
            }
        } // SECOND PAGE

        private static string ListPages(int pagenumber, List<Media> media, int? type = 0)
        {
            string page = "";
            
            if (pagenumber < 0)
                throw new ArgumentOutOfRangeException("pagenumber", "Pagenumber is invalid");
            
            List<Media> newMedia = new List<Media>();
            switch (type)
            {
                case 0:
                    newMedia = media;
                    break;
                case 1:
                    foreach ( Media m in media)
                    {
                        if (m is Track)
                            newMedia.Add(m);
                    }
                    break;
                case 2:
                    foreach ( Media m in media)
                    {
                        if (m is AudioBook)
                            newMedia.Add(m);
                    }
                    break;
                case 3:
                    foreach ( Media m in media)
                    {
                        if (m is Episode)
                            newMedia.Add(m);
                    }
                    break;
            }
            
            // TAKES IN PAGE NUMBER AND TYPE
            
            Console.WriteLine($"{pagenumber} || {newMedia.Count}");
            
            if ((pagenumber + 1) * 10 > newMedia.Count)
            {
                for (int i = 0; i < (newMedia.Count % 10); i++)
                {
                    page +=  $"\n({(pagenumber * 10) + i}) " + newMedia[(pagenumber * 10) + i];
                }
            }
            else if (pagenumber * 10 < newMedia.Count)
            {
                for (int i = 0; i < 10; i++)
                {
                    page +=  $"\n({(pagenumber * 10) + i}) " + newMedia[(pagenumber * 10) + i];
                }
            }
            
            return page;
        } // RETURNS TO SECOND PAGE
        
        
        
        private static void SearchMedia(List<Media> media) // FIRST PAGE
        {
            PrintMenu("Please Type A Number Below,\nOr Type \"Menu\" or \"Exit\" to go back to the Menu.", $"--How Would You Like To Search?--\n" +
                                           $"1.) Title\n" +
                                           $"2.) Creator\n" +
                                           $"3.) Year\n");
            
            while (true)
            {
                string? input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    continue;
                }

                if (input.ToUpper() == "MENU" || input.ToUpper() == "EXIT" || input.ToUpper() == "BACK" || input.ToUpper() == "B")
                {
                    break;
                }
                if (int.TryParse(input, out int num))
                {
                    if (num < 1 || num > 3)
                    {
                        PrintMenu("Please Type A Number Below,\nOr Type \"Menu\" or \"Exit\" to go back to the Menu.\nInvalid Response!", $"--How Would You Like To Search?--\n" +
                                                                                                                                          $"1.) Title\n" +
                                                                                                                                          $"2.) Creator\n" +
                                                                                                                                          $"3.) Year\n");
                    }
                    else
                    {
                        PrintMenu("-- Please Input Search Value: --");
                        while (true)
                        {
              
                            string? input2 = Console.ReadLine();
                            if (string.IsNullOrEmpty(input2))
                            {
                                PrintMenu("-- Please Input Search Value: --");
                                continue;
                            }
                            
                            List<Media> newMedia = new List<Media>();
                            if (num == 1)
                            {
                                foreach (Media m in media)
                                {
                                    if (m.Title.ToUpper() == input2.ToUpper())
                                    {
                                        newMedia.Add(m);
                                    }
                                }
                            }
                            else if (num == 2)
                            {
                                foreach (Media m in media)
                                {
                                    if (m.Creator.ToUpper() == input2.ToUpper())
                                    {
                                        newMedia.Add(m);
                                    }
                                }
                            }
                            else if (num == 3)
                            {
                                if (int.TryParse(input2.ToUpper(), out int num2))
                                {
                                    foreach (Media m in media)
                                    {
                                        if (m.Year >= num2)
                                        {
                                            newMedia.Add(m);
                                        }

                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                            ListSearched(newMedia, num);
                            PrintMenu("Please Type A Number Below,\nOr Type \"Menu\" or \"Exit\" to go back to the Menu.", $"--How Would You Like To Search?--\n" +
                                                                                                                           $"1.) Title\n" +
                                                                                                                           $"2.) Creator\n" +
                                                                                                                           $"3.) Year\n");
                            break;
                        }
                        
                    }
                }
            }
        }
        
        private static void ListSearched(List<Media> media, int type = 0) // SECOND PAGE
                 {
                     int j = 0;
                     int pages = 0;
                     if (media.Count() % 10 > 0)
                         j = 1;
                     pages = (media.Count()/10) + j;
                     
                     PrintMenu(SearchedPages(0, media), $"--Page [1/{pages}]--\n" +
                                                          $"--Type a Page Number to Go to a Page--\n" +
                                                          $"--Type \"Menu\" or \"Back\" to go back to the Menu.");
                     while (true)
                     {
                         string? input = Console.ReadLine();
                         if (string.IsNullOrEmpty(input))
                         {
                             continue;
                         }
         
                         if (input.ToUpper() == "MENU" || input.ToUpper() == "EXIT" || input.ToUpper() == "BACK" || input.ToUpper() == "B")
                         {
                             break;
                         }
                         
                         if (int.TryParse(input, out int num))
                         {
                             if (num < 1 || num > pages)
                             {
                                 PrintMenu(SearchedPages(0, media) + "\n\nInvalid Command!",   $"--Page [1/{pages}]--\n" +
                                                                 $"--Type a Page Number to Go to a Page--\n" +
                                                                 $"--Type \"Menu\" or \"Back\" to go back to the Menu.");
                             }
                             else
                             {
                                 PrintMenu(SearchedPages(num, media),   $"--Page [{num}/{pages}]--\n" +
                                                                                $"--Type a Page Number to Go to a Page--\n" +
                                                                                $"--Type \"Menu\" or \"Back\" to go back to the Menu.");
                             }
                         }
                     }
                 }
        
        private static string SearchedPages(int pagenumber, List<Media> media) // RETURNS TO SECOND PAGE
        {
            string page = "";
            
            if ((pagenumber + 1) * 10 > media.Count)
            {
                for (int i = 0; i < (media.Count % 10); i++)
                {
                    page +=  $"\n({(pagenumber * 10) + i}) " + media[(pagenumber * 10) + i];
                }
            }
            else if (pagenumber * 10 < media.Count)
            {
                for (int i = 0; i < 10; i++)
                {
                    page +=  $"\n({(pagenumber * 10) + i}) " + media[(pagenumber * 10) + i];
                }
            }
            
            return page;

        }
        
        
        
        private static void SortedMedia(List<Media> media) // FIRST PAGE
        {
            PrintMenu("Please Type A Number Below,\nOr Type \"Menu\" or \"Exit\" to go back to the Menu.", $"--Which Type Would you Like?--\n" +
                                                                                                           $"1.) Title\n" +
                                                                                                           $"2.) Year\n" +
                                                                                                           $"3.) Rating\n"+
                                                                                                           $"4.) Type");
            
            while (true)
            {
                string? input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    continue;
                }

                if (input.ToUpper() == "MENU" || input.ToUpper() == "EXIT" || input.ToUpper() == "BACK" || input.ToUpper() == "B")
                {
                    break;
                }
                if (int.TryParse(input, out int num))
                {
                    if (num < 1 || num > 4)
                    {
                        PrintMenu("Please Type A Number Below,\nOr Type \"Menu\" or \"Exit\" to go back to the Menu.\nInvalid Response!", $"--Which Type Would you Like?--\n" +
                                                                                                                                          $"1.) Title\n" +
                                                                                                                                          $"2.) Year\n" +
                                                                                                                                          $"3.) Rating\n"+
                                                                                                                                          $"4.) Type");
                    }
                    else
                    {
                        ListSorted(media, num);
                        PrintMenu("Please Type A Number Below,\nOr Type \"Menu\" or \"Exit\" to go back to the Menu.", $"--Which Type Would you Like?--\n" +
                                                                                                                       $"1.) Title\n" +
                                                                                                                       $"2.) Year\n" +
                                                                                                                       $"3.) Rating\n" +
                                                                                                                       $"4.) Type");
                    }
                }
            }
            
            
        }
        
        private static void ListSorted(List<Media> media, int type = 0) // SECOND PAGE
                 {
                     int j = 0;
                     int pages = 0;
                     if (media.Count() % 10 > 0)
                         j = 1;
                     pages = (media.Count()/10) + j;

                     switch (type)
                     {
                         case 0:
                             break;
                         case 1:
                             media.Sort((x,y) => x.Title.CompareTo(y.Title));
                             break;
                         case 2:
                             media.Sort((x,y) => x.Year.CompareTo(y.Year));
                             break;
                         case 3:
                              media.Sort((x, y) => x.NormalizedRating.CompareTo(y.NormalizedRating));
                             break;
                         case 4:
                             media.Sort((x, y) =>
                             {
                                 int typeCompare = x.GetType().Name.CompareTo(y.GetType().Name);
                                 if (typeCompare != 0)
                                     return typeCompare;
                                 
                                 if (x.Title.CompareTo(y.Title) != 0)
                                     return x.Title.CompareTo(y.Title);
                                 
                                 if (x.Creator.CompareTo(y.Creator) != 0)
                                     return x.Creator.CompareTo(y.Creator);
                                 
                                 return x.Year.CompareTo(y.Year);
                             });
                             break;
                     }
                     
                     PrintMenu(SortedPages(0, media), $"--Page [1/{pages}]--\n" +
                                                          $"--Type a Page Number to Go to a Page--\n" +
                                                          $"--Type \"Menu\" or \"Back\" to go back to the Menu--\n" +
                                                          $"--Type \"\" or \"\" to Change Order--");
                     while (true)
                     {
                         string? input = Console.ReadLine();
                         if (string.IsNullOrEmpty(input))
                         {
                             continue;
                         }
         
                         if (input.ToUpper() == "MENU" || input.ToUpper() == "EXIT" || input.ToUpper() == "BACK" || input.ToUpper() == "B")
                         {
                             break;
                         }

                         if (input.ToUpper() == "A" || input.ToUpper() == "ASCENDING")
                         {
                             switch (type)
                             {
                                 case 0:
                                     break;
                                 case 1:
                                     media.Sort((x,y) => x.Title.CompareTo(y.Title));
                                     break;
                                 case 2:
                                     media.Sort((x,y) => x.Year.CompareTo(y.Year));
                                     break;
                                 case 3:
                                     media.Sort((x, y) => x.NormalizedRating.CompareTo(y.NormalizedRating));
                                     break;
                                 case 4:
                                     media.Sort((x, y) =>
                                     {
                                         int typeCompare = x.GetType().Name.CompareTo(y.GetType().Name);
                                         if (typeCompare != 0)
                                             return typeCompare;
                                 
                                         if (x.Title.CompareTo(y.Title) != 0)
                                             return x.Title.CompareTo(y.Title);
                                 
                                         if (x.Creator.CompareTo(y.Creator) != 0)
                                             return x.Creator.CompareTo(y.Creator);
                                 
                                         return x.Year.CompareTo(y.Year);
                                     });
                                     break;
                             }
                             PrintMenu(SortedPages(0, media),   $"--Page [1/{pages}]--\n" +
                                                                $"--Type a Page Number to Go to a Page--\n" +
                                                                $"--Type \"Menu\" or \"Back\" to go back to the Menu--\n" +
                                                                $"--Type \"\" or \"\" to Change Order--");
                         }

                         if (input.ToUpper() == "D" || input.ToUpper() == "DESCENDING")
                         {
                             switch (type)
                             {
                                 case 0:
                                     break;
                                 case 1:
                                     media.Sort((x,y) => x.Title.CompareTo(y.Title));
                                     break;
                                 case 2:
                                     media.Sort((x,y) => x.Year.CompareTo(y.Year));
                                     break;
                                 case 3:
                                     media.Sort((x, y) => x.NormalizedRating.CompareTo(y.NormalizedRating));
                                     break;
                                 case 4:
                                     media.Sort((x, y) =>
                                     {
                                         int typeCompare = x.GetType().Name.CompareTo(y.GetType().Name);
                                         if (typeCompare != 0)
                                             return typeCompare;
                                 
                                         if (x.Title.CompareTo(y.Title) != 0)
                                             return x.Title.CompareTo(y.Title);
                                 
                                         if (x.Creator.CompareTo(y.Creator) != 0)
                                             return x.Creator.CompareTo(y.Creator);
                                 
                                         return x.Year.CompareTo(y.Year);
                                     });
                                     break;
                             }

                             media.Reverse();
                             PrintMenu(SortedPages(0, media),   $"--Page [1/{pages}]--\n" +
                                                                $"--Type a Page Number to Go to a Page--\n" +
                                                                $"--Type \"Menu\" or \"Back\" to go back to the Menu--\n" +
                                                                $"--Type \"\" or \"\" to Change Order--");
                         }
                         
                         if (int.TryParse(input, out int num))
                         {
                             if (num < 1 || num > pages)
                             {
                                 PrintMenu(SortedPages(0, media) + "\n\nInvalid Command!",   $"--Page [1/{pages}]--\n" +
                                                                                             $"--Type a Page Number to Go to a Page--\n" +
                                                                                             $"--Type \"Menu\" or \"Back\" to go back to the Menu--\n" +
                                                                                             $"--Type \"\" or \"\" to Change Order--");
                             }
                             else
                             {
                                 PrintMenu(SortedPages((num-1), media),   $"--Page [{num}/{pages}]--\n" +
                                                                          $"--Type a Page Number to Go to a Page--\n" +
                                                                          $"--Type \"Menu\" or \"Back\" to go back to the Menu--\n" +
                                                                          $"--Type \"\" or \"\" to Change Order--");
                             }
                         }
                     }
                 }
        
        private static string SortedPages(int pagenumber, List<Media> media) // RETURNS TO SECOND PAGE
        {
            string page = "";
            
            if ((pagenumber + 1) * 10 > media.Count)
            {
                for (int i = 0; i < (media.Count % 10); i++)
                {
                    page +=  $"\n({(pagenumber * 10) + i}) " + media[(pagenumber * 10) + i];
                }
            }
            else if (pagenumber * 10 < media.Count)
            {
                for (int i = 0; i < 10; i++)
                {
                    page +=  $"\n({(pagenumber * 10) + i}) " + media[(pagenumber * 10) + i];
                }
            }
            
            return page;

        }
        
        
        
        private static List<Media> ManageMedia(List<Media> media) // FIRST PAGE
        {
            List<Media> result = new List<Media>();
            PrintMenu("Please Type A Number Below,\nOr Type \"Menu\" or \"Exit\" to go back to the Menu.", $"--Which Type Would you Like?--\n" +
                                                                                                           $"1.) Add To Media\n" + 
                                                                                                           $"2.) Delete Media\n");
            while (true)
            {
                string? input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    continue;
                }

                if (input.ToUpper() == "MENU" || input.ToUpper() == "EXIT" || input.ToUpper() == "BACK" || input.ToUpper() == "B")
                {
                    break;
                }
                if (int.TryParse(input, out int num))
                {
                    if (num < 1 || num > 2)
                    {
                        PrintMenu("Please Type A Number Below,\nOr Type \"Menu\" or \"Exit\" to go back to the Menu.\nInvalid Response!", $"--Which Type Would you Like?--\n" +
                                                                                                                                          $"1.) Add To Media\n" +
                                                                                                                                          $"2.) Delete Media\n");
                    }
                    else
                    {
                        result = ListManagement(media, num);
                        PrintMenu("Please Type A Number Below,\nOr Type \"Menu\" or \"Exit\" to go back to the Menu.", $"--Which Type Would you Like?--\n" +
                                                                                                                       $"1.) Add To Media\n" +
                                                                                                                       $"2.) Delete Media\n");
                    }
                }
            }
            
            return result;
        }
        
        private static List<Media> ListManagement(List<Media> media, int type = 0) // SECOND PAGE
         {
             
             switch (type)
             {
                 case 0:
                     break;
                 case 1:
                     PrintMenu("Please Type A Number Below,\nTo Cancel, Type \"Menu\" to go back to the Menu.", $"--Which Type Would you Like to Add?--\n" +
                                                                                                                    $"1.) Track\n" +
                                                                                                                    $"2.) Audio Book\n" +
                                                                                                                    $"3.) TV Episode\n");
                     break;
                 case 2:
                     PrintMenu("Please Type An Index Number Below to Remove Media.\n(To See Index Numbers, Go to the Main Menu and Select 'List Contents')\nType \"Menu\" or \"Exit\" to go back to the Menu.");
                     break;
             }
             List<Media> result = media;
             TryAgain:
             while (true)
             {
                 string? input = Console.ReadLine();
                 if (string.IsNullOrEmpty(input))
                 {
                     continue;
                 }
                 if (type == 0)
                 {
                     break;
                 }
                 if (type == 1) // ADD to Media
                 {
                     if (input.ToUpper() == "MENU")
                     {
                         break;
                     }

                     if (int.TryParse(input, out int num))
                     {
                         if (num < 1 || num > 3)
                         {
                             goto TryAgain;
                         }
                         string[] fields = null;
                         switch (num)
                         {
                             case 1:
                                 fields = new string[6];
                                 // Track(string title, string creator, string album, int year, int duration, double rating)
                                 PrintMenu("Please Enter A Title Name:");
                                 fields[0] = Console.ReadLine();
                                 PrintMenu("Please Enter A Creator Name:");
                                 fields[1] = Console.ReadLine();
                                 PrintMenu("Please Enter An Album Name:");
                                 fields[2] = Console.ReadLine();
                                 PrintMenu("Please Enter A Year:");
                                 fields[3] = Console.ReadLine();
                                 PrintMenu("Please Enter A Duration (# of Minutes):");
                                 fields[4] = Console.ReadLine();
                                 PrintMenu("Please Enter A Rating (Any Decimal #, 0-5):");
                                 fields[5] = Console.ReadLine();
                                 try
                                 {
                                     Track newTrack = new Track(fields[0], fields[1], fields[2], int.Parse(fields[3]), int.Parse(fields[4]), double.Parse(fields[5]));
                                     
                                     if (int.Parse(fields[3]) < 0 || int.Parse(fields[3]) > 2025 || int.Parse(fields[4]) < 1 || double.Parse(fields[5]) < 0 || double.Parse(fields[5]) > 5 )
                                         throw new ArgumentOutOfRangeException();
                                     
                                     
                                     PrintMenu(newTrack.ToString(), "--Does This Look Right?--\n(Type \"Y\" or \"N\")");
                                     newInput:
                                     input = Console.ReadLine();
                                     if (string.IsNullOrEmpty(input))
                                         goto newInput;
                                     if (input.ToUpper() == "Y" ||  input.ToUpper() == "YES")
                                     {
                                         result.Add(newTrack);
                                         PrintMenu("Please Type A Number Below,\nTo Cancel, Type \"Menu\" to go back to the Menu.\nTrack Successfully Added!", $"--Which Type Would you Like to Add?--\n" +
                                                                                                                                                               $"1.) Track\n" +
                                                                                                                                                               $"2.) Audio Book\n" +
                                                                                                                                                               $"3.) TV Episode\n");
                                         goto TryAgain;
                                     }
                                     else if (input.ToUpper() == "N" || input.ToUpper() == "NO")
                                     {
                                         PrintMenu("Please Type A Number Below,\nTo Cancel, Type \"Menu\" to go back to the Menu.\nTrack Creation Cancelled!", $"--Which Type Would you Like to Add?--\n" +
                                                                                                                                                               $"1.) Track\n" +
                                                                                                                                                               $"2.) Audio Book\n" +
                                                                                                                                                               $"3.) TV Episode\n");
                                         goto TryAgain;
                                     }
                                     else
                                     {
                                         goto newInput;
                                     }
                                 }
                                 catch (Exception e)
                                 {
                                     PrintMenu("Please Type A Number Below,\nTo Cancel, Type \"Menu\" to go back to the Menu.\nError With Creating New Track!", $"--Which Type Would you Like to Add?--\n" +
                                                                                                                                $"1.) Track\n" +
                                                                                                                                $"2.) Audio Book\n" +
                                                                                                                                $"3.) TV Episode\n");
                                     goto TryAgain;
                                 }
                             case 2:
                                 fields = new string[5];
                                 // AudioBook(string title, string creator, int year, int duration, bool rating)
                                 PrintMenu("Please Enter A Title Name:");
                                 fields[0] = Console.ReadLine();
                                 PrintMenu("Please Enter A Creator Name:");
                                 fields[1] = Console.ReadLine();
                                 PrintMenu("Please Enter A Year:");
                                 fields[2] = Console.ReadLine();
                                 PrintMenu("Please Enter A Duration (# of Minutes):");
                                 fields[3] = Console.ReadLine();
                                 PrintMenu("Please Enter A Rating (Type: \"Like\" or \"Dislike\")");
                                 fields[4] = Console.ReadLine();
                                 try
                                 {

                                     if (int.Parse(fields[2]) < 0 || int.Parse(fields[2]) > 2025 || int.Parse(fields[3]) < 0)
                                     {
                                         throw new ArgumentOutOfRangeException();
                                     }
                                         
                                     bool like;
                                     if (fields[4].ToUpper() == "LIKE" || fields[4].ToUpper() == "LIKED" || fields[4].ToUpper() == "L")
                                         like = true;
                                     else if (fields[4].ToUpper() == "DISLIKE" || fields[4].ToUpper() == "DISLIKED" || fields[4].ToUpper() == "D")
                                         like = false;
                                     else
                                     {
                                         throw new Exception();
                                     }
                                     
                                     AudioBook newAB = new AudioBook(fields[0], fields[1], int.Parse(fields[2]), int.Parse(fields[3]), like);
                                     
                                     PrintMenu(newAB.ToString(), "--Does This Look Right?--\n(Type \"Y\" or \"N\")");
                                     newInput:
                                     input = Console.ReadLine();
                                     if (string.IsNullOrEmpty(input))
                                         goto newInput;
                                     if (input.ToUpper() == "Y" ||  input.ToUpper() == "YES")
                                     {
                                         result.Add(newAB);
                                         PrintMenu("Please Type A Number Below,\nTo Cancel, Type \"Menu\" to go back to the Menu.\nAudio Book Successfully Added!", $"--Which Type Would you Like to Add?--\n" +
                                                                                                                                                                         $"1.) Track\n" +
                                                                                                                                                                         $"2.) Audio Book\n" +
                                                                                                                                                                         $"3.) TV Episode\n");
                                         goto TryAgain;
                                         
                                     }
                                     else if (input.ToUpper() == "N" || input.ToUpper() == "NO")
                                     {
                                         PrintMenu("Please Type A Number Below,\nTo Cancel, Type \"Menu\" to go back to the Menu.\nAudio Book Creation Cancelled!", $"--Which Type Would you Like to Add?--\n" +
                                                                                                                                                               $"1.) Track\n" +
                                                                                                                                                               $"2.) Audio Book\n" +
                                                                                                                                                               $"3.) TV Episode\n");
                                         goto TryAgain;
                                     }
                                     else
                                     {
                                         goto newInput;
                                     }
                                 }
                                 catch (Exception e)
                                 {
                                     PrintMenu("Please Type A Number Below,\nTo Cancel, Type \"Menu\" to go back to the Menu.\nError With Creating New Audio Book!", $"--Which Type Would you Like to Add?--\n" +
                                                                                                                                $"1.) Track\n" +
                                                                                                                                $"2.) Audio Book\n" +
                                                                                                                                $"3.) TV Episode\n");
                                     goto TryAgain;
                                 }
                                 break;
                             case 3:
                                 fields = new string[8];
                                 // Episode(string title, string showtitle, string creator, int year, int seasonnumber, int episodenumber, int duration, int rating)
                                 PrintMenu("Please Enter A Title Name:");
                                 fields[0] = Console.ReadLine();
                                 PrintMenu("Please Enter The Show's Title Name:");
                                 fields[1] = Console.ReadLine();
                                 PrintMenu("Please Enter The Creator's Name:");
                                 fields[2] = Console.ReadLine();
                                 PrintMenu("Please Enter A Year;");
                                 fields[3] = Console.ReadLine();
                                 PrintMenu("Please Enter The Season Number:");
                                 fields[4] = Console.ReadLine();
                                 PrintMenu("Please Enter The Episode Number:");
                                 fields[5] = Console.ReadLine();
                                 PrintMenu("Please Enter A Duration (# of Minutes):");
                                 fields[6] = Console.ReadLine();
                                 PrintMenu("Please Enter A Rating (Give a # out of 10):");
                                 fields[7] = Console.ReadLine();
                                 try
                                 {
                                     if (int.Parse(fields[3]) < 0 || int.Parse(fields[3]) > 2025 || int.Parse(fields[4]) < 0 || int.Parse(fields[5]) < 0 ||  int.Parse(fields[6]) < 0 ||
                                         int.Parse(fields[7]) < 0 || int.Parse(fields[7]) > 10 )
                                     {
                                         throw new Exception();
                                     }
                                     
                                     Episode newEpisode = new Episode(fields[0], fields[1], fields[2], int.Parse(fields[3]),int.Parse(fields[4]), int.Parse(fields[5]), int.Parse(fields[6]), int.Parse(fields[7]));
                                     
                                     PrintMenu(newEpisode.ToString(), "--Does This Look Right?--\n(Type \"Y\" or \"N\")");
                                     newInput:
                                     input = Console.ReadLine();
                                     if (string.IsNullOrEmpty(input))
                                         goto newInput;
                                     if (input.ToUpper() == "Y" ||  input.ToUpper() == "YES")
                                     {
                                         result.Add(newEpisode);
                                         PrintMenu("Please Type A Number Below,\nTo Cancel, Type \"Menu\" to go back to the Menu.\nTV Episode Successfully Added!", $"--Which Type Would you Like to Add?--\n" +
                                                                                                                                                                         $"1.) Track\n" +
                                                                                                                                                                         $"2.) Audio Book\n" +
                                                                                                                                                                         $"3.) TV Episode\n");
                                         goto TryAgain;
                                         
                                     }
                                     else if (input.ToUpper() == "N" || input.ToUpper() == "NO")
                                     {
                                         PrintMenu("Please Type A Number Below,\nTo Cancel, Type \"Menu\" to go back to the Menu.\nTV Episode Creation Cancelled!", $"--Which Type Would you Like to Add?--\n" +
                                                                                                                                                               $"1.) Track\n" +
                                                                                                                                                               $"2.) Audio Book\n" +
                                                                                                                                                               $"3.) TV Episode\n");
                                         goto TryAgain;
                                     }
                                     else
                                     {
                                         goto newInput;
                                     }
                                 }
                                 catch (Exception e)
                                 {
                                     PrintMenu("Please Type A Number Below,\nTo Cancel, Type \"Menu\" to go back to the Menu.\nError With Creating New TV Episode!", $"--Which Type Would you Like to Add?--\n" +
                                                                                                                                $"1.) Track\n" +
                                                                                                                                $"2.) Audio Book\n" +
                                                                                                                                $"3.) TV Episode\n");
                                     goto TryAgain;
                                 }
                                 break;
                         }
                     }
                     
                 }
                 
                 else if (type == 2) // Remove media
                 { 
                     if (input.ToUpper() == "MENU" || input.ToUpper() == "EXIT" || input.ToUpper() == "BACK" || input.ToUpper() == "B")
                     {
                        break;
                     }
                     if (int.TryParse(input, out int num))
                     {
                         try
                         {
                            Media selectedMedia = result[num]; 
                            PrintMenu(result[num].ToString(),"--Is The Selected Media to be Removed Correct?--\n(Type \"Y\" or \"N\")");
                            newInput:
                            input = Console.ReadLine();
                            if (string.IsNullOrEmpty(input))
                                goto newInput;
                            if (input.ToUpper() == "Y" ||  input.ToUpper() == "YES")
                            {
                                if (result.Remove(selectedMedia))
                                {
                                    string temp;
                                    if (selectedMedia is Track)
                                    {
                                        temp = "Track";
                                    }
                                    else if (selectedMedia is AudioBook)
                                    {
                                        temp = "Audio Book";
                                    }
                                    else if (selectedMedia is Episode)
                                    {
                                        temp = "TV Episode";
                                    }
                                    PrintMenu($"Media:\n{selectedMedia}\nHas Been Deleted!", "Please Type An Index Number Below to Remove Media." +
                                                                         "\n(To See Index Numbers, Go to the Main Menu and Select 'List Contents')" +
                                                                         "\nType \"Menu\" or \"Exit\" to go back to the Menu.");
                                    goto TryAgain;
                                }
                                else
                                {
                                    PrintMenu("Media Selection Failed! Could Not Remove - Error!", "Please Type An Index Number Below to Remove Media." +
                                                                         "\n(To See Index Numbers, Go to the Main Menu and Select 'List Contents')" +
                                                                         "\nType \"Menu\" or \"Exit\" to go back to the Menu.");
                                    goto TryAgain;
                                }
                                
                            }
                            if (input.ToUpper() == "N" || input.ToUpper() == "NO")
                            {
                                PrintMenu("Media Selection Cancelled!", "Please Type An Index Number Below to Remove Media." +
                                                                                               "\n(To See Index Numbers, Go to the Main Menu and Select 'List Contents')" +
                                                                                               "\nType \"Menu\" or \"Exit\" to go back to the Menu.");
                                goto TryAgain;
                            }
                            else
                            {
                                goto newInput;
                            }
                         }
                         catch (Exception e)
                         {
                             PrintMenu("Media Selection Failed! Unknown Error!", "Please Type An Index Number Below to Remove Media." +
                                                                  "\n(To See Index Numbers, Go to the Main Menu and Select 'List Contents')" +
                                                                  "\nType \"Menu\" or \"Exit\" to go back to the Menu.");
                             goto TryAgain;
                         }
                     }
                 }
                 
                 
                 
             }
             
             return result;
        }



        private static bool Update(List<Media> media, string path)
        {
            string task = "";
            PrintMenu(task, "Updating Library - Do Not Shut Down or Exit!");
            
            task += "\nSorting Library by Type...";
            PrintMenu(task, "Updating Library - Do Not Shut Down or Exit!");
            media.Sort((x, y) =>
            {
                int typeCompare = x.GetType().Name.CompareTo(y.GetType().Name);
                if (typeCompare != 0)
                    return typeCompare;
                                 
                if (x.Title.CompareTo(y.Title) != 0)
                    return x.Title.CompareTo(y.Title);
                                 
                if (x.Creator.CompareTo(y.Creator) != 0)
                    return x.Creator.CompareTo(y.Creator);
                                 
                return x.Year.CompareTo(y.Year);
            });
            
            task += "\nAttempting overwrite...";
            PrintMenu(task, "Updating Library - Do Not Shut Down or Exit!");
            WriteMediaToFile(media[0], path, false);
            for (int i = 1; i < media.Count; i++)
            {
                WriteMediaToFile(media[i], path);
            }
            
            List<Media> CheckedMedia = ReadMediaFromFile(path);
            if (media.Count != CheckedMedia.Count)
            {
                task += $"\nWARNING {media.Count - CheckedMedia.Count} NOT FOUND IN NEW FILE...\nCancelled Shutdown!\nType \"Menu\" to Return to Menu.";
                PrintMenu(task, "Updating Library - Do Not Shut Down or Exit!");
                return false;
            }
            
            task += "\nMedia Successfully Saved.";
            PrintMenu(task, "Updating Library - Do Not Shut Down or Exit!");
            
            task += "\nExiting...";
            PrintMenu(task, "Updating Library - Do Not Shut Down or Exit!");
            
            return true;
        }
    
    #endregion

    
    public static void Main()
    {
        // Initializing
        string Path = "Collection1.csv";
        List<Media> media = ReadMediaFromFile(Path);

        Restart:
        PrintMenu(ListCommands(), "-- MENU: --");
        
        bool running = true;
        while (running)
        {
            Start:
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {

                PrintMenu(ListCommands(), "Please Type A Number To Select Command\n\n-- MENU: --");
            }
            else if (int.TryParse(input, out int n))
            {
                if (n < 0 || n > 9)
                {
                    PrintMenu(ListCommands(), "Please Type A Number To Select Command\n\n-- MENU: --");
                    continue;
                }

                switch (n)
                {
                    case 0:
                        goto TheEnd;
                    case 1:
                        ListAll(media);
                        PrintMenu(ListCommands(),  "-- MENU: --");
                        break;
                    case 2:
                        ListTypes(media);
                        PrintMenu(ListCommands(), "-- MENU: --");
                        break;
                    case 3:
                        SearchMedia(media);
                        PrintMenu(ListCommands(), "-- MENU: --");
                        break;
                    case 4:
                        SortedMedia(media);
                        PrintMenu(ListCommands(), "-- MENU: --");
                        break;
                    case 5:
                        media = ManageMedia(media);
                        PrintMenu(ListCommands(), "-- MENU: --");
                        break;
                    case 9:
                        break;
                }
            }
            
        }
        
        TheEnd:
        if (!Update(media, Path))
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    continue;
                }
                if (input.ToUpper() == "MENU")
                {
                    goto Restart;
                }
            }
        }
    }
}