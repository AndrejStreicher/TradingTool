namespace MainConsole;

public class UserInputs
{
    public static string GetIntervalInput()
    {
        Console.WriteLine("Enter interval: ");
        return Console.ReadLine();
    }

    public static string GetSymbolInput()
    {
        Console.WriteLine("Enter symbol: ");
        return Console.ReadLine();
    }

    public static string GetStartdateInput()
    {
        Console.WriteLine("Enter start-date (2000-12-31|or|2000-12-31 24-59-59): ");
        return Console.ReadLine();
    }

    public static string GetEnddateInput()
    {
        Console.WriteLine("Enter end-date (2000-12-31|or|2000-12-31 24-59-59): ");
        return Console.ReadLine();
    }

    public static string GetTimePeriodInput()
    {
        Console.WriteLine("Enter time-period: ");
        return Console.ReadLine();
    }

    public static string GetTechnicalIndicator()
    {
        Console.WriteLine("Enter technical indicator: ");
        return Console.ReadLine();
    }
}