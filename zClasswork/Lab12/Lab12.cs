public static partial class Lab12 {
	private static void Task1(List<Person> people) {
		people.Sort((x, y) => x.Id.CompareTo(y.Id));
		people.ForEach(Console.WriteLine);
	}

	private static void Task2(List<Person> people)
	{
		people.FindAll(x => x.Name.Length <= 4).ForEach(Console.WriteLine);
	}

	private static void Task3(List<Person> people)
	{
		people.Sort((x, y) => y.Age.CompareTo(x.Age));
		int num = 1;
		people.ForEach(p =>
		{
			if (num <= 10)
			{
				Console.WriteLine(num + ": " + p);
				num++;
			}
		});
	}

	private static int Task4(List<Person> people) {
		int num = 0;
		people.ForEach(x =>
		{
			if (x.Age >= 20 && x.Age < 30)
			{
				num++;
			}
		});
		return num;
	}
}

#region DO NOT MODIFY
public static partial class Lab12 {
	private static void Main() {
		List<Person> people = [
			new Person("Thomas", 29, 4424053),
			new Person("Doug", 28, 3566351),
			new Person("Emily", 21, 1414265),
			new Person("Brandon", 33, 3327914),
			new Person("Sydney", 25, 4662533),
			new Person("Katie", 34, 7597009),
			new Person("Sean", 18, 9768190),
			new Person("Allison", 45, 1904318),
			new Person("Patrick", 39, 4257062),
			new Person("Thomas", 65, 9676529),
			new Person("Dan", 47, 5796922),
			new Person("Cheryl", 68, 3602379),
			new Person("Diane", 59, 7879547),
			new Person("Sean", 29, 3126082),
			new Person("Emily", 21, 8625939),
			new Person("Steve", 72, 9896929),
			new Person("Roger", 80, 6166000),
			new Person("Thomas", 19, 5166720),
			new Person("Jack", 34, 8831654),
			new Person("Veronica", 27, 1169289),
		];

		Console.WriteLine("All People Sorted By Their ID:");
		Task1(people);

		Console.WriteLine("\nAll People Whose Name Is 4 Letters Or Shorter:");
		Task2(people);

		Console.WriteLine("\n10 Oldest People:");
		Task3(people);

		Console.Write("\nNumber Of People In Their 20s: ");
		int answer = Task4(people);
		Console.WriteLine(answer);
	}
}

public sealed class Person {
	private string name;
	private int age;
	private int id;

	public Person(string name, int age, int id) {
		Name = name;
		Age = age;
		Id = id;
	}

	public override string ToString() {
		return $"{Name} ({Age}) [{Id}]";
	}

	public string Name {
		get => name;
		set {
			if (string.IsNullOrWhiteSpace(value)) {
				throw new ArgumentNullException(nameof(Name));
			}

			name = value;
		}
	}

	public int Age {
		get => age;
		set {
			if (value < 0 || value > 120) {
				throw new ArgumentOutOfRangeException(nameof(Age));
			}

			age = value;
		}
	}

	public int Id {
		get => id;
		set {
			if (value < 1000000 || value > 9999999) {
				throw new ArgumentOutOfRangeException(nameof(Id));
			}

			id = value;
		}
	}
}
#endregion