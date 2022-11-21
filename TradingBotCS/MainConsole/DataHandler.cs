

namespace MainConsole;

public class DataHandler
{
    public static void DataHandle(string dataJson, string dataType)
    {
        string promptData = "How would you like to export your data ?";
        string[] optionsData = { "Print to console", "Download as JSON", "Download as CSV" };
        Menu dataMenu = new Menu(promptData, optionsData);
        int selectedIndex = dataMenu.Run();
        switch (selectedIndex)
        {
            case 0:
                JsonHandler.PrintJson(dataJson,dataType);
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }
}