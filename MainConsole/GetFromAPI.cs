using Newtonsoft.Json;

namespace MainConsole;

public class GetFromApi
{
    private static string fileName;

    public static async Task HttpRequestTech()
    {
        fileName = "";
        string techIndicator = UserInputs.GetTechnicalIndicator();
        string symbol = UserInputs.GetSymbolInput();
        string interval = UserInputs.GetIntervalInput();
        string startdate = UserInputs.GetStartdateInput();
        if (startdate == "earliest" || startdate == "Earliest")
        {
            startdate = await HttpRequestEarliestTimestamp(symbol, interval);
        }

        string enddate = UserInputs.GetEnddateInput();
        string parameters = InputChecker.GetTechIndicatorParameters(techIndicator);
        string requestString = string.Concat(techIndicator, "?symbol=", symbol, "&apikey=", HelperMethods.ApiKey,
            "&start_date=", startdate, "&end_date=", enddate, parameters);
        HttpRequests request =
            new HttpRequests(requestString);
        string responseJson = await request.ApiCall();
        fileName = string.Concat(fileName, symbol, "_", techIndicator, "_", startdate, enddate);
        DataHandler.DataHandleJson(responseJson, "technicalIndicator", fileName);
    }

    public static async Task HttpRequestInfo(string? endpoint)
    {
        fileName = "";
        string symbol = UserInputs.GetSymbolInput();
        string requestString = string.Concat(endpoint, "?symbol=", symbol, "&apikey=", HelperMethods.ApiKey);
        HttpRequests request = new HttpRequests(requestString);
        string responseJson = await request.ApiCall();
        fileName = String.Concat(fileName, symbol, "_", endpoint);
        DataHandler.DataHandleJson(responseJson, endpoint, fileName);
    }

    public static async Task HttpRequestTimeSeries()
    {
        fileName = "";
        string symbol = UserInputs.GetSymbolInput();
        string interval = UserInputs.GetIntervalInput();
        string startdate = UserInputs.GetStartdateInput();
        if (startdate == "earliest" || startdate == "Earliest")
        {
            startdate = await HttpRequestEarliestTimestamp(symbol, interval);
        }

        string enddate = UserInputs.GetEnddateInput();
        string requestString = string.Concat("time_series?symbol=", symbol, "&apikey=", HelperMethods.ApiKey,
            "&interval=", interval, "&start_date=", startdate, "&end_date=", enddate);
        HttpRequests request = new HttpRequests(requestString);
        string responseJson = await request.ApiCall();
        fileName = String.Concat(fileName, symbol, "_", interval, "_", startdate, "_", enddate);
        DataHandler.DataHandleJson(responseJson, "timeSeries", fileName);
    }

    public static async Task HttpRequestLookup()
    {
        fileName = "";
        string symbol = UserInputs.GetLookupSymbol();
        string requestString = $"symbol_search?symbol={symbol}";
        HttpRequests request = new HttpRequests(requestString);
        string responseJson = await request.ApiCall();
        fileName = $"SEARCH={symbol}";
        DataHandler.DataHandleJson(responseJson, "symbolLookup", fileName);
    }

    public static async Task<string> HttpRequestEarliestTimestamp(string symbol, string interval)
    {
        string requestString = $"earliest_timestamp?symbol={symbol}&interval={interval}&apikey={HelperMethods.ApiKey}";
        HttpRequests request = new HttpRequests(requestString);
        string responseJson = await request.ApiCall();
        EarliestTimestampClass earliestTimestamp = JsonConvert.DeserializeObject<EarliestTimestampClass>(responseJson);
        return earliestTimestamp.datetime.ToString("yyyy-MM-dd");
    }
}