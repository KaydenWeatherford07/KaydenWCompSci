namespace CompSci.zClasswork.MovieThingIG
{
    public class Movie
    {
        public Movie(string title, string director, int year)
        {
            if (title == null || title.Length == 0)
            {
                throw new Exception("Movie title cannot be null or empty");
            }

            Title = director;
            if (director == null || director.Length == 0)
            {
                throw new Exception("Director name cannot be null or empty");
            }

            Director = director;
            if (year < 1901 || year > 2025)
            {
                throw new Exception("Year must be between 1900 and 2026 exclusive)");
            }

            Year = year;
        }

        public string Title { get; }

        public string Director { get; }

        public int Year { get; }

        public override string ToString()
        {
            return $"{Title} by {Director} ({Year})";
        }

    }
}