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
        do
        {
            Console.WriteLine("Enter interval: ");
            interval = Console.ReadLine() ?? string.Empty;
            if (interval == string.Empty)
            {
                Console.WriteLine("Interval required!");
            }
            else if (InputChecker.intervals.Contains(interval) == false)
            {
                Console.WriteLine("Unknown interval, try again:");
            }
        } while (InputChecker.intervals.Contains(interval) == false);

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

    public static string GetTimePeriodInput(string number)
    {
        if (number == "0")
        {
            Console.WriteLine("Enter time-period: ");
        }
        else
        {
            Console.WriteLine($"Enter time-period number {number}: ");
        }

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
        do
        {
            Console.WriteLine("Enter technical indicator: ");
            techIndicator = Console.ReadLine() ?? string.Empty;
            techIndicator = techIndicator.ToLower();
            if (techIndicator.Contains(" "))
            {
                techIndicator = techIndicator.Replace(" ", "_");
            }
            if (techIndicator == string.Empty)
            {
                Console.WriteLine("Technical indicator required!");
            }
            else if (InputChecker.allTechIndicators.Contains(techIndicator) == false)
            {
                Console.WriteLine("Unknown technical indicator!");
            }
        } while (InputChecker.allTechIndicators.Contains(techIndicator) == false);

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

    public static string GetAtrMultiplier()
    {
        Console.WriteLine("Get ATR multiplier: ");
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