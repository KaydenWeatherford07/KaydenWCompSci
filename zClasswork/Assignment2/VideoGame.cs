public class VideoGame
{

    public VideoGame(String title, int sales, String platforms, String releaseDate, String developer, String publisher)
    {
        Title = title;
        Sales = sales;
        Platforms = platforms;
        ReleaseDate = releaseDate;
        Developer = developer;
        Publisher = publisher;
    }

    #region getters
    public String Title
        {
            get;
        }

    public int Sales
        {
            get;
        }

    public String Platforms
        {
            get;
        }

    public String ReleaseDate
    {
        get;
    }

    public String Developer
    {
        get;
    }

    public String Publisher
    {
        get;
    }

    public double SalesToTitleLength()
    {
        return (double)Sales / (double)Title.Length;
    }
    #endregion

    public override string ToString()
    {
        return
            $"\"{Title}\" developed by {Developer} and published by {Publisher} on {ReleaseDate} has sold {Sales}+ copies! - {Platforms}";
    }
}