﻿namespace MainConsole;

public class GetFromApi
{
    public static async Task<string> HttpRequestTech(string apiKey)
    {
        var techIndicator = UserInputs.GetTechnicalIndicator();
        var symbol = UserInputs.GetSymbolInput();
        var interval = UserInputs.GetIntervalInput();
        var startdate = UserInputs.GetStartdateInput();
        var enddate = UserInputs.GetEnddateInput();
        HttpRequests request =
            new HttpRequests(techIndicator, apiKey, interval, symbol, startdate, enddate, null);
        string responseJson = await request.APICall();
        return responseJson;
    }

    public static async Task<string> HttpRequestTechTimePeriod(string apiKey)
    {
        var techIndicator = UserInputs.GetTechnicalIndicator();
        var symbol = UserInputs.GetSymbolInput();
        var interval = UserInputs.GetIntervalInput();
        var startdate = UserInputs.GetStartdateInput();
        var enddate = UserInputs.GetEnddateInput();
        var timePeriod = UserInputs.GetTimePeriodInput();
        HttpRequests request =
            new HttpRequests(techIndicator, apiKey, interval, symbol, startdate, enddate, timePeriod);
        string responseJson = await request.APICall();
        return responseJson;
    }

    public static async Task<string> HttpRequestInfo(string apiKey, string endpoint)
    {
        var symbol = UserInputs.GetSymbolInput();
        HttpRequests request = new HttpRequests(endpoint, apiKey, null, symbol, null, null, null);
        string responseJson = await request.APICall();
        return responseJson;
    }

    public static async Task<string> HttpRequestTimeSeries(string apiKey)
    {
        var symbol = UserInputs.GetSymbolInput();
        var interval = UserInputs.GetIntervalInput();
        var startdate = UserInputs.GetStartdateInput();
        var enddate = UserInputs.GetEnddateInput();
        HttpRequests request = new HttpRequests("time_series", apiKey, interval, symbol, startdate, enddate, null);
        string responseJson = await request.APICall();
        return responseJson;
    }
}