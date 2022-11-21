namespace MainConsole;

public class Backtest
{
    public static async Task MacdStrategy(string _apiKey)
    {
        string macd = await GetFromApi.HttpRequestTech(_apiKey);
        string ema = await GetFromApi.HttpRequestTechTimePeriod(_apiKey);
        string timeSeries = await GetFromApi.HttpRequestTimeSeries(_apiKey);
    }
}