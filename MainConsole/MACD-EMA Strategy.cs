using Newtonsoft.Json.Linq;

namespace MainConsole;

public class MACD_EMA_Strategy
{
    public static async Task MacdEmaStrategy(string apikey)
    {
        var symbol = UserInputs.GetSymbolInput();
        var interval = UserInputs.GetIntervalInput();
        var startdate = UserInputs.GetStartdateInput();
        var enddate = UserInputs.GetEnddateInput();
        HttpRequests macdRequest =
            new HttpRequests("macd",apikey, interval, symbol, startdate, enddate,null);
        HttpRequests emaRequest =
            new HttpRequests("ema", apikey, interval, symbol, startdate, enddate,"200");
        HttpRequests timeSeriesRequest =
            new HttpRequests("time_series", apikey, interval, symbol, startdate, enddate,null);
        string macdTemp = await macdRequest.ApiCall();
        string emaTemp = await emaRequest.ApiCall();
        string timeSeriesTemp = await timeSeriesRequest.ApiCall();
        var macd = JObject.Parse(macdTemp);
        var ema = JObject.Parse(emaTemp);
        var timeSeries = JObject.Parse(timeSeriesTemp);
        int macdLength = macd["values"].Count();
        int emaLength = ema["values"].Count();
        int timeSeriesLength = timeSeries["values"].Count();
        int dataLength = macdLength;
        if (macdLength != emaLength || emaLength != timeSeriesLength ||
            timeSeriesLength != macdLength)
        {
            Console.WriteLine("JSON lengths don't match!");
            HelperMethods.ReturnToMenu();
        }
        else
        {
            for (int i = dataLength - 1; i >= 0; i--)
            {
                if ((Convert.ToDouble(macd["values"]?[i]?["macd"]) < 0
                     && Convert.ToDouble(macd["values"]?[i]?["macd_signal"]) < 0
                     && (Convert.ToDouble(macd["values"]?[i]?["macd"]) >
                         Convert.ToDouble(macd["values"]?[i]?["macd_signal"]))
                     && (Convert.ToDouble(timeSeries["values"]?[i]?["close"]) >
                         Convert.ToDouble(ema["values"]?[i]?["ema"]) && Backtest.BuyingLong == false))
                   )
                {
                    if (Backtest.SellingShort == true)
                    {
                        Backtest.SellingShort = false;
                        Backtest.LongBuy((macd["values"][i]["datetime"]).ToString());
                    }
                    else
                    {
                        Backtest.LongBuy((macd["values"][i]["datetime"]).ToString());
                    }
                }
                else if ((Convert.ToDouble(macd["values"][i]["macd"]) > 0
                          && Convert.ToDouble(macd["values"][i]["macd_signal"]) > 0
                          && (Convert.ToDouble(macd["values"][i]["macd"]) <
                              Convert.ToDouble(macd["values"][i]["macd_signal"]))
                          && (Convert.ToDouble(timeSeries["values"][i]["close"]) <
                              Convert.ToDouble(ema["values"][i]["ema"]) && Backtest.SellingShort == false)))
                {
                    if (Backtest.BuyingLong == true)
                    {
                        Backtest.BuyingLong = false;
                        Backtest.ShortSell((macd["values"][i]["datetime"]).ToString());
                    }
                    else
                    {
                        Backtest.ShortSell((macd["values"][i]["datetime"]).ToString());
                    }
                }
            }

            HelperMethods.ReturnToMenu();
        }
    }
}