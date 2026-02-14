namespace CompSci.zClasswork.FileIOPart2 {
	public class Album {
		private string title;
		private string artist;
		private int rank;
		private int year;
		private string genre;

		public Album(string title, string artist, int rank, int year, string genre) {
			Title = title;
			Artist = artist;
			Rank = rank;
			Year = year;
			Genre = genre;
		}

		public override string ToString() {
			return $"#{Rank:000}: {Title} by {Artist} ({Year}) [{Genre}]";
		}

		public string Title {
			get => title;
			set {
				if (string.IsNullOrWhiteSpace(value)) {
					throw new ArgumentNullException(nameof(Title), "Title cannot be null or empty");
				}

				title = value;
			}
		}

		public string Artist {
			get => artist;
			set {
				if (string.IsNullOrWhiteSpace(value)) {
					throw new ArgumentNullException(nameof(Artist), "Artist cannot be null or empty");
				}

				artist = value;
			}
		}

		public int Rank {
			get => rank;
			set {
				if (value < 1) {
					throw new ArgumentOutOfRangeException(nameof(Rank), "Rank must be a positive integer greater than 1");
				}

				rank = value;
			}
		}

		public int Year {
			get => year;
			set {
				if (value < 1900 || value > DateTime.Now.Year + 1) {
					throw new ArgumentOutOfRangeException(nameof(Year), $"Year must be between 1900 and {DateTime.Now.Year + 1}");
				}

				year = value;
			}
		}

		public string Genre {
			get => genre;
			set {
				if (string.IsNullOrWhiteSpace(value)) {
					throw new ArgumentNullException(nameof(Genre), "Genre cannot be null or empty");
				}

				genre = value;
			}
		}
	}
}