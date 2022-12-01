namespace MainConsole;

public class InputChecker
{
    public static readonly string[] allTechIndicators =
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

    public static readonly string[] intervals =
        { "1min", "5min", "15min", "30min", "45min", "1h", "2h", "4h", "1day", "1week", "1month" };

    public static readonly string[] techInterval =
        { "ad", "avgprice", "bop", "ceil", "heikinashicandles", "hcl3", "medprice", "trange", "typrice", "wclprice" };

    public static readonly string[] techIntervalTimePeriod =
    {
        "adx", "adxr", "aroon", "aroonosc", "atr", "cci", "dx", "mcginley_dynamic", "mfi", "midprice", "minus_di",
        "minus_dm", "natr", "plus_di", "plus_dm", "willr"
    };

    public static readonly string[] techIntervalSeriesType1 =
    {
        "exp", "floor", "ht_dcperiod", "ht_dcphase", "ht_phasor", "ht_sine", "ht_trendline", "ht_trendmode", "ln",
        "log10", "obv", "sqrt"
    };

    public static readonly string[] techIntervalSeriesTypeTimePeriod =
    {
        "avg", "cmo", "dema", "ema", "kama", "linearreg", "linearregangle", "linearregintercept", "linearregslope",
        "max", "maxindex", "midpoint", "min", "minindex", "minmax", "minmaxindex", "mom", "roc", "rocp", "rocr",
        "rocr100", "rsi", "sma", "sum", "tema", "trima", "tsf", "var", "wma"
    };

    public static readonly string[] techIntervalSeriesType12 = { "add", "div", "mult", "sub" };
    public static readonly string[] techIntervalFastPeriodMaTypeSeriesTypeSlowPeriod = { "apo", "ppo" };
    public static readonly string[] techIntervalSeriesType12TimePeriod = { "beta", "correl" };

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
       38 sd
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
        */
    public static string[] TechIndicatorParameterChecker(string technicalIndicator)
    {
        string[] parameters = { };
        if (techInterval.Any(technicalIndicator.Contains))
        {
            parameters[0] = UserInputs.GetIntervalInput();
            return parameters;
        }

        if (techIntervalTimePeriod.Any(technicalIndicator.Contains))
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[1] = UserInputs.GetTimePeriodInput("0");
            return parameters;
        }

        if (techIntervalSeriesType1.Any(technicalIndicator.Contains))
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[1] = UserInputs.GetSeriesType("1");
            return parameters;
        }

        if (techIntervalSeriesTypeTimePeriod.Any(technicalIndicator.Contains))
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[1] = UserInputs.GetSeriesType("1");
            parameters[2] = UserInputs.GetTimePeriodInput("0");
            return parameters;
        }

        if (techIntervalSeriesType12.Any(technicalIndicator.Contains))
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[1] = UserInputs.GetSeriesType("1");
            parameters[2] = UserInputs.GetSeriesType("2");
            return parameters;
        }

        if (techIntervalFastPeriodMaTypeSeriesTypeSlowPeriod.Any(technicalIndicator.Contains))
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[4] = UserInputs.GetSeriesType("0");
            parameters[6] = UserInputs.GetFastPeriod();
            parameters[7] = UserInputs.GetSlowPeriod();
            parameters[8] = UserInputs.GetMaType();
        }

        if (techIntervalSeriesType12TimePeriod.Any(technicalIndicator.Contains))
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[1] = UserInputs.GetTimePeriodInput("0");
            parameters[4] = UserInputs.GetSeriesType("1");
            parameters[5] = UserInputs.GetSeriesType("1");
        }

        if (technicalIndicator == "ichimoku")
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[17] = UserInputs.GetBaseLinePeriod();
            parameters[18] = UserInputs.GetConversionLinePeriod();
            parameters[19] = UserInputs.GetIncludeAheadSpanPeriod();
            parameters[20] = UserInputs.GetLaggingSpanPeriod();
            parameters[21] = UserInputs.GetLeadingSpanBPeriod();
        }

        if (technicalIndicator == "keltner")
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[1] = UserInputs.GetTimePeriodInput("0");
            parameters[4] = UserInputs.GetSeriesType("0");
            parameters[8] = UserInputs.GetMaType();
            parameters[22] = UserInputs.GetAtrMultiplier();
            parameters[23] = UserInputs.GetMultiplier();
        }

        if (technicalIndicator == "kst")
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[24] = UserInputs.GetRocPeriod("1");
            parameters[25] = UserInputs.GetRocPeriod("2");
            parameters[26] = UserInputs.GetRocPeriod("3");
            parameters[27] = UserInputs.GetRocPeriod("4");
            parameters[28] = UserInputs.GetSignalPeriod();
            parameters[29] = UserInputs.GetSmaPeriod("1");
            parameters[30] = UserInputs.GetSmaPeriod("2");
            parameters[31] = UserInputs.GetSmaPeriod("3");
            parameters[32] = UserInputs.GetSmaPeriod("4");
        }

        if (technicalIndicator == "ma")
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[1] = UserInputs.GetTimePeriodInput("0");
            parameters[4] = UserInputs.GetSeriesType("0");
            parameters[8] = UserInputs.GetMaType();
        }

        if (technicalIndicator == "macd")
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[4] = UserInputs.GetSeriesType("0");
            parameters[6] = UserInputs.GetFastPeriod();
            parameters[7] = UserInputs.GetSlowPeriod();
            parameters[8] = UserInputs.GetMaType();
        }

        if (technicalIndicator == "macdext")
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[4] = UserInputs.GetSeriesType("0");
            parameters[6] = UserInputs.GetFastPeriod();
            parameters[7] = UserInputs.GetSlowPeriod();
            parameters[28] = UserInputs.GetSignalPeriod();
            parameters[33] = UserInputs.GetFastMaType();
            parameters[34] = UserInputs.GetSignalMaType();
            parameters[35] = UserInputs.GetSlowMaType();
        }

        if (technicalIndicator == "mama")
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[4] = UserInputs.GetSeriesType("0");
            parameters[36] = UserInputs.GetFastLimit();
            parameters[37] = UserInputs.GetSlowPeriod();
        }

        if (technicalIndicator == "percent")
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[1] = UserInputs.GetTimePeriodInput("0");
            parameters[4] = UserInputs.GetSeriesType("0");
            parameters[8] = UserInputs.GetMaType();
            parameters[38] = UserInputs.GetSd();
        }

        if (technicalIndicator == "sar")
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[39] = UserInputs.GetAcceleration();
            parameters[40] = UserInputs.GetMaximum();
        }

        if (technicalIndicator == "sarext")
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[41] = UserInputs.GetAccelerationLimitLong();
            parameters[42] = UserInputs.GetAccelerationLimitShort();
            parameters[43] = UserInputs.GetAccelerationLong();
            parameters[44] = UserInputs.GetAccelerationMaxLong();
            parameters[45] = UserInputs.GetAccelerationMaxShort();
            parameters[46] = UserInputs.GetAccelerationShort();
            parameters[47] = UserInputs.GetOffsetOnReverse();
            parameters[48] = UserInputs.GetStartValue();
        }

        if (technicalIndicator == "stdev")
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[1] = UserInputs.GetTimePeriodInput("0");
            parameters[4] = UserInputs.GetSeriesType("0");
            parameters[38] = UserInputs.GetSd();
        }

        if (technicalIndicator == "stoch")
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[49] = UserInputs.GetFastKPeriod();
            parameters[50] = UserInputs.GetSlowDPeriod();
            parameters[51] = UserInputs.GetSlowDmaType();
            parameters[52] = UserInputs.GetSlowKPeriod();
            parameters[53] = UserInputs.GetSlowKmaType();
        }

        if (technicalIndicator == "stochf")
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[54] = UserInputs.GetFastDPeriod();
            parameters[55] = UserInputs.GetFastDmaType();
            parameters[49] = UserInputs.GetFastKPeriod();
        }

        if (technicalIndicator == "stochrsi")
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[1] = UserInputs.GetTimePeriodInput("0");
            parameters[4] = UserInputs.GetSeriesType("0");
            parameters[54] = UserInputs.GetFastDPeriod();
            parameters[55] = UserInputs.GetFastDmaType();
            parameters[49] = UserInputs.GetFastKPeriod();
        }

        if (technicalIndicator == "supertrend")
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[23] = UserInputs.GetMultiplier();
            parameters[56] = UserInputs.GetPeriod();
        }

        if (technicalIndicator == "t3ma")
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[1] = UserInputs.GetTimePeriodInput("0");
            parameters[4] = UserInputs.GetSeriesType("0");
            parameters[57] = UserInputs.GetVFactor();
        }

        if (technicalIndicator == "ultosc")
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[1] = UserInputs.GetTimePeriodInput("1");
            parameters[2] = UserInputs.GetTimePeriodInput("2");
            parameters[3] = UserInputs.GetTimePeriodInput("3");
        }

        if (technicalIndicator == "vwap")
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[38] = UserInputs.GetSd();
            parameters[58] = UserInputs.GetSdTimePeriod();
        }

        if (technicalIndicator == "adosc")
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[6] = UserInputs.GetFastPeriod();
            parameters[7] = UserInputs.GetSlowPeriod();
        }

        if (technicalIndicator == "bbands")
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[1] = UserInputs.GetTimePeriodInput("0");
            parameters[4] = UserInputs.GetSeriesType("0");
            parameters[8] = UserInputs.GetMaType();
            parameters[38] = UserInputs.GetSd();
        }

        if (technicalIndicator == "coppock")
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[4] = UserInputs.GetSeriesType("0");
            parameters[10] = UserInputs.GetLongRocPeriod();
            parameters[11] = UserInputs.GetShortRocPeriod();
            parameters[12] = UserInputs.GetWMA();
        }

        if (technicalIndicator == "crsi")
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[4] = UserInputs.GetSeriesType("0");
            parameters[13] = UserInputs.GetPercentRankPeriod();
            parameters[14] = UserInputs.GetRsiPeriod();
            parameters[15] = UserInputs.GetUpDownLength();
        }

        if (technicalIndicator == "dpo")
        {
            parameters[0] = UserInputs.GetIntervalInput();
            parameters[1] = UserInputs.GetTimePeriodInput("0");
            parameters[4] = UserInputs.GetSeriesType("0");
            parameters[16] = UserInputs.GetCentered();
        }

        return parameters;
    }
}