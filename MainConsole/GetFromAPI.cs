namespace MainConsole;

public class GetFromApi
{
    public static async Task<string> HttpRequestTech()
    {
        var techIndicator = UserInputs.GetTechnicalIndicator();
        var symbol = UserInputs.GetSymbolInput();
        var parameters = InputChecker.TechIndicatorParameterChecker(techIndicator);
        var startdate = UserInputs.GetStartdateInput();
        var enddate = UserInputs.GetEnddateInput();
        HttpRequests request =
            new HttpRequests(techIndicator, HelperMethods.ApiKey, parameters[0], symbol, startdate, enddate,
                parameters[1],
                parameters[2], parameters[3], parameters[4], parameters[5], parameters[6], parameters[7], parameters[8],
                parameters[9], parameters[10], parameters[11], parameters[12], parameters[13], parameters[14],
                parameters[15], parameters[16], parameters[17], parameters[18], parameters[19], parameters[20],
                parameters[21], parameters[22], parameters[23], parameters[24], parameters[25], parameters[26],
                parameters[27], parameters[28], parameters[29], parameters[30], parameters[31], parameters[32],
                parameters[33], parameters[34], parameters[35], parameters[36], parameters[37],
                parameters[39], parameters[40], parameters[41], parameters[42], parameters[43], parameters[44],
                parameters[45], parameters[46], parameters[47], parameters[48], parameters[49], parameters[50],
                parameters[51], parameters[52], parameters[53], parameters[54], parameters[55], parameters[56],
                parameters[57], parameters[58], parameters[59], parameters[60]);
        string responseJson = await request.ApiCall();
        return responseJson;
    }

    public static async Task<string> HttpRequestInfo(string? endpoint)
    {
        var symbol = UserInputs.GetSymbolInput();
        HttpRequests request = new HttpRequests(endpoint, HelperMethods.ApiKey, null, symbol, null, null, null, null,
            null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
            null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
            null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
            null, null, null);
        string responseJson = await request.ApiCall();
        return responseJson;
    }

    public static async Task<string> HttpRequestTimeSeries()
    {
        var symbol = UserInputs.GetSymbolInput();
        var interval = UserInputs.GetIntervalInput();
        var startdate = UserInputs.GetStartdateInput();
        var enddate = UserInputs.GetEnddateInput();
        HttpRequests request = new HttpRequests("time_series", HelperMethods.ApiKey, interval, symbol, startdate,
            enddate, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
            null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
            null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
            null, null, null, null, null, null, null);
        string responseJson = await request.ApiCall();
        return responseJson;
    }
}