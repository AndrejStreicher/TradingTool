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
        if (fileName != null)
        {
            if (fileName.Contains(@"\"))
            {
                fileName = fileName.Replace(@"\", "-");
            }

            if (fileName.Contains(@"/"))
            {
                fileName = fileName.Replace(@"/", "-");
            }

            if (fileName.Contains("["))
            {
                fileName = fileName.Replace("[", "");
            }

            if (fileName.Contains("]"))
            {
                fileName = fileName.Replace("]", "");
            }

            if (fileName.Contains("'"))
            {
                fileName = fileName.Replace("'", "");
            }

            if (fileName.Contains(":"))
            {
                fileName = fileName.Replace(":", "-");
            }

            fileName = fileName.ToUpper();
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

                        foreach (SymbolLookupClass.Data data in rootSymbolLookupRoot.DataSets)
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
                            SinglePrice priceRoot =
                                JsonConvert.DeserializeObject<SinglePrice>(dataJson);
                            Console.WriteLine($"Price: {priceRoot.price}");

                            HelperMethods.ReturnToMenu();
                        }
                        else
                        {
                            CurrentPriceClass.Root priceRoot = JsonConvert.DeserializeObject<CurrentPriceClass.Root>(
                                dataJson);
                            foreach (CurrentPriceClass.Price price in priceRoot.Prices)
                            {
                                Console.WriteLine(price.price);
                                Console.ReadLine();
                            }

                            HelperMethods.ReturnToMenu();
                        }

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
                File.WriteAllText($@".\Downloaded data\{dataType}\{fileName}.json", jsonFormatted.ToString());
                Console.WriteLine("File written successfully!");
                HelperMethods.ReturnToMenu();
                break;
            case 2:
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