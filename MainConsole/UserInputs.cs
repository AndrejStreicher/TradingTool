namespace MainConsole;

public class UserInputs
{
    public static string GetIntervalInput()
    {
        string interval;
        Console.WriteLine("Intervals: ");
        Console.WriteLine("______________________________________");
        for (int i = 0; i < InputChecker.intervals.Length; i++)
        {
            Console.Write($"{InputChecker.intervals[i]} ");
        }

        Console.WriteLine("");
        Console.WriteLine("______________________________________");
        Console.WriteLine("Enter interval: ");
        do
        {
            interval = Console.ReadLine();
        } while (InputChecker.intervals.Any(interval.Contains) == false);

        return interval;
    }

    public static string GetSymbolInput()
    {
        Console.WriteLine("Enter symbol: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetStartdateInput()
    {
        Console.WriteLine("Enter start-date (2000-12-31|or|2000-12-31 24-59-59): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetEnddateInput()
    {
        Console.WriteLine("Enter end-date (2000-12-31|or|2000-12-31 24-59-59): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetTimePeriodInput()
    {
        Console.WriteLine("Enter time-period: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetTechnicalIndicator()
    {
        string techIndicator;
        Console.WriteLine("Technical indicators: ");
        Console.WriteLine("______________________________________");
        for (int i = 0; i < InputChecker.allTechIndicators.Length; i++)
        {
            Console.Write($"{InputChecker.allTechIndicators[i]} ");
        }

        Console.WriteLine("");
        Console.WriteLine("______________________________________");
        Console.WriteLine("Enter technical indicator: ");
        do
        {
            techIndicator = Console.ReadLine();
        } while (InputChecker.allTechIndicators.Any(techIndicator.Contains) == false);

        return techIndicator;
    }

    public static string GetSeriesType()
    {
        Console.WriteLine("Series type (default: close): ");
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

    public static string GetWMA()
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

    public static bool GetCentered()
    {
        Console.WriteLine("Specifies if there should be a shift to match the current price (true or false): ");
        bool boolResponse;
        string response = Console.ReadLine();
        if (response == "true")
        {
            boolResponse = true;
        }
        else
        {
            boolResponse = false;
        }

        return boolResponse;
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

    public static bool GetIncludeAheadSpanPeriod()
    {
        Console.WriteLine(
            " Specifies if the span values ahead the current moment should be returned (true or false): ");
        bool boolResponse;
        string response = Console.ReadLine();
        if (response == "true")
        {
            boolResponse = true;
        }
        else
        {
            boolResponse = false;
        }

        return boolResponse;
    }

    public static string GetLaggingSpanPeriod()
    {
        Console.WriteLine("Lagging span period (1 to 800): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetLaggingSpanBPeriod()
    {
        Console.WriteLine("Lagging span B period (1 to 800): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetMultiplier()
    {
        Console.WriteLine("Get multiplier: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetRocPeriod()
    {
        Console.WriteLine("Rate of change period (1 to 800): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetSignalPeriod()
    {
        Console.WriteLine("Signal period (1 to 800): ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static string GetSmaPeriod()
    {
        Console.WriteLine("Simple moving average period (1 to 800): ");
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

    public static string GetVFactor()
    {
        Console.WriteLine("Volume factor (0 to 1): ");
        return Console.ReadLine() ?? string.Empty;
    }
}