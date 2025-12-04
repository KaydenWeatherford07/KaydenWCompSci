namespace CompSci.zClasswork.Lab11
{
	public static partial class Lab11 {
		private static void Task1(IEnumerable<Person> people) {
			// 1.2: Create a collection which will be used to store the names of all people in their 20s
			List<String> persons = new List<String>();
		
		
			// 1.3: Iterate through 'people' and add each person in their 20s' name to the collection
			foreach (Person person in people)
			{
				if (person.Age >= 20 && person.Age < 30)
				{
					persons.Add(person.Name);
				}
			}
			// 1.4: Iterate over the collection you created in 1.2 and print each element
			foreach (String person in persons)
			{
				Console.Write(person + " ");
			}
			Console.WriteLine();
		}

		private static void Task2(IEnumerable<Person> people) {
			// 2.2: Create a collection which will be used to store the unique names of the people
			HashSet<String> pop = new HashSet<String>();
		
			// 2.3: Iterate through 'people' and add each person's name to the collection
			foreach (Person person in people)
			{
				pop.Add(person.Name);
			}
		
			// 2.4: Print the number of unique names in the collection
			Console.WriteLine(pop.Count);
			// 2.4: Print each name in the collection
			foreach (String person in pop)
			{
				Console.Write(person + " ");
			}
			Console.WriteLine();
		}

		private static void Task3(IEnumerable<Person> people) {
			// 3.2: Create a collection which allows you to look up a person by their ID
			Dictionary<int, Person> pep = new Dictionary<int, Person>();
		
			// 3.3: Iterate through 'people' and add each person to the collection
			// Each person has a unique ID which would be useful for looking them up
			foreach (Person person in people)
			{
				pep[person.Id] = person;
			}
		
			// 3.4: Print the number of people in the collection
			Console.WriteLine(pep.Count);
		
			// 3.5: Print the person with the ID 9676529 if they exist in the collection
			// If they do not exist, print "Person not found"
			if (pep.ContainsKey(9676529))
			{
				Console.WriteLine(pep[9676529]);
			}
			else
			{
				Console.WriteLine("Person not found.");
			}
		
			// 3.6: Print the person with the ID 7879447 if they exist in the collection
			// If they do not exist, print "Person not found"
			if (pep.ContainsKey(7879447))
			{
				Console.WriteLine(pep[7879447]);
			}
			else
			{
				Console.WriteLine("Person not found.");
			}
		
			// 3.7: Create a Person object which represents you. Use your own name, age, and student ID.
			// Add yourself to the collection from 3.2, overwriting anyone else who might share your ID.
			if (pep.ContainsKey(2107925))
			{
				pep.Remove(2107925);
			}

			Person me = new Person("Kayden Weatherford", 18, 2107925);
			pep.Add(me.Id, me);
			// 3.8: Print every entry in the collection in the following format:
			// ID : Name
			foreach (KeyValuePair<int, Person> e in pep)
			{
				Console.WriteLine(e.Key + " : " + e.Value.Name);
			}
		}
	}

	#region DO NOT MODIFY
	public static partial class Lab11 {
		private static void Main() {
			Person[] people =  {
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
			};

			Console.WriteLine("Names of Users in their 20s:");
			Task1(people);

			Console.WriteLine("Unique Names:");
			Task2(people);

			Console.WriteLine("Lookup Table:");
			Task3(people);
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
}