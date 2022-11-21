using Newtonsoft.Json.Linq;

namespace MainConsole;

public static class JsonHandler
{
    public static void PrintJson(string dataJson, string dataType)
    {
        if (dataType == "price")
        {
            var price = JObject.Parse(dataJson);
            Console.WriteLine($"Price: {price["price"]}");
            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey(true);
        }
        else if (dataType == "time-series")
        {
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
    }
}