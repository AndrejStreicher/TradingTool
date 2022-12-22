namespace MainConsole;

using System.Threading.Tasks;

public class HttpRequests
{
    static readonly HttpClient Client = new HttpClient();
    private static string _request;

    public HttpRequests(string request)
    {
        _request = request;
    }

    public async Task<string> ApiCall()
    {
        try
        {
            string responseBody =
                await Client.GetStringAsync(
                    $"https://api.twelvedata.com/{_request}");
            return responseBody;
        }
        catch (HttpRequestException error)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", error.Message);
            return error.Message;
        }
    }
}