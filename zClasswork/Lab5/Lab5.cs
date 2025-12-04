namespace CompSci.zClasswork.Lab5
{
	public static class Lab5 {
		private static double PricePerUnit(Order order)
		{
			double PricePayedPerUnit = order.Cost / order.Quantity;
			return PricePayedPerUnit;
		}
		private static Order BestDeal(Order[] orders) {
			double bestdeal = PricePerUnit(orders[0]);
			int bestdealIndex = 0;
		
			for (int i = 1; i < orders.Length; i++)
			{
				if (PricePerUnit(orders[i]) < bestdeal)
				{
					bestdeal = PricePerUnit(orders[i]);
					bestdealIndex = i;
				}
			}
		
			return orders[bestdealIndex];
		}

		private static Order WorstDeal(Order[] orders) {
			double worstdeal = PricePerUnit(orders[0]);
			int worstdealIndex = 0;
		
			for (int i = 1; i < orders.Length; i++)
			{
				if (PricePerUnit(orders[i]) > worstdeal)
				{
					worstdeal = PricePerUnit(orders[i]);
					worstdealIndex = i;
				}
			}
		
			return orders[worstdealIndex];
		}

		private static void Sort(Order[] orders) {
			// Sort by price
			for (int i = 1; i < orders.Length; i++) {
				int j = i;
				Order temp = orders[i];

				while (j > 0 && temp.Cost < orders[j - 1].Cost) {
					orders[j] = orders[j - 1]; // Takes one from behind and moves backwards
					j--; 
				}
				
				while ( j > 0 && temp.Cost == orders[j-1].Cost && temp.Id < orders[j - 1].Id) {
					orders[j] = orders[j - 1]; // Moves it behind if the ID
					j--;
				}
				
				orders[j] = temp;
			}

		}

		private static Order[] Cheapest(Order[] orders, int n) {
			// It should return a new array of length n which contains the n least expensive elements of the orders array.
			// Your solution must be O(N) - it can only iterate over the orders array once.
		
			Order[] CheapestOrders = new Order[n];
			for (int i = 0; i < n; i++)
			{
				CheapestOrders[i] = orders[i];
			}
		
			return CheapestOrders;
		}

		private static Order[] MostExpensive(Order[] orders, int n) {
			Order[] ExpensiveOrders = new Order[n];
			for (int i = orders.Length - 1, j = 0; i > (orders.Length - n - 1); i--, j++)
			{
				ExpensiveOrders[j] = orders[i];
			}
		
			return ExpensiveOrders;
		}
	

		#region DO NOT MODIFY
		private static Order[] GenerateOrders() {
			Random random = new Random(221);

			Order[] orders = new Order[10000];
			for (int i = 0; i < orders.Length; i++) {
				int quantity = random.Next(1, 21);
				double cost = Math.Round(
					              quantity * (25d + (75d * (21d - quantity) / 20d) + (-15.00 + 30.00 * random.NextDouble())) * 10.0)
				              / 10.0;
				orders[i] = new Order(i + 1, quantity, cost);
			}

			for (int i = orders.Length - 1; i > 0; i--) {
				int j = random.Next(i + 1);
				Order temp = orders[i];
				orders[i] = orders[j];
				orders[j] = temp;
			}

			return orders;
		}

		private static void Main() {
			Order[] orders = GenerateOrders();

			Console.WriteLine($"\nBest deal is {BestDeal(orders)}");
			Console.WriteLine($"Worst deal is {WorstDeal(orders)}");

			Sort(orders);

			Console.WriteLine("\nTop 10 cheapest orders:");
			Order[] cheapestOrders = Cheapest(orders, 10);
			for (int i = 0; i < cheapestOrders.Length; i++) {
				Console.WriteLine(cheapestOrders[i]);
			}

			Console.WriteLine("\nTop 10 most expensive orders:");
			Order[] mostExpensiveOrders = MostExpensive(orders, 10);
			for (int i = 0; i < mostExpensiveOrders.Length; i++) {
				Console.WriteLine(mostExpensiveOrders[i]);
			}
		}
	}

	class Order {
		public Order(int id, int quantity, double cost) {
			Id = id;
			Quantity = quantity;
			Cost = cost;
		}

		public override string ToString() {
			return $"#{Id:0000}: {Cost:C} (x{Quantity}) at {(Cost / Quantity):C} per unit";
		}

		public int Id { get; }

		public int Quantity { get; }

		public double Cost { get; }
	}
	#endregion
}