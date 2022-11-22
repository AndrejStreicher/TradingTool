using Newtonsoft.Json.Linq;

namespace MainConsole;

public class Backtest
{
    private bool BuyLong;
    private bool ShortSell;
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
        string macdTemp = await macdRequest.GetTechnicalIndicator();
        string emaTemp = await emaRequest.GetTechnicalIndicatorTimePeriod();
        string timeSeriesTemp = await timeSeriesRequest.GetTickerTimeSeries();
        var macd = JObject.Parse(macdTemp);
        var ema = JObject.Parse(emaTemp);
        var timeSeries = JObject.Parse(timeSeriesTemp);
        if (macd["values"].Count() != ema["values"].Count() || ema["values"].Count() != timeSeries["values"].Count() ||
            timeSeries["values"].Count() != macd["values"].Count())
        {
            Console.WriteLine("JSON lengths don't match!");
            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey(true);
        }
        else
        {
        }
    }
}