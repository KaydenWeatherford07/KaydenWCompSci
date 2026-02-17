namespace CompSci451 {
	static class Events {
		static void Main() {
			// Create an example Account object
			var a1 = new Account();
			a1.Email = "dave@discovery.gov";
			a1.Balance = 1000;

			// Create a series of observers
			// They are unaware of each other, and the Account object is unaware of them.
			var console = new ConsoleLogObserver();
			var file = new FileLogObserver { FilePath = "log.txt" };
			var audio = new AudioObserver();

			// Subscribe the observers to the Account's events
			a1.OnEmailChangedEvent += console.OnEmailChanged;
			a1.OnBalanceChangedEvent += console.OnBalanceChanged;
			a1.OnEmailChangedEvent += file.OnEmailChanged;
			a1.OnBalanceChangedEvent += file.OnBalanceChanged;
			a1.OnEmailChangedEvent += audio.OnEmailChanged;
			a1.OnBalanceChangedEvent += audio.OnBalanceChanged;

			// Make some changes to the Account object, which will trigger the events and notify the observers
			a1.Email = "frank@discovery.gov";
			a1.Balance = 1200;

			// Unsubscribe the audio observer and make some more changes to see the difference
			a1.OnEmailChangedEvent -= audio.OnEmailChanged;
			a1.OnBalanceChangedEvent -= audio.OnBalanceChanged;

			// Changes to email and balance will still notify the console and file observers, but not the audio observer
			a1.Email = "hal@discovery.gov";
			a1.Balance = 1500;

			// We can also subscribe to the events using lambda expressions, which allows us to write inline event handlers without needing to define a separate class
			// However, this approach is less reusable and can lead to more cluttered code if overused, so it's generally best for simple or one-off event handling logic
			a1.OnEmailChangedEvent += (sender, e) => Console.WriteLine($"[Lambda] Email changed from {e.OldEmail} to {e.NewEmail}");
			a1.OnBalanceChangedEvent += (sender, e) => Console.WriteLine($"[Lambda] Balance changed from {e.OldBalance:C} to {e.NewBalance:C}");

			// Make some more changes to see the lambda observers in action
			a1.Email = "heywood@nca.gov";
			a1.Balance = 2000;
		}
	}

	// A common practice is to define an interface for your observers, which allows you to create multiple different types of observers
	// Implementing types can react to the same events in different ways.
	// This promotes code reuse and separation of concerns, as the Account class does not need to know about the specific implementations of the observers
	// and the observers can be easily swapped out or modified without affecting the Account class.
	interface IAccountObserver {
		void OnEmailChanged(object? sender, EmailChangeEventArgs e);
		void OnBalanceChanged(object? sender, BalanceChangeEventArgs e);
	}

	// This observer will log changes to the console, which is useful for debugging or monitoring purposes.
	// It implements the IAccountObserver interface, which allows it to be easily subscribed to the Account's events and react to changes in the email and balance.
	class ConsoleLogObserver : IAccountObserver {
		public void OnEmailChanged(object? sender, EmailChangeEventArgs e) {
			Console.WriteLine($"Email changed from {e.OldEmail} to {e.NewEmail}");
		}

		public void OnBalanceChanged(object? sender, BalanceChangeEventArgs e) {
			Console.WriteLine($"Balance changed from {e.OldBalance:C} to {e.NewBalance:C}");
		}
	}

	// This observer will log changes to a file, which is useful for keeping a permanent record of changes or for analyzing changes over time.
	class FileLogObserver : IAccountObserver {
		public void OnEmailChanged(object? sender, EmailChangeEventArgs e) {
			File.AppendAllText(FilePath, $"Email changed from {e.OldEmail} to {e.NewEmail}\n");
		}

		public void OnBalanceChanged(object? sender, BalanceChangeEventArgs e) {
			File.AppendAllText(FilePath, $"Balance changed from {e.OldBalance:C} to {e.NewBalance:C}\n");
		}

		public required string FilePath { get; init; }
	}

	// Just for fun, this observer will play a jingle whenever the email or balance changes.
	class AudioObserver : IAccountObserver {
		public void OnEmailChanged(object? sender, EmailChangeEventArgs e) {
			Console.Beep(659, 400);
			Console.Beep(587, 400);
			Console.Beep(523, 400);
			Console.Beep(587, 400);
			Console.Beep(659, 400);
			Console.Beep(659, 400);
			Console.Beep(659, 400);
		}

		public void OnBalanceChanged(object? sender, BalanceChangeEventArgs e) {
			Console.Beep(659, 300);
			Console.Beep(659, 300);
			Console.Beep(659, 300);
			Thread.Sleep(150);
			Console.Beep(523, 300);
			Console.Beep(659, 300);
			Thread.Sleep(150);
			Console.Beep(784, 300);
			Thread.Sleep(300);
			Console.Beep(392, 500);
		}
	}
}
