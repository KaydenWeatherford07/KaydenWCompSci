namespace CompSci451 {
	class Account {
		private static int nextNumber = 1;
		private readonly int number;
		private string? email;
		private decimal balance;

		// By exposing these events, we allow other code to subscribe to changes in the account's email and balance.
		// Importantly, the Account class remains agnostic of who is observing it and what they do with the information.
		// This promotes loose coupling and separation of concerns.
		// Events are still fields, so each Account object will have its own set of events that observers can subscribe to.
		// This is to say that changes to one Account will not raise events for other Account objects.
		public event EventHandler<EmailChangeEventArgs>? OnEmailChangedEvent;
		public event EventHandler<BalanceChangeEventArgs>? OnBalanceChangedEvent;

		public Account() {
			number = nextNumber++;
		}

		public override string ToString() {
			return $"Account {number}: {email} (${balance:C})";
		}

		public int Number {
			get => number;
		}

		public string? Email {
			get => email;
			set {
				var oldEmail = email;
				email = value;
				var args = new EmailChangeEventArgs {
					OldEmail = oldEmail,
					NewEmail = email
				};

				// Any changes to an Account object's email must go through this set accessor, which ensures that the appropriate event is raised whenever the email changes.
				// This allows observers to react to changes in the email without needing to know about the internal workings of the Account class.
				// Yet another reason to use properties instead of public fields: we can add logic to the set accessor to ensure that events are raised whenever the email changes, which would not be possible with a public field.
				OnEmailChangedEvent?.Invoke(this, args);
			}
		}

		public decimal Balance {
			get => balance;
			set {
				var oldBalance = balance;
				balance = value;
				var args = new BalanceChangeEventArgs {
					OldBalance = oldBalance,
					NewBalance = balance
				};
				OnBalanceChangedEvent?.Invoke(this, args);
			}
		}
	}

	// The .NET standard for event arguments is to create a class that inherits from EventArgs and contains properties for the relevant information about the event.
	// What is considered relevant information is up to the developer, but it should be enough to allow observers to react appropriately to the event without needing to know about the internal workings of the Account class.
	// In this example, we provide the old and new values for the email and balance, which allows observers to log the changes or perform other actions based on the specific changes that occurred.
	class EmailChangeEventArgs : EventArgs {
		public required string? OldEmail { get; init; }
		public required string? NewEmail { get; init; }
	}

	class BalanceChangeEventArgs : EventArgs {
		public required decimal OldBalance { get; init; }
		public required decimal NewBalance { get; init; }
	}
}
