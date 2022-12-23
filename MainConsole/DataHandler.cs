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