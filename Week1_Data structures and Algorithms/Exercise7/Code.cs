using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Financial Forecasting Using Recursion\n");

        Console.Write("Enter the current amount: ");
        double currentValue = double.Parse(Console.ReadLine());

        Console.Write("Enter the annual growth rate (%): ");
        double growthRate = double.Parse(Console.ReadLine()) / 100;

        Console.Write("Enter number of years to forecast: ");
        int years = int.Parse(Console.ReadLine());

        double forecastedValue = ForecastRecursive(currentValue, growthRate, years);

        Console.WriteLine($"\nForecasted value after {years} years: {forecastedValue:F2}");

        Console.WriteLine("\n--- Analysis ---");
        Console.WriteLine("Recursion simplifies the forecasting by breaking the problem into yearly predictions.");
        Console.WriteLine("Each year is calculated based on the previous year's value using the formula:");
        Console.WriteLine("FutureValue(n) = FutureValue(n - 1) * (1 + growthRate)");

        Console.WriteLine("\nTime Complexity:");
        Console.WriteLine("Recursive version time complexity: O(n) — one call per year.");

        Console.WriteLine("\nOptimization:");
        Console.WriteLine("This recursion is already linear, but if you calculate the same year multiple times,");
        Console.WriteLine("use memoization to store results and avoid recomputation.");
    }

    static double ForecastRecursive(double value, double rate, int years)
    {
        if (years == 0)
            return value;

        return ForecastRecursive(value, rate, years - 1) * (1 + rate);
    }
}
