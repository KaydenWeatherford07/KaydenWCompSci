namespace CompSci.zClasswork.FileIOLab
{
	public class Movie {
		private int year;
		private double rating;
		private string title;

		public Movie(string title, int year, Name director, double rating) {
			Title = title;
			Year = year;
			Director = director;
			Rating = rating;
		}

		public override string ToString() {
			return $"{Title} by {Director} ({Year}) rated {Rating:N2} / 5 stars";
		}

		public string Title {
			get => title;

			set {
				if (string.IsNullOrWhiteSpace(value)) {
					throw new ArgumentException("Title cannot be empty", nameof(Title));
				}

				title = value;
			}
		}

		public Name Director {
			get;
			set;
		}

		public double Rating {
			get => rating;

			set {
				if (value < 0 || value > 5) {
					throw new ArgumentOutOfRangeException(nameof(Rating));
				}

				rating = value;
			}
		}

		public int Year {
			get => year;

			set {
				if (value < 1900 || value > DateTime.Now.Year + 1) {
					throw new ArgumentOutOfRangeException(nameof(Year));
				}

				year = value;
			}
		}
	}
}
