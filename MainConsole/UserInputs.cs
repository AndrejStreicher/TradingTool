using System.Net.Http.Json;
using System.Text.Json.Nodes;
using Newtonsoft.Json;

namespace MainConsole;

public class UserInputs
{
    public static string GetIntervalInput()
    {
        string interval;
        Console.WriteLine("Intervals: ");
        for (var i = 0; i < InputChecker.Intervals.Length; i++) Console.Write($"{InputChecker.Intervals[i]} ");

        Console.WriteLine("");
        do
        {
            Console.WriteLine("Enter interval: ");
            interval = Console.ReadLine() ?? string.Empty;
            switch (interval)
            {
                case "minute":
                case "min":
                case "one minute":
                case "1 min":
                case "1 minute":
                case "1minute":
                    interval = "1min";
                    break;
                case "5 minutes":
                case "5minutes":
                case "5 min":
                case "five minutes":
                    interval = "5min";
                    break;
                case "15 minutes":
                case "15minutes":
                case "15 min":
                case "fifteen minutes":
                    interval = "15min";
                    break;
                case "30 minutes":
                case "30minutes":
                case "30 min":
                case "thirty minutes":
                    interval = "30min";
                    break;
                case "45 minutes":
                case "45minutes":
                case "45 min":
                case "fortyfive minutes":
                case "forty-five minutes":
                    interval = "45min";
                    break;
                case "hour":
                case "h":
                case "one hour":
                case "1 hour":
                case "1hour":
                    interval = "1h";
                    break;
                case "2hours":
                case "2 hours":
                case "two hours":
                    interval = "2h";
                    break;
                case "4hours":
                case "4 hours":
                case "four hours":
                    interval = "4h";
                    break;
                case "1d":
                case "1 day":
                case "one day":
                    interval = "1day";
                    break;
                case "1 week":
                case "1w":
                case "one week":
                    interval = "1week";
                    break;
                case "1 month":
                case "one month":
                    interval = "1month";
                    break;
            }

            if (interval == string.Empty)
                Console.WriteLine("Interval required!");
            else if (InputChecker.Intervals.Contains(interval) == false)
                Console.WriteLine("Unknown interval!");
        } while (InputChecker.Intervals.Contains(interval) == false);

        return interval;
    }

    public static string GetSymbolInput()
    {
        Console.WriteLine("Enter one or more symbols: ");
        string symbols = Console.ReadLine();
        if (symbols.Contains(" "))
        {
            symbols = symbols.Replace(" ", ",");
        }

        return symbols;
    }

    public static string GetLookupSymbol()
    {
        Console.WriteLine("Enter symbol for lookup. Try to type it as precisely as possible:");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetStartdateInput()
    {
        Console.WriteLine(
            "Enter start-date.\nPossible inputs:\n2000-12-31\n2000-12-31 24-59-59\nEarliest - for the earliest possible start-date:");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetEnddateInput()
    {
        Console.WriteLine(
            "Enter start-date.\nPossible inputs:\n2000-12-31\n2000-12-31 24-59-59:");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetTimePeriodInput(string number)
    {
        if (number == "0")
            Console.WriteLine("Enter time-period: ");
        else
            Console.WriteLine($"Enter time-period number {number}: ");

        return Console.ReadLine() ?? string.Empty;
    }

    public static string? GetTechnicalIndicator()
    {
        string? techIndicator;
        Console.WriteLine("Technical indicators: ");
        for (var i = 0; i < InputChecker.AllTechIndicators.Length; i++)
            Console.Write($"{InputChecker.AllTechIndicators[i]} ");

        Console.WriteLine("");
        do
        {
            Console.WriteLine("Enter technical indicator: ");
            techIndicator = Console.ReadLine() ?? string.Empty;
            techIndicator = techIndicator.ToLower();
            if (techIndicator.Contains(" ")) techIndicator = techIndicator.Replace(" ", "_");

            if (techIndicator == string.Empty)
                Console.WriteLine("Technical indicator required!");
            else if (InputChecker.AllTechIndicators.Contains(techIndicator) == false)
                Console.WriteLine("Unknown technical indicator!");
        } while (InputChecker.AllTechIndicators.Contains(techIndicator) == false);

        return techIndicator;
    }

    public static string GetSeriesType(string number)
    {
        Console.WriteLine(number == "0"
            ? "Series type (close|open|high|low|volume): "
            : $"Series type number {number} (close|open|high|low|volume): ");

        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetFastPeriod()
    {
        Console.WriteLine("Fast period (1 to 800): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetSlowPeriod()
    {
        Console.WriteLine("Slow period (1 to 800): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetMaType()
    {
        Console.WriteLine("Moving average type (ema,sma,ma): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetFastMaType()
    {
        Console.WriteLine("Fast moving average type (ema,sma,ma): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetSlowMaType()
    {
        Console.WriteLine("Slow moving average type (ema,sma,ma): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetSignalMaType()
    {
        Console.WriteLine("Signal moving average type (ema,sma,ma): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetLongRocPeriod()
    {
        Console.WriteLine("Long ROC period (1 to 800): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetShortRocPeriod()
    {
        Console.WriteLine("Short ROC period (1 to 800): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetWma()
    {
        Console.WriteLine("Weighted moving average (1 to 800): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetSd()
    {
        Console.WriteLine("Standard deviations (at least 1): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetPercentRankPeriod()
    {
        Console.WriteLine("Number of periods to calculate PercentRank (1 to 800): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetRsiPeriod()
    {
        Console.WriteLine("Number of period for RSI to calculate price momentum (1 to 800): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetUpDownLength()
    {
        Console.WriteLine("Number of periods for RSI used to calculate up/down trend (1 to 800): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetCentered()
    {
        Console.WriteLine("Specifies if there should be a shift to match the current price (true or false): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetBaseLinePeriod()
    {
        Console.WriteLine("Base line period (1 to 800): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetConversionLinePeriod()
    {
        Console.WriteLine("Conversion line period (1 to 800): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetIncludeAheadSpanPeriod()
    {
        Console.WriteLine(
            " Specifies if the span values ahead the current moment should be returned (true or false): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetLaggingSpanPeriod()
    {
        Console.WriteLine("Lagging span period (1 to 800): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetLeadingSpanBPeriod()
    {
        Console.WriteLine("Lagging span B period (1 to 800): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetMultiplier()
    {
        Console.WriteLine("Get multiplier: ");
        return Console.ReadLine() ?? string.Empty;
    }


    public static string GetRocPeriod(string number)
    {
        Console.WriteLine($"Rate of change period number {number} (1 to 800): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetSignalPeriod()
    {
        Console.WriteLine("Signal period number (1 to 800): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetSmaPeriod(string number)
    {
        Console.WriteLine($"Simple moving average period number {number} (1 to 800): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetFastLimit()
    {
        Console.WriteLine("Fast limit: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetSlowLimit()
    {
        Console.WriteLine("Slow limit: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetAcceleration()
    {
        Console.WriteLine("Acceleration: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetMaximum()
    {
        Console.WriteLine("Maximum: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetAccelerationLimitLong()
    {
        Console.WriteLine("Acceleration limit long: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetAccelerationLimitShort()
    {
        Console.WriteLine("Acceleration limit short: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetAccelerationLong()
    {
        Console.WriteLine("Acceleration long: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetAccelerationMaxLong()
    {
        Console.WriteLine("Acceleration max long: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetAccelerationMaxShort()
    {
        Console.WriteLine("Acceleration max short: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetAccelerationShort()
    {
        Console.WriteLine("Acceleration short: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetOffsetOnReverse()
    {
        Console.WriteLine("Offset on reverse (default: 0): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetStartValue()
    {
        Console.WriteLine("Start value (default: 0): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetFastKPeriod()
    {
        Console.WriteLine("Fast K period (1 to 800): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetSlowDPeriod()
    {
        Console.WriteLine("Slow D period (1 to 800): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetSlowDmaType()
    {
        Console.WriteLine("Type of moving average to be used on slow DMA: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetSlowKmaType()
    {
        Console.WriteLine("Type of moving average to be used on slow KMA: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetFastDmaType()
    {
        Console.WriteLine("Type of moving average to be used on fast DMA: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetSlowKPeriod()
    {
        Console.WriteLine("Slow K period (1 to 800): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetFastDPeriod()
    {
        Console.WriteLine("Fast D period (1 to 800): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetPeriod()
    {
        Console.WriteLine("Period (1 to 800): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetSdTimePeriod()
    {
        Console.WriteLine("Number of periods for standard deviation. Must be greater than 0 (recommended: 9): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetVFactor()
    {
        Console.WriteLine("Volume factor (0 to 1): ");
        return Console.ReadLine() ?? string.Empty;
    }
}