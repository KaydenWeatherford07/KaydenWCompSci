using System.Globalization;

namespace CompSci451.PA1 {
	static partial class AnnualReport {
		private const string CsvPath = "employees.csv";
		private const int TopN = 10;

		private static void Main() {
			var employees = ReadFromFile(CsvPath);

			Console.WriteLine("Task 1: Active Employees:");
			var task1Result = Task1(employees);
			foreach (var employee in task1Result) {
				Console.WriteLine(employee);
			}

			Console.WriteLine("\nTask 2: Unique States:");
			var task2Result = Task2(employees);
			for (var i = 0; i < task2Result.Count; i++) {
				Console.WriteLine($"{i + 1}:\t{task2Result[i]}");
			}

			Console.WriteLine("\nTask 3: Total Sales from the Sales Department:");
			var task3Result = Task3(employees);
			Console.WriteLine(task3Result.ToString("C"));

			Console.WriteLine($"\nTask 4: Top {TopN} Active Employees by Sales YTD:");
			var task4Result = Task4(employees, TopN);
			foreach (var employee in task4Result) {
				Console.WriteLine($"{employee} - Sales YTD: {employee.SalesYtdUsd:C}");
			}

			Console.WriteLine("\nTask 5: Average Base Salary by Department:");
			var task5Result = Task5(employees);
			foreach (var kvp in task5Result) {
				Console.WriteLine($"{kvp.Key}: {kvp.Value:C}");
			}

			Console.WriteLine("\nTask 6: Sales by Region:");
			var task6Result = Task6(employees);
			foreach (var kvp in task6Result) {
				Console.WriteLine($"{kvp.Key}: {kvp.Value:C}");
			}

			Console.WriteLine("\nTask 7: Unprofitable Employees:");
			var culture = CultureInfo.CreateSpecificCulture("en-US");
			culture.NumberFormat.CurrencyNegativePattern = 1;
			var task7Result = Task7(employees);
			foreach (var employee in task7Result) {
				Console.WriteLine($"{employee} - Company Profit: {(employee.SalesYtdUsd - employee.BaseSalaryUsd).ToString("C", culture)}");
			}

			Console.WriteLine("\nTask 8: Employees by Department by Region:");
			var task8Result = Task8(employees);
			foreach (var regionKvp in task8Result) {
				Console.WriteLine($"{regionKvp.Key}:");
				foreach (var deptKvp in regionKvp.Value) {
					Console.WriteLine($"\t{deptKvp.Key}: {deptKvp.Value}");
				}
			}

			Console.WriteLine($"\nTask 9: Top {TopN} Employees by Region:");
			var task9Result = Task9(employees, TopN);
			foreach (var kvp in task9Result) {
				Console.WriteLine($"{kvp.Key}:");
				var place = 1;
				foreach (var employee in kvp.Value) {
					Console.WriteLine($"\t{place++}:\t{employee} - Sales YTD: {employee.SalesYtdUsd:C}");
				}
			}

			Console.WriteLine("\nTask 10: Most Recently Hired Employee Terminated From Each Department:");
			var task10Result = Task10(employees);
			foreach (var employee in task10Result) {
				Console.WriteLine($"{employee} - Department: {employee.Department}, Hire Date: {employee.HireDate}");
			}
			
			Console.ReadLine();
		}

		private static List<Employee> ReadFromFile(string path) {
			if (string.IsNullOrWhiteSpace(path)) {
				throw new ArgumentException("CSV path is required.", nameof(path));
			}

			if (!File.Exists(path)) {
				throw new FileNotFoundException("CSV file not found.", path);
			}

			using var reader = new StreamReader(path);

			var headerLine = reader.ReadLine() ?? throw new InvalidDataException("CSV is empty (missing header row).");
			var employees = new List<Employee>();

			try {
				while (!reader.EndOfStream) {
					var line = reader.ReadLine() ?? string.Empty;
					var fields = line.Split(',');

					var id = int.Parse(fields[0]);

					var dateOfBirth = DateOnly.ParseExact(fields[1], "M/d/yyyy", CultureInfo.InvariantCulture);
					var hireDate = DateOnly.ParseExact(fields[2], "M/d/yyyy", CultureInfo.InvariantCulture);
					var employmentStatus = Enum.Parse<Employee.Status>(fields[3]);
					var department = fields[4];
					var role = fields[5];
					var city = fields[6];
					var state = fields[7];
					var region = fields[8];
					var baseSalaryUsd = int.Parse(fields[9]);
					var productLine = fields[10];
					var quotaUsd = int.Parse(fields[11]);
					var salesYtdUsd = int.Parse(fields[12]);

					employees.Add(new Employee {
						EmployeeId = id,
						DateOfBirth = dateOfBirth,
						HireDate = hireDate,
						EmploymentStatus = employmentStatus,
						Department = department,
						Role = role,
						City = city,
						State = state,
						Region = region,
						BaseSalaryUsd = baseSalaryUsd,
						ProductLine = productLine,
						QuotaUsd = quotaUsd,
						SalesYtdUsd = salesYtdUsd,
					});
				}
			}
			catch (Exception e) {
				throw new InvalidDataException("Error reading employee data from CSV.", e);
			}

			return employees;
		}
	}
}