namespace CompSci451.PA1 {
	static partial class AnnualReport {
		private static IList<Employee> Task1(IEnumerable<Employee> employees)
		{
			return employees.Where(e => e.EmploymentStatus == Employee.Status.Active)
				.OrderByDescending(e => e.EmployeeId).ToList();
		}

		private static IList<string> Task2(IEnumerable<Employee> employees) {
			return employees.Select(e => e.State).Order().Distinct().ToList();
		}

		private static int Task3(IEnumerable<Employee> employees) {
			return employees.Where(e => e.Department == "Sales").Sum(e => e.SalesYtdUsd);
		}

		private static IEnumerable<Employee> Task4(IEnumerable<Employee> employees, int N) {
			return employees.Where(e => e.EmploymentStatus == Employee.Status.Active).OrderByDescending(e => e.SalesYtdUsd).Take(N).ToList();
		}

		private static IDictionary<string, double> Task5(IEnumerable<Employee> employees)
		{
			return employees.GroupBy(e => e.Department).ToDictionary(
				group => group.Key, 
				group => group.Average(e => e.BaseSalaryUsd));
		}

		private static IDictionary<string, int> Task6(IEnumerable<Employee> employees) {
			return employees.GroupBy(e => e.Region).ToDictionary(
				group => group.Key, 
				group => group.Sum(e => e.SalesYtdUsd));
		}

		private static IEnumerable<Employee> Task7(IEnumerable<Employee> employees) {
			return employees.Where(e => (e.SalesYtdUsd-e.BaseSalaryUsd) < 0).OrderBy(e => (e.SalesYtdUsd-e.BaseSalaryUsd)).ToList();
		}
		
		private static IDictionary<string, Dictionary<string, int>> Task8(IEnumerable<Employee> employees)
		{
			return employees.GroupBy(e => e.Region).ToDictionary(group => group.Key, group => group.GroupBy(e => e.Department).ToDictionary(group => group.Key, group => group.Count()));
		}

		private static IDictionary<string, IEnumerable<Employee>> Task9(IEnumerable<Employee> employees, int N)
		{
			return employees.GroupBy(e => e.Region).ToDictionary(
				group => group.Key,
				group => group.
					OrderByDescending(e => e.SalesYtdUsd).
					Take(N)
			);
		}

		private static IEnumerable<Employee> Task10(IEnumerable<Employee> employees)
		{
			return employees.Where(e => e.EmploymentStatus == Employee.Status.Terminated).
				GroupBy(e => e.Department).
				Select(
					e => e.
						OrderByDescending(e => e.HireDate).
						First()
					).
				ToList();
		}
	}
}
