namespace CompSci.zClasswork.MidTermProject;

public class Book
{
    private bool isCheckedOut;
    
    public Book(string title,string author,string genre,int pageLength,int year,string checkedOut)
    {
        Title = title;
        Author = author;
        Genre = genre;
        PageLength = pageLength;
        Year = year;

        if (String.IsNullOrEmpty(checkedOut))
        {
            throw new Exception("Book checked out is null or empty");
        }
        if (checkedOut == "Yes")
        {
            isCheckedOut = true;
        }
        else if (checkedOut == "No")
        {
            isCheckedOut = false;
        }
        else
        {
            throw new Exception($"Incorrect Operator for 'CheckedOut' for book {Title}");
        }
    }
    
    public Book(string title,string author,string genre,int pageLength,int year,bool checkedOut)
    {
        Title = title;
        Author = author;
        Genre = genre;
        PageLength = pageLength;
        Year = year;
        isCheckedOut = checkedOut;
    }

    public string Title
    {
        get;
    }

    public string Author
    {
        get;
    }

    public string Genre
    {
        get;
    }

    public int PageLength
    {
        get;
    }

    public int Year
    {
        get;
    }

    public bool CheckedOut
    {
        get => isCheckedOut;
        set => isCheckedOut = value;
    }

    public override string ToString()
    {
        string strCheckedOut = null;
        if (isCheckedOut)
        {
            strCheckedOut = "Yes";
        }
        else if (!isCheckedOut)
        {
            strCheckedOut = "No";
        }
        else
        {
            throw new Exception($"Error for 'CheckedOut' for book {Title}");
        }
        return $"{Title} ({Year}) by {Author} in {Genre} section. {PageLength} pages. Is Checked Out?: {strCheckedOut}";
    }

    public string FileWriteFormat()
    {
        string strCheckedOut = null;
        if (isCheckedOut)
        {
            strCheckedOut = "Yes";
        }
        else if (!isCheckedOut)
        {
            strCheckedOut = "No";
        }
        else
        {
            throw new Exception($"Error for 'CheckedOut' for book {Title}");
        }
        return $"{Title},{Author},{Genre},{PageLength},{Year},{strCheckedOut}";
    }
}