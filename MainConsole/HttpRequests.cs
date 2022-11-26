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
        _apiKey = args[1];
        _interval = args[2];
        _symbol = args[3];
        _startdate = args[4];
        _enddate = args[5];
        _timePeriod = args[6] ?? "9";
    }

    public async Task<string> ApiCall()
    {
        try
        {
            string responseBody =
                await Client.GetStringAsync(
                    $"https://api.twelvedata.com/{_endpoint}?apikey={_apiKey}&interval={_interval}&symbol={_symbol}&start_date={_startdate}&end_date={_enddate}&time_period={_timePeriod}");
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