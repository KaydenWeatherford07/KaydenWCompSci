namespace TravelAgent;

public class TravelAgent
{
    private static void Main()
    {
        int[] flightNumbers = [4570, 6409, 8432, 9913, 1920];
        string[][] Cities = [
            ["Tokyo", "Chicago", "Toronto", "Milwaukee","New York City"], 
            ["Honolulu", "Detroit", "Rome", "Charlotte", "Los Angeles"]
        ];
        double[] prices = [400.00, 200.00, 500.00, 300.00, 350.00];
        Flight[] flights = new Flight[5];

        // This is just easier for me to wrap my head around
        for (int i = 0; i < flightNumbers.Length; i++)
        {
            flights[i] = new Flight(
                flightNumbers[i], 
                Cities[0][i], 
                Cities[1][i], 
                prices[i]);
            Console.WriteLine(flights[i]);
        }
        
        
        // Task 7/7
        Console.WriteLine("\n\n---HOLIDAY SALE! 25% OFF ALL FLIGHTS OVER $300---");

        foreach (Flight flight in flights)
        {
            if (flight.Price >= 300.00)
            {
                flight.Price *= 0.75;
            }
            Console.WriteLine(flight);
        }
    }
}