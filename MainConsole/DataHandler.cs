using Newtonsoft.Json.Linq;
using Aspose.Cells;
using Aspose.Cells.Utility;

namespace MainConsole;

public class DataHandler
{
    public static void DataHandleJson(string dataJson, string dataType)
    {
        var jsonFormatted = JObject.Parse(dataJson);
        string? fileName = "";
        if (dataType == "price")
        {
            Console.WriteLine("Enter symbol name:");
            fileName = Console.ReadLine();
        }
        else if (dataType == "timeSeries")
        {
            int valuesLength = jsonFormatted["values"].Count();
            fileName =
                $"{jsonFormatted["meta"]?["symbol"]}_{jsonFormatted["meta"]?["interval"]}_{jsonFormatted["values"]?[valuesLength - 1]?["datetime"]}_{jsonFormatted["values"]?[0]?["datetime"]}";
        }
        else if (dataType == "quote")
        {
            fileName = $"{jsonFormatted["symbol"]}_{jsonFormatted["datetime"]}";
        }
        else if (dataType == "technicalIndicator")
        {
            int valuesLength = jsonFormatted["values"].Count();
            fileName =
                $"{jsonFormatted["meta"]?["symbol"]}_{jsonFormatted["meta"]?["interval"]}_{jsonFormatted["values"]?[valuesLength - 1]?["datetime"]}_{jsonFormatted["values"]?[0]?["datetime"]}";
        }

        if (fileName != null && fileName.Contains(@"\"))
        {
            fileName = fileName.Replace(@"\", "-");
        }
        else if (fileName != null && fileName.Contains(@"/"))
        {
            fileName = fileName.Replace(@"/", "-");
        }

        if (fileName != null && fileName.Contains(":"))
        {
            fileName = fileName.Replace(":", "-");
        }

        string promptData = "How would you like to export your data ?";
        string[] optionsData = { "Print to console", "Download as JSON", "Download as CSV" };
        Menu dataMenu = new Menu(promptData, optionsData);
        int selectedIndex = dataMenu.CreateMenu();
        switch (selectedIndex)
        {
            case 0:
                Console.Clear();
                Console.WriteLine(jsonFormatted);
                HelperMethods.ReturnToMenu();
                break;
            case 1:
                File.WriteAllText($@".\Data\{dataType}\{fileName}.json", jsonFormatted.ToString());
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
                workbook.Save($@".\Data\{dataType}\{fileName}.csv", SaveFormat.Csv);
                Console.WriteLine("File written successfully!");
                HelperMethods.ReturnToMenu();
                break;
        }
    }
}