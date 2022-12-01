namespace MainConsole;

using System.Threading.Tasks;

public class HttpRequests
{
    static readonly HttpClient Client = new HttpClient();
    private string? _endpoint;
    private string? _apiKey;
    private string? _interval;
    private string? _symbol;
    private string _timePeriod;
    private string? _startdate;
    private string? _enddate;

    public HttpRequests(params string?[] args)
    {
        _endpoint = args[0];
        _apiKey = $"?apikey={args[1]}";
        _interval = $"&interval={args[2]}";
        _symbol = $"&symbol={args[3]}";
        _startdate = $"&start_date={args[4]}";
        _enddate = $"&end_date={args[5]}";
        _timePeriod = args[6] ?? "9";
    }

    public async Task<string> ApiCall()
    {
        try
        {
            string responseBody =
                await Client.GetStringAsync(
                    $"https://api.twelvedata.com/{_endpoint}{_apiKey}{_interval}{_symbol}{_startdate}{_enddate}");
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