using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MainConsole;

public class DataHandler
{
    public static void DataHandle(string dataJson)
    {
        string promptData = "How would you like to export your data ?";
        string[] optionsData = { "Print to console", "Download as JSON", "Download as CSV" };
        Menu dataMenu = new Menu(promptData, optionsData);
        int selectedIndex = dataMenu.CreateMenu();
        switch (selectedIndex)
        {
            case 0:
                Console.Clear();
                string jsonFormatted = JValue.Parse(dataJson).ToString(Formatting.Indented);
                Console.WriteLine(jsonFormatted);
                Console.WriteLine("Press any key to return to main menu...");
                Console.ReadKey(true);
                break;
            case 1:
                Console.Clear();
                int i = 0;
                string jsonFormattedDownload = JValue.Parse(dataJson).ToString(Formatting.Indented);
                if (File.Exists($@".\Data\Export{i}.json"))
                {
                    i++;
                }
                else
                {
                    File.WriteAllText($@".\Data\Export{i}.json", jsonFormattedDownload);
                }

                break;
            case 2:
                break;
        }
    }
}