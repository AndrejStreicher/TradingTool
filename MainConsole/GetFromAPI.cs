namespace MainConsole;

public class GetFromApi
{
    public static async Task<string> HttpRequestTech()
    {
        string techIndicator = UserInputs.GetTechnicalIndicator();
        string symbol = UserInputs.GetSymbolInput();
        string startdate = UserInputs.GetStartdateInput();
        string enddate;
        if (startdate != "earliest")
        {
            enddate = UserInputs.GetEnddateInput();
        }
        else
        {
            enddate = "";
        }

        string parameters = InputChecker.TechIndicatorParameterChecker(techIndicator);
        string requestString = string.Concat(techIndicator, "?symbol=", symbol, "&apikey=", HelperMethods.ApiKey,
            "&start_date=", startdate, "&end_date=", enddate, parameters);
        HttpRequests request =
            new HttpRequests(requestString);
        string responseJson = await request.ApiCall();
        return responseJson;
    }

    public static async Task<string> HttpRequestInfo(string? endpoint)
    {
        var symbol = UserInputs.GetSymbolInput();
        string requestString = string.Concat(endpoint, "?symbol=", symbol, "&apikey=", HelperMethods.ApiKey);
        HttpRequests request = new HttpRequests(requestString);
        string responseJson = await request.ApiCall();
        return responseJson;
    }

    public static async Task<string> HttpRequestTimeSeries()
    {
        var symbol = UserInputs.GetSymbolInput();
        var interval = UserInputs.GetIntervalInput();
        var startdate = UserInputs.GetStartdateInput();
        string enddate;
        if (startdate != "earliest")
        {
            enddate = UserInputs.GetEnddateInput();
        }
        else
        {
            enddate = "";
        }

        string requestString = string.Concat("time_series?symbol=", symbol, "&apikey=", HelperMethods.ApiKey,
            "&interval=", interval, "&start_date=", startdate, "&end_date=", enddate);
        HttpRequests request = new HttpRequests(requestString);
        string responseJson = await request.ApiCall();
        return responseJson;
    }
}