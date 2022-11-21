namespace MainConsole;

public class GetFromApi
{
    public static async Task<string> HttpRequestTech(string apiKey)
    {
        Console.WriteLine("Enter technical indicator");
        var techIndicator = Console.ReadLine();
        Console.WriteLine("Enter symbol: ");
        var symbol = Console.ReadLine();
        Console.WriteLine("Enter interval: ");
        var interval = Console.ReadLine();
        HttpRequests request = new HttpRequests(techIndicator, null, apiKey, interval, symbol, null);
        string responseJson = await request.GetTechnicalIndicator();
        return responseJson;
    }

    public static async Task<string> HttpRequestTechTimePeriod(string apiKey)
    {
        Console.WriteLine("Enter technical indicator");
        var techIndicator = Console.ReadLine();
        Console.WriteLine("Enter symbol: ");
        var symbol = Console.ReadLine();
        Console.WriteLine("Enter interval: ");
        var interval = Console.ReadLine();
        Console.WriteLine("Enter time period: ");
        var timePeriod = Console.ReadLine();
        HttpRequests request = new HttpRequests(techIndicator, null, apiKey, interval, symbol, timePeriod);
        string responseJson = await request.GetTechnicalIndicatorTimePeriod();
        return responseJson;
    }

    public static async Task<string> HttpRequestInfo(string apiKey, string endpoint)
    {
        Console.WriteLine("Enter symbol: ");
        var symbol = Console.ReadLine();
        HttpRequests request = new HttpRequests(null, endpoint, apiKey, null, symbol, null);
        string responseJson = await request.GetTickerInfo();
        return responseJson;
    }

    public static async Task<string> HttpRequestTimeSeries(string apiKey)
    {
        Console.WriteLine("Enter symbol: ");
        var symbol = Console.ReadLine();
        Console.WriteLine("Enter interval: ");
        var interval = Console.ReadLine();
        HttpRequests request = new HttpRequests(null, null, apiKey, interval, symbol, null);
        string responseJson = await request.GetTickerTimeSeries();
        return responseJson;
    }
}