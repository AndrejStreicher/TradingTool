namespace MainConsole;

public class InputChecker
{
    public static readonly string[] AllTechIndicators =
    {
        "ad",
        "add",
        "adosc",
        "adx",
        "adxr",
        "apo",
        "aroon",
        "aroonosc",
        "atr",
        "avg",
        "avgprice",
        "bbands",
        "beta",
        "bop",
        "cci",
        "ceil",
        "cmo",
        "coppock",
        "correl",
        "crsi",
        "dema",
        "div",
        "dpo",
        "dx",
        "ema",
        "exp",
        "floor",
        "heikinashicandles",
        "hlc3",
        "ht_dcperiod",
        "ht_dcphase",
        "ht_phasor",
        "ht_sine",
        "ht_trendline",
        "ht_trendmode",
        "ichimoku",
        "kama",
        "keltner",
        "kst",
        "linearreg",
        "linearrerangle",
        "linearregintercept",
        "linearregslope",
        "ln",
        "log10",
        "ma",
        "macd",
        "macdext",
        "mama",
        "max",
        "maxindex",
        "mcginley_dynamic",
        "medprice",
        "mfi",
        "midpoint",
        "midprice",
        "min",
        "minindex",
        "minmax",
        "minmaxindex",
        "minus_di",
        "minus_dm",
        "mom",
        "mult",
        "natr",
        "obv",
        "percent_b",
        "plus_di",
        "plus_dm",
        "ppo",
        "roc",
        "rocp",
        "rocr",
        "rocr100",
        "rsi",
        "sar",
        "sarext",
        "sma",
        "sqrt",
        "stddev",
        "stoch",
        "stochf",
        "stochrsi",
        "sub",
        "sum",
        "supertrend",
        "supertrend_heikinashicandles",
        "t3ma",
        "tema",
        "trange",
        "trima",
        "tsf",
        "typrice",
        "ultosc",
        "var",
        "vwap",
        "wclprice",
        "willr",
        "wma"
    };

    public static readonly string[] Intervals =
        { "1min", "5min", "15min", "30min", "45min", "1h", "2h", "4h", "1day", "1week", "1month" };

    private static readonly string[] TechInterval =
        { "ad", "avgprice", "bop", "ceil", "heikinashicandles", "hcl3", "medprice", "trange", "typrice", "wclprice" };

    private static readonly string[] TechIntervalTimePeriod =
    {
        "adx", "adxr", "aroon", "aroonosc", "atr", "cci", "dx", "mcginley_dynamic", "mfi", "midprice", "minus_di",
        "minus_dm", "natr", "plus_di", "plus_dm", "willr"
    };

    private static readonly string[] TechIntervalSeriesType1 =
    {
        "exp", "floor", "ht_dcperiod", "ht_dcphase", "ht_phasor", "ht_sine", "ht_trendline", "ht_trendmode", "ln",
        "log10", "obv", "sqrt"
    };

    private static readonly string[] TechIntervalSeriesTypeTimePeriod =
    {
        "avg", "cmo", "dema", "ema", "kama", "linearreg", "linearregangle", "linearregintercept", "linearregslope",
        "max", "maxindex", "midpoint", "min", "minindex", "minmax", "minmaxindex", "mom", "roc", "rocp", "rocr",
        "rocr100", "rsi", "sma", "sum", "tema", "trima", "tsf", "var", "wma"
    };

    private static readonly string[] TechIntervalSeriesType12 = { "add", "div", "mult", "sub" };
    private static readonly string[] TechIntervalFastPeriodMaTypeSeriesTypeSlowPeriod = { "apo", "ppo" };
    private static readonly string[] TechIntervalSeriesType12TimePeriod = { "beta", "correl" };

    /* 0 interval
       1 timePeriod 1
       2 timePeriod 2
       3 timePeriod 3
       4 seriesType 1
       5 seriesType 2
       6 fastPeriod
       7 slowPeriod
       8 maType
       9 sd
       10 longROCPeriod
       11 shortROCPeriod
       12 wmaPeriod
       13 percentRankPeriod
       14 rsiPeriod
       15 upDownLength
       16 centered
       17 baseLinePeriod
       18 conversionLinePeriod
       19 includeAheadSpanPeriod
       20 laggingSpanPeriod
       21 leadingSpanBPeriod
       22 atrTimePeriod
       23 multiplier
       24 rocPeriod 1
       25 rocPeriod 2
       26 rocPeriod 3
       27 rocPeriod 4
       28 signalPeriod
       29 smaPeriod 1
       30 smaPeriod 2
       31 smaPeriod 3
       32 smaPeriod 4
       33 fastMaType
       34 signalMaType
       35 slowMaType
       36 fastLimit
       37 slowLimit
       39 acceleration
       40 maximum
       41 accelerationLimitLong
       42 accelerationLimitShort
       43 accelerationLong
       44 accelerationMaxLong
       45 accelerationMaxShort
       46 accelerationShort
       47 offsetOnReverse
       48 startValue
       49 fastKPeriod
       50 slowDPeriod
       51 slowDmaType
       52 slowKPeriod
       53 slowKmaType
       54 fastDPeriod
       55 fastDmaType
       56 period
       57 vFactor
       58 sdTimePeriod
       59 timePeriod0
       60 seriesType0
        */
    public static string[] TechIndicatorParameterChecker(string? technicalIndicator)
    {
        List<string> parameters = new List<string>(60);
        parameters.AddRange(Enumerable.Repeat(string.Empty, 60));
        if (TechInterval.Contains(technicalIndicator))
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            return parameters.ToArray();
        }

        if (TechIntervalTimePeriod.Contains(technicalIndicator))
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(59, UserInputs.GetTimePeriodInput("0"));
            return parameters.ToArray();
        }

        if (TechIntervalSeriesType1.Contains(technicalIndicator))
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(60, UserInputs.GetSeriesType("0"));
            return parameters.ToArray();
        }

        if (TechIntervalSeriesTypeTimePeriod.Contains(technicalIndicator))
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(59, UserInputs.GetTimePeriodInput("0"));
            parameters.Insert(60, UserInputs.GetSeriesType("0"));
            return parameters.ToArray();
        }

        if (TechIntervalSeriesType12.Contains(technicalIndicator))
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(4, UserInputs.GetSeriesType("1"));
            parameters.Insert(5, UserInputs.GetSeriesType("2"));
            return parameters.ToArray();
        }

        if (TechIntervalFastPeriodMaTypeSeriesTypeSlowPeriod.Contains(technicalIndicator))
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(60, UserInputs.GetSeriesType("0"));
            parameters.Insert(6, UserInputs.GetFastPeriod());
            parameters.Insert(7, UserInputs.GetSlowPeriod());
            parameters.Insert(8, UserInputs.GetMaType());
            return parameters.ToArray();
        }

        if (TechIntervalSeriesType12TimePeriod.Contains(technicalIndicator))
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(59, UserInputs.GetTimePeriodInput("0"));
            parameters.Insert(4, UserInputs.GetSeriesType("1"));
            parameters.Insert(5, UserInputs.GetSeriesType("2"));
            return parameters.ToArray();
        }

        if (technicalIndicator == "ichimoku")
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(17, UserInputs.GetBaseLinePeriod());
            parameters.Insert(18, UserInputs.GetConversionLinePeriod());
            parameters.Insert(19, UserInputs.GetIncludeAheadSpanPeriod());
            parameters.Insert(20, UserInputs.GetLaggingSpanPeriod());
            parameters.Insert(21, UserInputs.GetLeadingSpanBPeriod());
            return parameters.ToArray();
        }

        if (technicalIndicator == "keltner")
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(8, UserInputs.GetMaType());
            parameters.Insert(22, UserInputs.GetAtrMultiplier());
            parameters.Insert(23, UserInputs.GetMultiplier());
            parameters.Insert(59, UserInputs.GetTimePeriodInput("0"));
            parameters.Insert(60, UserInputs.GetSeriesType("0"));
            return parameters.ToArray();
        }

        if (technicalIndicator == "kst")
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(24, UserInputs.GetRocPeriod("1"));
            parameters.Insert(25, UserInputs.GetRocPeriod("2"));
            parameters.Insert(26, UserInputs.GetRocPeriod("3"));
            parameters.Insert(27, UserInputs.GetRocPeriod("4"));
            parameters.Insert(28, UserInputs.GetSignalPeriod());
            parameters.Insert(29, UserInputs.GetSmaPeriod("1"));
            parameters.Insert(30, UserInputs.GetSmaPeriod("2"));
            parameters.Insert(31, UserInputs.GetSmaPeriod("3"));
            parameters.Insert(32, UserInputs.GetSmaPeriod("4"));
            return parameters.ToArray();
        }

        if (technicalIndicator == "ma")
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(60, UserInputs.GetSeriesType("0"));
            parameters.Insert(8, UserInputs.GetMaType());
            parameters.Insert(59, UserInputs.GetTimePeriodInput("0"));
            return parameters.ToArray();
        }

        if (technicalIndicator == "macd")
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(6, UserInputs.GetFastPeriod());
            parameters.Insert(7, UserInputs.GetSlowPeriod());
            parameters.Insert(28, UserInputs.GetSignalPeriod());
            parameters.Insert(60, UserInputs.GetSeriesType("0"));
            return parameters.ToArray();
        }

        if (technicalIndicator == "macdext")
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(6, UserInputs.GetFastPeriod());
            parameters.Insert(7, UserInputs.GetSlowPeriod());
            parameters.Insert(28, UserInputs.GetSignalPeriod());
            parameters.Insert(33, UserInputs.GetFastMaType());
            parameters.Insert(34, UserInputs.GetSignalMaType());
            parameters.Insert(35, UserInputs.GetSlowMaType());
            parameters.Insert(60, UserInputs.GetSeriesType("0"));
            return parameters.ToArray();
        }

        if (technicalIndicator == "mama")
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(36, UserInputs.GetFastLimit());
            parameters.Insert(37, UserInputs.GetSlowPeriod());
            parameters.Insert(60, UserInputs.GetSeriesType("0"));
            return parameters.ToArray();
        }

        if (technicalIndicator == "percent")
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(8, UserInputs.GetMaType());
            parameters.Insert(9, UserInputs.GetSd());
            parameters.Insert(59, UserInputs.GetTimePeriodInput("0"));
            parameters.Insert(60, UserInputs.GetSeriesType("0"));
            return parameters.ToArray();
        }

        if (technicalIndicator == "sar")
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(39, UserInputs.GetAcceleration());
            parameters.Insert(40, UserInputs.GetMaximum());
            return parameters.ToArray();
        }

        if (technicalIndicator == "sarext")
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(41, UserInputs.GetAccelerationLimitLong());
            parameters.Insert(42, UserInputs.GetAccelerationLimitShort());
            parameters.Insert(43, UserInputs.GetAccelerationLong());
            parameters.Insert(44, UserInputs.GetAccelerationMaxLong());
            parameters.Insert(45, UserInputs.GetAccelerationMaxShort());
            parameters.Insert(46, UserInputs.GetAccelerationShort());
            parameters.Insert(47, UserInputs.GetOffsetOnReverse());
            parameters.Insert(48, UserInputs.GetStartValue());
            return parameters.ToArray();
        }

        if (technicalIndicator == "stdev")
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(9, UserInputs.GetSd());
            parameters.Insert(9, UserInputs.GetSd());
            parameters.Insert(59, UserInputs.GetTimePeriodInput("0"));
            parameters.Insert(60, UserInputs.GetSeriesType("0"));
            return parameters.ToArray();
        }

        if (technicalIndicator == "stoch")
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(49, UserInputs.GetFastKPeriod());
            parameters.Insert(50, UserInputs.GetSlowDPeriod());
            parameters.Insert(51, UserInputs.GetSlowDmaType());
            parameters.Insert(52, UserInputs.GetSlowKPeriod());
            parameters.Insert(53, UserInputs.GetSlowKmaType());
            return parameters.ToArray();
        }

        if (technicalIndicator == "stochf")
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(49, UserInputs.GetFastKPeriod());
            parameters.Insert(54, UserInputs.GetFastDPeriod());
            parameters.Insert(55, UserInputs.GetFastDmaType());
            return parameters.ToArray();
        }

        if (technicalIndicator == "stochrsi")
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(54, UserInputs.GetFastDPeriod());
            parameters.Insert(55, UserInputs.GetFastDmaType());
            parameters.Insert(49, UserInputs.GetFastKPeriod());
            parameters.Insert(59, UserInputs.GetTimePeriodInput("0"));
            parameters.Insert(60, UserInputs.GetSeriesType("0"));
            return parameters.ToArray();
        }

        if (technicalIndicator == "supertrend")
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(23, UserInputs.GetMultiplier());
            parameters.Insert(56, UserInputs.GetPeriod());
            return parameters.ToArray();
        }

        if (technicalIndicator == "t3ma")
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(59, UserInputs.GetTimePeriodInput("0"));
            parameters.Insert(60, UserInputs.GetSeriesType("0"));
            parameters.Insert(57, UserInputs.GetVFactor());
            return parameters.ToArray();
        }

        if (technicalIndicator == "ultosc")
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(1, UserInputs.GetTimePeriodInput("1"));
            parameters.Insert(2, UserInputs.GetTimePeriodInput("2"));
            parameters.Insert(3, UserInputs.GetTimePeriodInput("3"));
            return parameters.ToArray();
        }

        if (technicalIndicator == "vwap")
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(9, UserInputs.GetSd());
            parameters.Insert(58, UserInputs.GetSdTimePeriod());
            return parameters.ToArray();
        }

        if (technicalIndicator == "adosc")
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(6, UserInputs.GetFastPeriod());
            parameters.Insert(7, UserInputs.GetSlowPeriod());
            return parameters.ToArray();
        }

        if (technicalIndicator == "bbands")
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(59, UserInputs.GetTimePeriodInput("0"));
            parameters.Insert(60, UserInputs.GetSeriesType("0"));
            parameters.Insert(8, UserInputs.GetMaType());
            parameters.Insert(9, UserInputs.GetSd());
            return parameters.ToArray();
        }

        if (technicalIndicator == "coppock")
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(60, UserInputs.GetSeriesType("0"));
            parameters.Insert(10, UserInputs.GetLongRocPeriod());
            parameters.Insert(11, UserInputs.GetShortRocPeriod());
            parameters.Insert(12, UserInputs.GetWma());
            return parameters.ToArray();
        }

        if (technicalIndicator == "crsi")
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(60, UserInputs.GetSeriesType("0"));
            parameters.Insert(13, UserInputs.GetPercentRankPeriod());
            parameters.Insert(14, UserInputs.GetRsiPeriod());
            parameters.Insert(15, UserInputs.GetUpDownLength());
            return parameters.ToArray();
        }

        if (technicalIndicator == "dpo")
        {
            parameters.Insert(0, UserInputs.GetIntervalInput());
            parameters.Insert(59, UserInputs.GetTimePeriodInput("0"));
            parameters.Insert(60, UserInputs.GetSeriesType("0"));
            parameters.Insert(16, UserInputs.GetCentered());
            return parameters.ToArray();
        }

        return parameters.ToArray();
    }
}