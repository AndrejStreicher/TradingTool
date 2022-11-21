using Newtonsoft.Json.Linq;

namespace MainConsole;

public static class JsonHandler
{
    public static void PrintJson(string dataJson, string dataType)
    {
        if (dataType == "price")
        {
            Console.Clear();
            var price = JObject.Parse(dataJson);
            Console.WriteLine($"Price: {price["price"]}");
            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey(true);
        }
        else if (dataType == "time-series")
        {
            Console.Clear();
            var timeSeries = JObject.Parse(dataJson);
            for (int i = 0; i < timeSeries["values"].Count(); i++)
            {
                Console.WriteLine($"Date-time: {timeSeries["values"][i]["datetime"]}");
                Console.WriteLine($"Open: {timeSeries["values"][i]["open"]}");
                Console.WriteLine($"High: {timeSeries["values"][i]["high"]}");
                Console.WriteLine($"Low: {timeSeries["values"][i]["low"]}");
                Console.WriteLine($"Close: {timeSeries["values"][i]["close"]}");
                Console.WriteLine($"Volume: {timeSeries["values"][i]["volume"]}\n");
            }

            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey(true);
        }
        else if (dataType == "quote")
        {
            var quote = JObject.Parse(dataJson);
            {
                Console.Clear();
                Console.WriteLine($"Symbol: {quote["symbol"]}");
                Console.WriteLine($"Name: {quote["name"]}");
                Console.WriteLine($"Exchange: {quote["exchange"]}");
                Console.WriteLine($"MIC code: {quote["mic_code"]}");
                Console.WriteLine($"Currency: {quote["currency"]}");
                Console.WriteLine($"Date-time: {quote["datetime"]}");
                Console.WriteLine($"Unix timestamp: {quote["timestamp"]}");
                Console.WriteLine($"Open: {quote["open"]}");
                Console.WriteLine($"High: {quote["high"]}");
                Console.WriteLine($"Close: {quote["close"]}");
                Console.WriteLine($"Volume: {quote["volume"]}");
                Console.WriteLine($"Previous close: {quote["previous_close"]}");
                Console.WriteLine($"Change: {quote["change"]}");
                Console.WriteLine($"Percent change: {quote["percent_change"]}");
                Console.WriteLine($"Average volume: {quote["average_volume"]}");
                Console.WriteLine($"Is the market open ?: {quote["is_market_open"]}");
                Console.WriteLine($"Fifty two week average:\n");
                Console.WriteLine($"Low: {quote["fifty_two_week"]["low"]}");
                Console.WriteLine($"High: {quote["fifty_two_week"]["high"]}");
                Console.WriteLine($"Low change: {quote["fifty_two_week"]["low_change"]}");
                Console.WriteLine($"High change: {quote["fifty_two_week"]["high_change"]}");
                Console.WriteLine($"Low change percent: {quote["fifty_two_week"]["low_change_percent"]}");
                Console.WriteLine($"High change percent: {quote["fifty_two_week"]["high_change_percent"]}");
                Console.WriteLine($"Range: {quote["fifty_two_week"]["range"]}");
                Console.WriteLine("Press any key to return to main menu...");
                Console.ReadKey(true);
            }
        }
    }
}