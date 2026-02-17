/*
namespace CompSci451 {
	public static partial class LINQ {
		private static void Main() {
			IEnumerable<Album> albums = LoadAlbumsFromFile("Rolling-Stone-Top-500-Albums.csv");

			// Print all artists represented in the list without duplicates
			Console.WriteLine("All Artists:");
			albums.Select(a => a.Artist)
				.Distinct()
				.ToList()
				.ForEach(Console.WriteLine);

			// Print all albums released in the 1970s
			Console.WriteLine("\nAlbums Released in the 1970s:");
			albums.Where(a => a.Year >= 1970 && a.Year < 1980)
				.ToList()
				.ForEach(Console.WriteLine);

			// Print the top 10 albums in the rock genre
			Console.WriteLine("\nTop 10 Albums in the Rock Genre");
			albums.Where(a => a.Genre == Genre.Rock)
				.OrderBy(a => a.Rank)
				.Take(10)
				.ToList()
				.ForEach(Console.WriteLine);

			// Print the number of albums released by The Beatles
			Console.WriteLine("\nNumber of Albums by The Beatles");
			Console.WriteLine(albums.Count(a => a.Artist == "The Beatles"));

			// Print the average release year of all albums in the rock genre
			Console.WriteLine("\nAverage release year of albums in the Rock genre:");
			Console.WriteLine(albums.Where(a => a.Genre == Genre.Rock)
				.Average(a => a.Year));

			// Print the longest album title
			Console.WriteLine("\nLongest album title:");
			Console.WriteLine(albums.MaxBy(a => a.Title.Length)?.Title);

			// Print the shortest album title
			Console.WriteLine("\nShortest album title:");
			Console.WriteLine(albums.MinBy(a => a.Title.Length)?.Title);

			// Print the 5 most recent rock albums with the word 'love' in the title, sorted by rank
			Console.WriteLine("\n5 most recent rock albums with the word 'Love' in the title sorted by rank:");
			albums.Where(a => a.Genre == Genre.Rock && a.Title.Contains("Love"))
				.OrderByDescending(a => a.Year)
				.Take(5)
				.OrderBy(a => a.Rank)
				.ToList()
				.ForEach(Console.WriteLine);

			// Print all albums sorted by artist and then by release year
			Console.WriteLine("\nAlbums sorted by artist then year:");
			albums.OrderBy(a => a.Artist)
				.ThenBy(a => a.Year)
				.ToList()
				.ForEach(Console.WriteLine);
		}
	}

	#region UNRELATED TO LECTURE CONTENT
	public static partial class LINQ {
		// This method loads the albums from the file and returns them as a list.
		// Its implementation is not important for this example and is best treated as a black box.
		private static IEnumerable<Album> LoadAlbumsFromFile(string path) {
			List<Album> albums = new List<Album>();

			using StreamReader reader = new StreamReader(path);

			reader.ReadLine();

			while (!reader.EndOfStream) {
				string[] cols = reader.ReadLine().Split(',');

				int rank = int.Parse(cols[0]);
				int year = int.Parse(cols[1]);
				string title = cols[2];
				string artist = cols[3];
				Genre genre = Enum.Parse<Genre>(cols[4]);

				albums.Add(new Album(title, artist, rank, year, genre));
			}

			return albums;
		}
	}

	public sealed class Album {
		private string title;
		private string artist;
		private int rank;
		private int year;

		public Album(string title, string artist, int rank, int year, Genre genre) {
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

		public Genre Genre {
			get;
			set;
		}
	}

	public enum Genre : byte {
		Blues,
		Classical,
		Electronic,
		Folk,
		Funk,
		HipHop,
		Jazz,
		Latin,
		Pop,
		Reggae,
		Rock,
	}
	#endregion
}
*/