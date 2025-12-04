namespace CompSci.zClasswork.FinalProject;

public class Episode: Media<IntRating>
{
    private int Rating;
    
    public Episode(string title, string showtitle, string creator, int year, int seasonnumber, int episodenumber, int duration, int rating) :
        base(title, creator, year, duration, new IntRating(rating))
    {
        if (string.IsNullOrEmpty(showtitle))
            throw new ArgumentNullException("showtitle");
        ShowTitle = showtitle;
        SeasonNumber = seasonnumber;
        EpisodeNumber = episodenumber;
        Rating = rating;
    }

    public string ShowTitle {get;}
    public int SeasonNumber {get;}
    public int EpisodeNumber {get;}

    public override string ToString()
    {
        return $"{Title} - {ShowTitle} by {Creator} ({Year}) [Season {SeasonNumber}, Episode {EpisodeNumber}] [Dur: {Duration}min ] ({this.NormalizedRating * 10}/10)";
    }
    
}

