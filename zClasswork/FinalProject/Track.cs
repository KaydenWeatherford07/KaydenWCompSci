namespace CompSci.zClasswork.FinalProject;

public class Track: Media<DoubleRating>
{
    private double Rating;
    
    public Track(string title, string creator, string album, int year, int duration, double rating) : 
        base(title, creator, year, duration, new DoubleRating(rating))
    {
        if (string.IsNullOrEmpty(album))
            throw new ArgumentNullException("album");
        Album = album;
        Rating = rating;
    }
    public string Album {get;}

    
    
    public override string ToString()
    {
        return $"{Title} by {Creator} in {Album} ({Year}). [Dur: {Duration}min ] (Rating: {(this.NormalizedRating * 5):0.0}/5)";
    }
}

