namespace CompSci451.PA1 {
	public sealed class Employee {
		public int EmployeeId { get; init; }
		public DateOnly DateOfBirth { get; init; }
		public DateOnly HireDate { get; init; }
		public Status EmploymentStatus { get; init; }
		public string Department { get; init; } = "";
		public string Role { get; init; } = "";
		public string City { get; init; } = "";
		public string State { get; init; } = "";
		public string Region { get; init; } = "";
		public int BaseSalaryUsd { get; init; }

		public string ProductLine { get; init; } = "";
		public int QuotaUsd { get; init; }
		public int SalesYtdUsd { get; init; }

		public override string ToString() {
			return $"EID #{EmployeeId:0000000} - {Role} in {Department} ({EmploymentStatus})";
		}

		public enum Status {
			Active,
			OnLeave,
			Terminated,
		}
	}
}