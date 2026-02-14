namespace CompSci.zClasswork.FileIOLab
{
	public readonly struct Name {
		public readonly string first, last;

		public Name(string first, string last) {
			if (string.IsNullOrWhiteSpace(first)) {
				throw new ArgumentException("First name cannot be empty", nameof(first));
			}

			if (string.IsNullOrWhiteSpace(last)) {
				throw new ArgumentException("Last name cannot be empty", nameof(last));
			}

			this.first = first;
			this.last = last;
		}

		public override string ToString() {
			return $"{first} {last}";
		}
	}
}