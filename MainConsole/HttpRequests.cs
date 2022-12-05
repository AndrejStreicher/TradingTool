namespace MainConsole;

using System.Threading.Tasks;

public class HttpRequests
{
    static readonly HttpClient Client = new HttpClient();
    private string? _endpoint;
    private string _apiKey;
    private string? _interval;
    private string? _symbol;
    private string? _startdate;
    private string? _enddate;
    private string _timePeriod1;
    private string _timePeriod2;
    private string _timePeriod3;
    private string _seriesType1;
    private string _seriesType2;
    private string _fastPeriod;
    private string _slowPeriod;
    private string _maType;
    private string _sd;
    private string _longRoCperiod;
    private string _shortRoCperiod;
    private string _wmaPeriod;
    private string _percentRankPeriod;
    private string _rsiPeriod;
    private string _upDownLength;
    private string _centered;
    private string _baseLinePeriod;
    private string _conversionLinePeriod;
    private string _includeAheadSpanperiod;
    private string _laggingSpanPeriod;
    private string _leadingSpanBPeriod;
    private string _atrTimePeriod;
    private string _multiplier;
    private string _rocPeriod1;
    private string _rocPeriod2;
    private string _rocPeriod3;
    private string _rocPeriod4;
    private string _signalPeriod;
    private string _smaPeriod1;
    private string _smaPeriod2;
    private string _smaPeriod3;
    private string _smaPeriod4;
    private string _fastMaType;
    private string _signalMaType;
    private string _slowMaType;
    private string _fastLimit;
    private string _slowLimit;
    private string _acceleration;
    private string _maximum;
    private string _accelerationLimitLong;
    private string _accelerationLimitShort;
    private string _accelerationLong;
    private string _accelerationMaxLong;
    private string _accelerationMaxShort;
    private string _accelerationShort;
    private string _offsetOnReverse;
    private string _startValue;
    private string _fastKPeriod;
    private string _slowDPeriod;
    private string _slowDmaType;
    private string _slowKPeriod;
    private string _slowKmaType;
    private string _fastDPeriod;
    private string _fastDmaType;
    private string _period;
    private string _vFactor;
    private string _sdTimePeriod;
    private string _timePeriod0;
    private string _seriesType0;


    public HttpRequests(params string[] args)
    {
        _endpoint = args[0];
        _apiKey = $"?apikey={args[1]}";
        _interval = $"&interval={args[2]}";
        _symbol = $"&symbol={args[3]}";
        _startdate = $"&start_date={args[4]}";
        _enddate = $"&end_date={args[5]}";
        _timePeriod1 = $"&time_period_1={args[6]}";
        _timePeriod2 = $"&time_period_2={args[7]}";
        _timePeriod3 = $"&time_period_3={args[8]}";
        _seriesType1 = $"&series_type_1={args[9]}";
        _seriesType2 = $"&series_type_2={args[10]}";
        _fastPeriod = $"&fast_period={args[11]}";
        _slowPeriod = $"&slow_period={args[12]}";
        _maType = $"&ma_type={args[13]}";
        _sd = $"&sd={args[14]}";
        _longRoCperiod = $"&long_roc_period={args[15]}";
        _shortRoCperiod = $"&short_roc_period={args[16]}";
        _wmaPeriod = $"&wma_period={args[17]}";
        _percentRankPeriod = $"&percent_rank_period={args[18]}";
        _rsiPeriod = $"&rsi_period={args[19]}";
        _upDownLength = $"&up_down_length={args[20]}";
        _centered = $"&centered={args[21]}";
        _baseLinePeriod = $"&base_line_period={args[22]}";
        _conversionLinePeriod = $"&conversion_line_period={args[23]}";
        _includeAheadSpanperiod = $"&include_ahead_span={args[24]}";
        _laggingSpanPeriod = $"&lagging_span_period={args[25]}";
        _leadingSpanBPeriod = $"&leading_span_b_period={args[26]}";
        _atrTimePeriod = $"&atr_time_period={args[27]}";
        _multiplier = $"&multiplier={args[28]}";
        _rocPeriod1 = $"&roc_period_1={args[29]}";
        _rocPeriod2 = $"&roc_period_2={args[30]}";
        _rocPeriod3 = $"&roc_period_3={args[31]}";
        _rocPeriod4 = $"&roc_period_4={args[32]}";
        _signalPeriod = $"&signal_period={args[33]}";
        _smaPeriod1 = $"&sma_period_1={args[34]}";
        _smaPeriod2 = $"&sma_period_2={args[35]}";
        _smaPeriod3 = $"&sma_period_3={args[36]}";
        _smaPeriod4 = $"&sma_period_4={args[37]}";
        _fastMaType = $"&fast_ma_type={args[38]}";
        _signalMaType = $"&signal_ma_type={args[39]}";
        _slowMaType = $"&slow_ma_type={args[40]}";
        _fastLimit = $"&fast_limit={args[41]}";
        _slowLimit = $"&slow_limit={args[42]}";
        _acceleration = $"&acceleration={args[43]}";
        _maximum = $"&maximum={args[44]}";
        _accelerationLimitLong = $"&acceleration_limit_long={args[45]}";
        _accelerationLimitShort = $"&acceleration_limit_short={args[46]}";
        _accelerationLong = $"&acceleration_long={args[47]}";
        _accelerationMaxLong = $"&acceleration_max_long={args[48]}";
        _accelerationMaxShort = $"&acceleration_max_short={args[49]}";
        _accelerationShort = $"&acceleration_short={args[50]}";
        _offsetOnReverse = $"&offset_on_reverse={args[51]}";
        _startValue = $"&start_value={args[52]}";
        _fastKPeriod = $"&fast_k_period={args[53]}";
        _slowDPeriod = $"&slow_d_period={args[54]}";
        _slowDmaType = $"&slow_dma_type={args[55]}";
        _slowKPeriod = $"&slow_k_period={args[56]}";
        _slowKmaType = $"&slow_kma_type={args[57]}";
        _fastDPeriod = $"&fast_d_period={args[58]}";
        _fastDmaType = $"&fast_dma_type={args[59]}";
        _period = $"&period={args[60]}";
        _vFactor = $"&v_factor={args[61]}";
        _sdTimePeriod = $"&sd_time_period={args[62]}";
        _timePeriod0 = $"&time_period_0={args[63]}";
        _seriesType0 = $"&series_type_0={args[64]}";
    }

    public async Task<string> ApiCall()
    {
        try
        {
            string responseBody =
                await Client.GetStringAsync(
                    $"https://api.twelvedata.com/{_endpoint}{_apiKey}{_interval}{_symbol}{_startdate}{_enddate}{_timePeriod1}{_timePeriod2}{_timePeriod3}{_seriesType1}{_seriesType2}{_fastPeriod}{_slowPeriod}{_maType}{_sd}{_longRoCperiod}{_shortRoCperiod}{_wmaPeriod}{_percentRankPeriod}{_rsiPeriod}{_upDownLength}{_centered}{_baseLinePeriod}{_conversionLinePeriod}{_includeAheadSpanperiod}{_laggingSpanPeriod}{_leadingSpanBPeriod}{_atrTimePeriod}{_multiplier}{_rocPeriod1}{_rocPeriod2}{_rocPeriod3}{_rocPeriod4}{_signalPeriod}{_smaPeriod1}{_smaPeriod2}{_smaPeriod3}{_smaPeriod4}{_fastMaType}{_signalMaType}{_slowMaType}{_fastLimit}{_slowLimit}{_acceleration}{_maximum}{_accelerationLimitLong}{_accelerationLimitShort}{_accelerationLong}{_accelerationMaxLong}{_accelerationMaxShort}{_accelerationShort}{_offsetOnReverse}{_startValue}{_fastKPeriod}{_slowDPeriod}{_slowDmaType}{_slowKPeriod}{_slowKmaType}{_fastDPeriod}{_fastDmaType}{_period}{_vFactor}{_sdTimePeriod}{_timePeriod0}{_seriesType0}");
            return responseBody;
        }
        catch (HttpRequestException error)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", error.Message);
            return error.Message;
        }
    }
}