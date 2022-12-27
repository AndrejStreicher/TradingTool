using Aspose.Cells;
using Aspose.Cells.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MainConsole;

public class DataHandler
{
    public static void DataHandleJson(string dataJson, string dataType, string fileName)
    {
        JObject jsonFormatted = JObject.Parse(dataJson);
        if (jsonFormatted.Properties().First().Name == "code")
        {
            ErrorHandling.ErrorHandle(jsonFormatted, dataJson);
            return;
        }

        switch (dataType)
        {
            case "symbolLookup":
                JArray array = (JArray)jsonFormatted.SelectToken("data");

                if (array.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("No symbol found!");
                    HelperMethods.ReturnToMenu();
                    return;
                }

                break;
        }

        var promptData = "How would you like to export your data ?";
        string[] optionsData = { "Print to console", "Download as JSON", "Download as CSV" };
        var dataMenu = new Menu(promptData, optionsData);
        var selectedIndex = dataMenu.CreateMenu();
        switch (selectedIndex)
        {
            case 0:
                Console.Clear();
                switch (dataType)
                {
                    case "symbolLookup":
                        SymbolLookupClass.Root rootSymbolLookupRoot =
                            JsonConvert.DeserializeObject<SymbolLookupClass.Root>(dataJson);

                        foreach (SymbolLookupClass.Data data in rootSymbolLookupRoot.Data)
                        {
                            Console.WriteLine($"Symbol:            {data.Symbol}");
                            Console.WriteLine($"Instrument name:   {data.Instrument_Name}");
                            Console.WriteLine($"Exchange:          {data.Exchange}");
                            Console.WriteLine($"Mic code:          {data.Mic_Code}");
                            Console.WriteLine($"Exchange timezone: {data.Exchange_Timezone}");
                            Console.WriteLine($"Instrument type:   {data.Instrument_Type}");
                            Console.WriteLine($"Country:           {data.Country}");
                            Console.WriteLine($"Currency:          {data.Currency}");
                            Console.WriteLine();
                        }

                        HelperMethods.ReturnToMenu();
                        break;
                    case "price":
                        if (jsonFormatted.Properties().First().Name == "price")
                        {
                            SinglePriceClass priceClassRoot =
                                JsonConvert.DeserializeObject<SinglePriceClass>(dataJson);
                            Console.WriteLine($"Price: {priceClassRoot.price}");
                            HelperMethods.ReturnToMenu();
                        }
                        else
                        {
                            Dictionary<string, MultiplePricesClass.Price> priceRoot =
                                JsonConvert.DeserializeObject<Dictionary<string, MultiplePricesClass.Price>>(dataJson);
                            foreach (KeyValuePair<string, MultiplePricesClass.Price> price in priceRoot)
                            {
                                Console.WriteLine($"{price.Key.ToUpper()}:  {price.Value.price}");
                            }

                            HelperMethods.ReturnToMenu();
                        }

                        break;
                    case "timeSeries":
                        Console.Clear();
                        TimeSeriesClass.TimeSeriesRoot timeSeriesRoot =
                            JsonConvert.DeserializeObject<TimeSeriesClass.TimeSeriesRoot>(dataJson);
                        Console.WriteLine($"Symbol:             {timeSeriesRoot.Meta.symbol}");
                        Console.WriteLine($"Interval:           {timeSeriesRoot.Meta.interval}");
                        if (timeSeriesRoot.Meta.currency != null)
                        {
                            Console.WriteLine($"Currency:           {timeSeriesRoot.Meta.currency}");
                        }

                        if (timeSeriesRoot.Meta.exchange_timezone != null)
                        {
                            Console.WriteLine($"Exchange timezone:  {timeSeriesRoot.Meta.exchange_timezone}");
                        }

                        if (timeSeriesRoot.Meta.exchange != null)
                        {
                            Console.WriteLine($"Exchange:           {timeSeriesRoot.Meta.exchange}");
                        }

                        if (timeSeriesRoot.Meta.mic_code != null)
                        {
                            Console.WriteLine($"Mic code:           {timeSeriesRoot.Meta.mic_code}");
                        }

                        if (timeSeriesRoot.Meta.currency_base != null)
                        {
                            Console.WriteLine($"Currency base:      {timeSeriesRoot.Meta.currency_base}");
                        }

                        if (timeSeriesRoot.Meta.currency_quote != null)
                        {
                            Console.WriteLine($"Currency quote:     {timeSeriesRoot.Meta.currency_quote}");
                        }

                        Console.WriteLine($"Type:               {timeSeriesRoot.Meta.type}");
                        Console.WriteLine();
                        foreach (TimeSeriesClass.Value values in timeSeriesRoot.Values)
                        {
                            Console.WriteLine($"Datetime:       {values.datetime}");
                            Console.WriteLine($"Open:           {values.open}");
                            Console.WriteLine($"High:           {values.high}");
                            Console.WriteLine($"Low:            {values.low}");
                            Console.WriteLine($"Close:          {values.close}");
                            if (values.volume != null)
                            {
                                Console.WriteLine($"Volume:         {values.volume}");
                            }

                            Console.WriteLine();
                        }

                        HelperMethods.ReturnToMenu();
                        break;
                    default:
                        var jsonReader = jsonFormatted.CreateReader();
                        while (jsonReader.Read())
                        {
                            if (jsonReader.TokenType == JsonToken.PropertyName)
                            {
                                var propertyName = jsonReader.Value.ToString();
                                propertyName = propertyName.Replace("_", " ");
                                propertyName = char.ToUpper(propertyName[0]) + propertyName.Substring(1);
                                Console.Write(propertyName + ": ");
                            }

                            if (jsonReader.TokenType == JsonToken.String || jsonReader.TokenType == JsonToken.Float ||
                                jsonReader.TokenType == JsonToken.Integer || jsonReader.TokenType == JsonToken.Boolean)
                                Console.WriteLine(jsonReader.Value);

                            if (jsonReader.Value == null) Console.WriteLine();
                        }

                        HelperMethods.ReturnToMenu();
                        break;
                }

                break;
            case 1:
                fileName = HelperMethods.FormatFilename(fileName);
                File.WriteAllText($@".\Downloaded data\{dataType}\{fileName}.json", jsonFormatted.ToString());
                Console.WriteLine("File written successfully!");
                HelperMethods.ReturnToMenu();
                break;
            case 2:
                fileName = HelperMethods.FormatFilename(fileName);
                var workbook = new Workbook();
                var worksheet = workbook.Worksheets[0];
                var layoutOptions = new JsonLayoutOptions();
                layoutOptions.ConvertNumericOrDate = true;
                layoutOptions.ArrayAsTable = true;
                layoutOptions.IgnoreArrayTitle = true;
                layoutOptions.IgnoreObjectTitle = true;
                layoutOptions.ArrayAsTable = true;
                JsonUtility.ImportData(jsonFormatted["values"]?.ToString(), worksheet.Cells, 0, 0, layoutOptions);
                workbook.Save($@".\Downloaded data\{dataType}\{fileName}.csv", SaveFormat.Csv);
                Console.WriteLine("File written successfully!");
                HelperMethods.ReturnToMenu();
                break;
        }
    }
}