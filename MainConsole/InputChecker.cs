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

    // private static readonly string[] TechInterval =
    //     { "ad", "avgprice", "bop", "ceil", "heikinashicandles", "hcl3", "medprice", "trange", "typrice", "wclprice" };

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


    public static string GetTechIndicatorParameters(string? technicalIndicator)
    {
        string parameters = "";
        if (TechIntervalTimePeriod.Contains(technicalIndicator))
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&time_period={UserInputs.GetTimePeriodInput("0")}");
        }

        if (TechIntervalSeriesType1.Contains(technicalIndicator))
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&series_type={UserInputs.GetSeriesType("0")}");
        }

        if (TechIntervalSeriesTypeTimePeriod.Contains(technicalIndicator))
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&time_period={UserInputs.GetTimePeriodInput("0")}",
                $"&series_type={UserInputs.GetSeriesType("0")}");
        }

        if (TechIntervalSeriesType12.Contains(technicalIndicator))
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&series_type_1={UserInputs.GetSeriesType("1")}",
                $"&series_type_2={UserInputs.GetSeriesType("2")}");
        }

        if (TechIntervalFastPeriodMaTypeSeriesTypeSlowPeriod.Contains(technicalIndicator))
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&series_type={UserInputs.GetSeriesType("0")}",
                $"&fast_period={UserInputs.GetFastPeriod()}",
                $"&slow_period={UserInputs.GetSlowPeriod()}",
                $"&ma_type={UserInputs.GetMaType()}");
        }

        if (TechIntervalSeriesType12TimePeriod.Contains(technicalIndicator))
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&time_period={UserInputs.GetTimePeriodInput("0")}",
                $"&series_type_1={UserInputs.GetSeriesType("1")}",
                $"&series_type_2={UserInputs.GetSeriesType("2")}");
        }

        if (technicalIndicator == "ichimoku")
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&base_line_period={UserInputs.GetBaseLinePeriod()}",
                $"&conversion_line_period={UserInputs.GetConversionLinePeriod()}",
                $"&include_ahead_span={UserInputs.GetIncludeAheadSpanPeriod()}",
                $"&lagging_span_period={UserInputs.GetLaggingSpanPeriod()}",
                $"&leading_span_b_period={UserInputs.GetLeadingSpanBPeriod()}");
        }

        if (technicalIndicator == "keltner")
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&ma_type={UserInputs.GetMaType()}",
                $"&multiplier={UserInputs.GetMultiplier()}",
                $"&time_period={UserInputs.GetTimePeriodInput("0")}",
                $"&series_type={UserInputs.GetSeriesType("0")}");
        }

        if (technicalIndicator == "kst")
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&roc_period_1={UserInputs.GetRocPeriod("1")}",
                $"&roc_period_2={UserInputs.GetRocPeriod("2")}",
                $"&roc_period_3={UserInputs.GetRocPeriod("3")}",
                $"&roc_period_4={UserInputs.GetRocPeriod("4")}",
                $"&signal_period={UserInputs.GetSignalPeriod()}",
                $"&sma_period_1={UserInputs.GetSmaPeriod("1")}",
                $"&sma_period_2={UserInputs.GetSmaPeriod("2")}",
                $"&sma_period_3={UserInputs.GetSmaPeriod("3")}",
                $"&sma_period_4={UserInputs.GetSmaPeriod("4")}");
        }

        if (technicalIndicator == "ma")
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&series_type={UserInputs.GetSeriesType("0")}",
                $"&ma_type={UserInputs.GetMaType()}",
                $"&time_period={UserInputs.GetTimePeriodInput("0")}");
        }

        if (technicalIndicator == "macd")
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&fast_period={UserInputs.GetFastPeriod()}",
                $"&slow_period={UserInputs.GetSlowPeriod()}",
                $"&signal_period={UserInputs.GetSignalPeriod()}",
                $"&series_type={UserInputs.GetSeriesType("0")}");
        }

        if (technicalIndicator == "macdext")
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&fast_period={UserInputs.GetFastPeriod()}",
                $"&slow_period={UserInputs.GetSlowPeriod()}",
                $"&signal_period={UserInputs.GetSignalPeriod()}",
                $"&fast_ma_type={UserInputs.GetFastMaType()}",
                $"&signal_ma_type={UserInputs.GetSignalMaType()}",
                $"&slow_ma_type={UserInputs.GetSlowMaType()}",
                $"&series_type={UserInputs.GetSeriesType("0")}");
        }

        if (technicalIndicator == "mama")
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&fast_limit={UserInputs.GetFastLimit()}",
                $"&slow_limit={UserInputs.GetSlowLimit()}",
                $"&series_type={UserInputs.GetSeriesType("0")}");
        }

        if (technicalIndicator == "percent")
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&ma_type={UserInputs.GetMaType()}",
                $"&sd={UserInputs.GetSd()}",
                $"&time_period={UserInputs.GetTimePeriodInput("0")}",
                $"&series_type={UserInputs.GetSeriesType("0")}");
        }

        if (technicalIndicator == "sar")
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&acceleration={UserInputs.GetAcceleration()}",
                $"&maximum={UserInputs.GetMaximum()}");
        }

        if (technicalIndicator == "sarext")
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&acceleration_limit_long={UserInputs.GetAccelerationLimitLong()}",
                $"&acceleration_limit_short={UserInputs.GetAccelerationLimitShort()}",
                $"&acceleration_long={UserInputs.GetAccelerationLong()}",
                $"&acceleration_max_long={UserInputs.GetAccelerationMaxLong()}",
                $"&acceleration_max_short={UserInputs.GetAccelerationMaxShort()}",
                $"&acceleration_short={UserInputs.GetAccelerationShort()}",
                $"&offset_on_reverse={UserInputs.GetOffsetOnReverse()}",
                $"&offset_on_reverse={UserInputs.GetStartValue()}");
        }

        if (technicalIndicator == "stdev")
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&sd={UserInputs.GetSd()}",
                $"&time_period={UserInputs.GetTimePeriodInput("0")}",
                $"&series_type={UserInputs.GetSeriesType("0")}");
        }

        if (technicalIndicator == "stoch")
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&fast_k_period={UserInputs.GetFastKPeriod()}",
                $"&slow_d_period={UserInputs.GetSlowDPeriod()}",
                $"&slow_dma_type={UserInputs.GetSlowDmaType()}",
                $"&slow_k_period={UserInputs.GetSlowKPeriod()}",
                $"&slow_kma_type={UserInputs.GetSlowKmaType()}");
        }

        if (technicalIndicator == "stochf")
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&fast_k_period={UserInputs.GetFastKPeriod()}",
                $"&fast_d_period={UserInputs.GetFastDPeriod()}",
                $"&fast_dma_type={UserInputs.GetFastDmaType()}");
        }

        if (technicalIndicator == "stochrsi")
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&fast_k_period={UserInputs.GetFastKPeriod()}",
                $"&fast_d_period={UserInputs.GetFastDPeriod()}",
                $"&fast_dma_type={UserInputs.GetFastDmaType()}",
                $"&time_period={UserInputs.GetTimePeriodInput("0")}",
                $"&series_type={UserInputs.GetSeriesType("0")}");
        }

        if (technicalIndicator == "supertrend")
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&multiplier={UserInputs.GetMultiplier()}",
                $"&period={UserInputs.GetPeriod()}");
        }

        if (technicalIndicator == "t3ma")
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&v_factor={UserInputs.GetVFactor()}",
                $"&time_period={UserInputs.GetTimePeriodInput("0")}",
                $"&series_type={UserInputs.GetSeriesType("0")}");
        }

        if (technicalIndicator == "ultosc")
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&time_period_1={UserInputs.GetTimePeriodInput("1")}",
                $"&time_period_2={UserInputs.GetTimePeriodInput("2")}",
                $"&time_period_3={UserInputs.GetTimePeriodInput("3")}");
        }

        if (technicalIndicator == "vwap")
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&sd={UserInputs.GetSd()}",
                $"&sd_time_period={UserInputs.GetSdTimePeriod()}");
        }

        if (technicalIndicator == "adosc")
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&fast_period={UserInputs.GetFastPeriod()}",
                $"&slow_period={UserInputs.GetSlowPeriod()}");
        }

        if (technicalIndicator == "bbands")
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&ma_type={UserInputs.GetMaType()}",
                $"&sd={UserInputs.GetSd()}", $"&time_period={UserInputs.GetTimePeriodInput("0")}",
                $"&series_type={UserInputs.GetSeriesType("0")}");
        }

        if (technicalIndicator == "coppock")
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&long_roc_period={UserInputs.GetLongRocPeriod()}",
                $"&short_roc_period={UserInputs.GetShortRocPeriod()}",
                $"&wma_period={UserInputs.GetWma()}",
                $"&series_type={UserInputs.GetSeriesType("0")}");
        }

        if (technicalIndicator == "crsi")
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&percent_rank_period={UserInputs.GetPercentRankPeriod()}",
                $"&rsi_period={UserInputs.GetRsiPeriod()}",
                $"&up_down_length={UserInputs.GetUpDownLength()}",
                $"&series_type={UserInputs.GetSeriesType("0")}");
        }

        if (technicalIndicator == "dpo")
        {
            parameters = String.Concat(parameters, $"&interval={UserInputs.GetIntervalInput()}",
                $"&time_period={UserInputs.GetTimePeriodInput("0")}",
                $"&series_type={UserInputs.GetSeriesType("0")}",
                $"&centered={UserInputs.GetCentered()}");
        }

        return parameters;
    }
}