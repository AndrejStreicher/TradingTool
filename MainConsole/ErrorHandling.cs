using Newtonsoft.Json.Linq;

namespace MainConsole;

using Newtonsoft.Json;

public class ErrorHandling
{
    public static void ErrorHandle(JObject jsonFormatted, string dataJson)
    {
        Console.Clear();
        ErrorMessageClass errorMessage = JsonConvert.DeserializeObject<ErrorMessageClass>(dataJson);
        Console.WriteLine($"Error Code: {errorMessage.code}");
        switch (errorMessage.code)
        {
            case 400:
                Console.WriteLine("There is an error with one or multiple parameters.");
                break;
            case 401:
                Console.WriteLine("Your API key is wrong or not valid.");
                break;
            case 403:
                Console.WriteLine(
                    "Your API key is valid but has no permissions to make request available on the upper plans.");
                break;
            case 404:
                Console.WriteLine("The specified data can not be found.");
                break;
            case 414:
                Console.WriteLine("The parameter which accepts multiple values is out of range.");
                break;
            case 429:
                Console.WriteLine("You've reached your API request limits.");
                break;
            case 500:
                Console.WriteLine("There is an error on the server-side. Try again later.");
                break;
        }

        Console.WriteLine(errorMessage.message);
        HelperMethods.ReturnToMenu();
        return;
    }
}