namespace CompSci.zClasswork.FinalProject;

public class AudioBook : Media<BoolRating>
{
    private bool like;
    public AudioBook(string title, string creator, int year, int duration, bool rating) : 
        base(title, creator, year, duration, new BoolRating(rating))
    {
        like = rating;
    }

    public override string ToString()
    {
        string guh;
        switch (like)
        {
            case true:
                guh = "Yes";
                break;
            case false:
                guh = "No";
                break;
        }
        return $"{Title} by {Creator} ({Year}). [Dur: {Duration}min ] (Liked? {guh})";
    }
}

