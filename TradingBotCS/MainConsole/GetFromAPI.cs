namespace MainConsole;

public class GetFromApi
{
    public static async Task<string> HttpRequestTech(string _apiKey)
    {
        Console.WriteLine("Enter technical indicator");
        var techIndicator = Console.ReadLine();
        Console.WriteLine("Enter symbol: ");
        var symbol = Console.ReadLine();
        Console.WriteLine("Enter interval: ");
        var interval = Console.ReadLine();
        HttpRequests request = new HttpRequests(techIndicator, null, _apiKey, interval, symbol);
        string responseJson = await request.GetTechnicalIndicator();
        return responseJson;
    }

    public static async Task<string> HttpRequestInfo(string _apiKey,string _endpoint)
    {
        Console.WriteLine("Enter symbol: ");
        var symbol = Console.ReadLine();
        HttpRequests request = new HttpRequests(null, _endpoint, _apiKey, null, symbol);
        string responseJson = await request.GetTickerInfo();
        return responseJson;
    }
    public static async Task<string> HttpRequestTimeSeries(string _apiKey)
    {
        Console.WriteLine("Enter symbol: ");
        var symbol = Console.ReadLine();
        Console.WriteLine("Enter interval: ");
        var interval = Console.ReadLine();
        HttpRequests request = new HttpRequests(null, null, _apiKey, interval, symbol);
        string responseJson = await request.GetTickerTimeSeries();
        return responseJson;
    }
}