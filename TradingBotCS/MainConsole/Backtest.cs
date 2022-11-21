namespace MainConsole;

public class Backtest
{
    public static async Task MacdStrategy(string _apiKey)
    {
        Console.WriteLine("Enter symbol: ");
        var symbol = Console.ReadLine();
        Console.WriteLine("Enter interval: ");
        var interval = Console.ReadLine();
        Console.WriteLine("Enter start-date (2000-12-31|or|2000-12-31 24-59-59):");
        var startdate = Console.ReadLine();
        Console.WriteLine("Enter end-date (2000-12-31|or|2000-12-31 24-59-59):");
        var enddate = Console.ReadLine();
        HttpRequests macdRequest =
            new HttpRequests("macd", null, _apiKey, interval, symbol, null, startdate, enddate);
        HttpRequests emaRequest =
            new HttpRequests("ema", null, _apiKey, interval, symbol, "200", startdate, enddate);
        HttpRequests timeSeriesRequest =
            new HttpRequests(null, null, _apiKey, interval, symbol, null, startdate, enddate);
        string macd = await macdRequest.GetTechnicalIndicator();
        string ema = await emaRequest.GetTechnicalIndicatorTimePeriod();
        string timeSeries = await timeSeriesRequest.GetTickerTimeSeries();
    }
}