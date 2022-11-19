﻿namespace MainConsole;

using System.Threading.Tasks;

public class HttpRequests
{
    static readonly HttpClient client = new HttpClient();
    private string _responseBody;
    private string _techIndicator;
    private string _endpoint = null;
    private string _apiKey;
    private string _interval;
    private string _symbol;

    public HttpRequests(string techIndicator, string endpoint, string apiKey, string interval, string symbol)
    {
        _techIndicator = techIndicator;
        _endpoint = endpoint;
        _apiKey = apiKey;
        _interval = interval;
        _symbol = symbol;
    }

    public async Task<string> GetTechnicalIndicator()
    {
        try
        {
            _responseBody =
                await client.GetStringAsync(
                    $"https://api.twelvedata.com/{_techIndicator}?apikey={_apiKey}&interval={_interval}&symbol={_symbol}");
            // Console.WriteLine(responseBody);
            return _responseBody;
        }
        catch (HttpRequestException error)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", error.Message);
            return error.Message;
        }
    }

    public async Task<string> GetTickerInfo()
    {
        try
        {
            _responseBody =
                await client.GetStringAsync(
                    $"https://api.twelvedata.com/{_endpoint}?apikey={_apiKey}&symbol={_symbol}");
            return _responseBody;
        }
        catch (HttpRequestException error)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ",error.Message);
            return error.Message;
        }
    }
    public async Task<string> GetTickerTimeSeries()
    {
        try
        {
            _responseBody =
                await client.GetStringAsync(
                    $"https://api.twelvedata.com/time_series?apikey={_apiKey}&symbol={_symbol}&interval={_interval}");
            return _responseBody;
        }
        catch (HttpRequestException error)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ",error.Message);
            return error.Message;
        }
    }
}