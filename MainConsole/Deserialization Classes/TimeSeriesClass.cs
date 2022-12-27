namespace MainConsole;

public class TimeSeriesClass
{
    public class TimeSeriesRoot
    {
        public Meta Meta { get; set; }
        public List<Value> Values { get; set; }
    }

    public class Meta
    {
        public string symbol { get; set; }
        public string interval { get; set; }
        public string currency { get; set; }
        public string exchange_timezone { get; set; }
        public string exchange { get; set; }
        public string mic_code { get; set; }
        public string currency_base { get; set; }
        public string currency_quote { get; set; }
        public string type { get; set; }
    }


    public class Value
    {
        public DateTime datetime { get; set; }
        public string open { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string close { get; set; }
        public string volume { get; set; }
    }
}