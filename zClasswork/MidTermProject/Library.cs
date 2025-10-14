namespace Library;

public class Library
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
    
    private static void WriteBookToFile(Book book, string path)
    {
        using StreamWriter writer = new StreamWriter(path, append:true);
        writer.WriteLine(book.FileWriteFormat());
    }
    
    private static Book[] ReadBooksFromFile(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("Cant read from missing file!");
        }
                
        int LineCount = GetLineCount(path);
        Book[] books = new Book[LineCount-1];
        
        using StreamReader reader = new StreamReader(path);
        reader.ReadLine();
                
        for (var i = 0; i < books.Length; i++)
        {
            string line = reader.ReadLine();
            string[] columns = line.Split(',');
            bool isCheckedOut;
            
            if (columns[5] == "Yes")
                isCheckedOut = true;
            else if (columns[5] == "No")
                isCheckedOut = false;
            else
            {
                isCheckedOut = false;
            }
            
            string title = columns[0];
            string author = columns[1];
            string genre = columns[2];
            int pageCount = int.Parse(columns[3]);
            int year = int.Parse(columns[4]);
            books[i] = new Book(title, author, genre, pageCount, year, isCheckedOut);
        }

        return books;
    }

    private static void PrintMenu(string output, string optional = null)
    {
        /*
            ||----------Library Manager 5000!----------||
            >>
                        output
            <<
            ||-----------------------------------------||
         */
        if (output == null)
            output = "";
        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
        Console.WriteLine("||----------Library Manager 5000!----------||");
        Console.WriteLine(">>");
        if (optional != null)
        {
            Console.WriteLine(optional + "\n");
        }
        Console.WriteLine(output);
        Console.WriteLine("\n<<");
        Console.WriteLine("||-----------------------------------------||");
    }
    
    private static void ListBooks(Book[] books, bool OnlyNonCheckedOut = false, string Author = null, int Year = -1, string Title = null)
    {
        string IHateMemoryAllocation = "[Index] \t\tBook & Description\n";
        int OutputLength = IHateMemoryAllocation.Length;
        
        for (int i = 0; i < books.Length; i++)
        {
            if (OnlyNonCheckedOut)
            {
                if (!books[i].CheckedOut)
                {
                    IHateMemoryAllocation += $"[{i}] " + books[i] + "\n";
                }
            }
            else if (Author != null)
            {
                if (books[i].Author.ToUpper().Contains(Author.ToUpper()))
                {
                    IHateMemoryAllocation += $"[{i}] " + books[i] + "\n";
                }
            }
            else if (Year >= 0)
            {
                if (books[i].Year >= Year)
                {
                    IHateMemoryAllocation += $"[{i}] " + books[i] + "\n";
                }
            }
            else if (Title != null)
            {
                if (books[i].Title.ToUpper().Contains(Title.ToUpper()))
                {
                    IHateMemoryAllocation += $"[{i}] " + books[i] + "\n";
                }
            }
            else
            {
                IHateMemoryAllocation += $"[{i}] " + books[i] + "\n";
            }
        }
        if (IHateMemoryAllocation.Length > OutputLength)
        {
             PrintMenu(IHateMemoryAllocation);
        }
        else
        {
            PrintMenu("No Results Found...");
        }
    }
    
    public static void Main()
    {
        string path = "TheBooks.csv";
        
        Book[] books = ReadBooksFromFile(path);
        int lineCount = GetLineCount(path);
        
        PrintMenu("Welcome to Library Manager 5000!\n" +
                  "For a list of commands, type Help.");
        bool running = true;
        while (running)
        {
            string? input = Console.ReadLine();
            if (input == null)
            {
                PrintMenu("No command provided. For a list of commands, type Help.");
            }
            else
            {
                input = input.ToUpper();
            }

            if (input == "HELP")
            {
                PrintMenu(
                    "ListBooks - Print out all the books owned by the library\n" +
                    "ListAvailable - Print out all of the books which are currently available to check out (i.e. not already checked out)\n" +
                    "Author - Print out all of the books by a given author\n" +
                    "Year - Print out all of the books published on or after a given year\n" +
                    "Sort - Sort all of the books owned by the library\n" +
                    "Info - Print out all of the information about a single book by searching its title or index\n" +
                    "Checkout - Check out a book (only if it is available to check out)\n" +
                    "Return - Return a book (only if it is currently checked out)\n" +
                    "Donate - Adds a new book to the library (Thank you for your donation!)\n" +
                    "Quit");
            }
            
            else if (input == "QUIT")
            {
                running = false;
            }

            else if (input == "LISTBOOKS" || input == "LISTALL")
            {
                ListBooks(books);
            }
            
            else if (input == "LISTAVAILABLE")
            {
                ListBooks(books, true);
            }
            
            else if (input == "AUTHOR")
            {
                string? errortext = null;
                PrintMenu("Insert Author Name to Search:\n");
                input = Console.ReadLine()?.ToUpper() ?? "";
                
                if (input.Length < 3)
                    PrintMenu("The name of the Author must be at least 3 characters long.");
                else
                {
                    ListBooks(books, false, input);
                }
                
            }
            
            else if (input == "YEAR")
            {
                PrintMenu("Insert Year to Search:\n");
                input = Console.ReadLine()?.ToUpper() ?? "";

                if(int.TryParse(input, out int yearChoice))
                {
                    if (yearChoice < 0)
                        PrintMenu("Please insert a positive year.");
                    else
                    {
                        ListBooks(books, false, null, yearChoice);
                    }
                }
                else
                {
                    PrintMenu("Year Not Recognized.");
                }
            }
            
            else if (input == "SORT")
            {
                PrintMenu("" +
                          "Sort by: \n" +
                          "1) Page Number\n" +
                          "2) Title\n" +
                          "3) Author\n" +
                          "4) Genre\n" +
                          "5) Year\n\n" +
                          "0) Cancel");
                input = Console.ReadLine()?.ToUpper() ?? "";
                
                if (int.TryParse(input, out int i))
                {
                    switch (i)
                    {
                        case 0:
                            PrintMenu("Canceled Sorting");
                            break;
                        case 1:
                            Array.Sort(books, (b1, b2) => b1.PageLength.CompareTo(b2.PageLength));
                            ListBooks(books);
                            break;
                        case 2:
                            Array.Sort(books, (b1, b2) => b1.Title.CompareTo(b2.Title));
                            ListBooks(books);
                            break;
                        case 3:
                            Array.Sort(books, (b1, b2) => b1.Author.CompareTo(b2.Author));
                            ListBooks(books);
                            break;
                        case 4:
                            Array.Sort(books, (b1, b2) => b1.Genre.CompareTo(b2.Genre));
                            ListBooks(books);
                            break;
                        case 5:
                            Array.Sort(books, (b1, b2) => b1.Year.CompareTo(b2.Year));
                            ListBooks(books);
                            break;
                    }
                }
                else
                {
                    PrintMenu("Input not recognized.");
                }
            }
            
            else if (input == "INFO")
            {
                PrintMenu("Enter a Title or Index Please.");
                input = Console.ReadLine()?.ToUpper() ?? "";

                if (int.TryParse(input, out int i))
                {
                    if (i < 0 || i >= books.Length)
                    {
                        PrintMenu("Please insert a valid book index.\nYou can view the index with the command \"ListBooks\"");
                    }
                    else
                    {
                        PrintMenu(books[i].ToString()); // the call ToString() has to be called here idk why my IDE is yelling at me. Dont hang me for it
                    }
                }
                else if  (input.Length > 2)
                {
                    ListBooks(books, false, null, -1, input);
                }
                else if (input.Length < 3)
                {
                    PrintMenu("Title has to be more than 3 characters long.");
                }
                else
                {
                    PrintMenu("Invalid book Index or Title!");
                }
                
            }
            
            else if (input == "CHECKOUT")
            {
                PrintMenu("Enter a Title or Index Please...");
                input = Console.ReadLine()?.ToUpper() ?? "";
                
                
                if (int.TryParse(input, out int i))
                {
                    if (i < 0 || i >= books.Length)
                    {
                        PrintMenu("Invalid book index.");
                        continue;
                    }
                    if (books[i].CheckedOut)
                    {
                        PrintMenu("That book is already checked out...\n" +
                                "Please get a book that isn't checked out.");
                    }
                    else if (!books[i].CheckedOut)
                    {
                        books[i].CheckedOut = true;
                        PrintMenu("Successfully checked out:\n" +
                                    books[i]);
                    }
                    else
                    { 
                        PrintMenu("Invalid book Index or Title!");
                    }
                }
                else if   (input.Length > 2)
                {
                    foreach (Book book in books)
                    {
                        if (book.Title == input && !book.CheckedOut)
                        {
                            book.CheckedOut = true;
                            PrintMenu("Successfully checked out: " + book.Title);
                            break;
                        }
                    }
                }
                else
                {
                    PrintMenu("Input not recognized.");
                }
            }
            
            else if (input == "RETURN")
            {
                PrintMenu("Enter a Title or Index that you are returning...");
                input = Console.ReadLine()?.ToUpper() ?? "";
                if (int.TryParse(input, out int i))
                {
                    if (i < 0 || i >= books.Length)
                    {
                        PrintMenu("Invalid book index.");
                        continue;
                    }
                    if (books[i].CheckedOut)
                    {
                        books[i].CheckedOut = false;
                        PrintMenu("Successfully returned: " + books[i]);
                    }
                    else if (!books[i].CheckedOut)
                    {
                        PrintMenu("That book isn't checked out. We already have the book.");
                    }
                    else
                    {
                        PrintMenu("Invalid book Index or Title!");
                    }
                }
                else if  (input.Length > 2)
                {
                    foreach (Book book in books)
                    {
                        if (book.Title == input && book.CheckedOut)
                        {
                            book.CheckedOut = false;
                            PrintMenu("Successfully returned: " + book.Title);
                            break;
                        }
                    }
                }
                else
                {
                    PrintMenu("Input not recognized.");
                }
            }
            else if (input == "DONATEBOOK" || input == "DONATE" || input == "ADDBOOK")
            {
                string? title = null;
                string? author = null;
                string? genre = null;
                int pages = -1;
                int year = -1;
                bool exit = false;
                string? errortext = null;
                
                int i = 0;
                while (i < 6)
                {
                    
                    if (i == 0)
                    {
                        PrintMenu("Enter the Title Of Book:\n(Type \"?Exit\" to Cancel or \"?GoBack\" to change last var)", errortext);
                        errortext = null;
                        input = Console.ReadLine() ?? "";
                        if (input.Length < 3)
                        {
                            errortext = "Title must be at least 3 characters long and not NULL/Empty.";
                            i--;
                        }
                        else if (input.ToUpper() == "?EXIT")
                        {
                            exit = true;
                            break;
                        }
                        else if (input.ToUpper() == "?GOBACK")
                        {
                            i -=2;
                        }
                        else
                        {
                            title = input;
                        }
                    }
                    else if (i == 1)
                    {
                        PrintMenu("Enter Author of Book:\n(Type \"?Exit\" to Cancel or \"?GoBack\" to change last var)", errortext);
                        errortext = null;
                        input = Console.ReadLine() ?? "";
                        if (input.Length < 3)
                        {
                            errortext = "Name must be at least 3 characters long and not NULL/Empty.";
                            i--;
                        }
                        else if (input.ToUpper() == "?EXIT")
                        {
                            exit = true;
                            break;
                        }
                        else if (input.ToUpper() == "?GOBACK")
                        {
                            i -=2;
                        }
                        else
                        {
                            author = input;
                        }
                    }
                    else if (i == 2)
                    {
                        PrintMenu("Enter Genre of Book:\n(Type \"?Exit\" to Cancel or \"?GoBack\" to change last var)", errortext);
                        errortext = null;
                        input = Console.ReadLine() ?? "";
                        if (input.Length < 3)
                        {
                            errortext = "Genre must be at least 3 characters long.";
                            i--;
                        }
                        else if (input.ToUpper() == "?EXIT")
                        {
                            exit = true;
                            break;
                        }
                        else if (input.ToUpper() == "?GOBACK")
                        {
                            i -=2;
                        }
                        else
                        {
                            genre = input;
                        }
                    }
                    else if (i == 3)
                    {
                        PrintMenu("Enter Number of Pages:\n(Type \"?Exit\" to Cancel or \"?GoBack\" to change last var)",errortext);
                        errortext = null;
                        input = Console.ReadLine() ?? "";
                        if (int.TryParse(input, out int Page))
                        {
                            if (Page <= 0)
                            {
                                errortext = "A book cannot have less than 1 page.";
                                i--;
                            }
                            pages = Page;
                        }
                        else if (input.ToUpper() == "?EXIT")
                        {
                            exit = true;
                            break;
                        }
                        else if (input.ToUpper() == "?GOBACK")
                        {
                            i -=2;
                        }
                        else
                        {
                            errortext = "Please enter a valid page number.";
                            i--;
                        }
                    }
                    else if (i == 4)
                    {
                        PrintMenu("Enter Year of Book:\n(Type \"?Exit\" to Cancel or \"?GoBack\" to change last var)", errortext);
                        errortext = null;
                        input = Console.ReadLine() ?? "";
                        if (int.TryParse(input, out int TheYear))
                        {
                            if (TheYear <= 0)
                            {
                                errortext = "The Year must be positive.";
                                i--;
                            }
                            else
                            {
                                year = TheYear;
                            }
                        }
                        else if (input.ToUpper() == "?EXIT")
                        {
                            exit = true;
                            break;
                        }
                        else if (input.ToUpper() == "?GOBACK")
                        {
                            i -=2;
                        }
                        else
                        {
                            errortext = "Please enter a valid year.";
                            i--;
                        }
                    }
                    else if (i == 5)
                    {
                        PrintMenu("Does this look Correct? (Y/N)\n" +
                                  $"{title} ({year}) by {author} in {genre} section. {pages} pages long.");
                        
                        input = Console.ReadLine() ?? "";
                        if (input == "N" || input == "n" || input == "?Go Back")
                        {
                            i -= 2;
                        }
                        else if (input == "?EXIT")
                        {
                            exit = true;
                            break;
                        }
                        else if (input == "Y" || input == "y")
                        {
                            i = 6;
                        }
                        else
                        {
                            i--;
                        }
                    }
                    i++;
                }
                if (!exit)
                {
                    Book newbook = new Book(title, author, genre, pages, year, false);
                    books = books.Append(newbook).ToArray();
                    WriteBookToFile(newbook, path);
                    PrintMenu("Book created: " + newbook.Title);
                }
                else
                {
                    PrintMenu("Book Donation Canceled.");
                }
            }
            else
            {
                PrintMenu("Input Command Not Recognized. Please try again.");
            }
        }
        
    }
}