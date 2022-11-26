using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MainConsole;

public class DataHandler
{
    public static void DataHandle(string dataJson, string dataType)
    {
        var jsonFormatted = JObject.Parse(dataJson);
        string fileName = "";
        if (dataType == "price")
        {
            Console.WriteLine("Enter symbol name:");
            fileName = Console.ReadLine();
        }
        else if (dataType == "timeSeries")
        {
            fileName = $"{jsonFormatted["meta"]["symbol"]}-{jsonFormatted["meta"]["interval"]}";
        }
        else if (dataType == "quote")
        {
            fileName = $"{jsonFormatted["symbol"]}-{jsonFormatted["datetime"]}";
        }
        else if (dataType == "technicalIndicator")
        {
            fileName = $"{jsonFormatted["meta"]["symbol"]}-{jsonFormatted["meta"]["interval"]}";
        }

        if (fileName.Contains(@"\"))
        {
            fileName = fileName.Replace(@"\", "-");
        }
        else if (fileName.Contains(@"/"))
        {
            fileName = fileName.Replace(@"/", "-");
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
                Console.Clear();
                File.WriteAllText($@".\Data\{dataType}\{fileName}.json", jsonFormatted.ToString());
                Console.WriteLine("File written successfully!");
                HelperMethods.ReturnToMenu();
                break;
            case 2:
                break;
        }
    }
}