namespace MainConsole;

public class QuoteClass
{
    public string symbol { get; set; }
    public string name { get; set; }
    public string exchange { get; set; }
    public string mic_code { get; set; }
    public string currency { get; set; }
    public DateTime datetime { get; set; }
    public long timestamp { get; set; }
    public decimal open { get; set; }
    public decimal high { get; set; }
    public decimal low { get; set; }
    public decimal close { get; set; }
    public long volume { get; set; }
    public decimal previous_close { get; set; }
    public decimal change { get; set; }
    public decimal percent_change { get; set; }
    public long average_volume { get; set; }
    public bool is_market_open { get; set; }
    public FiftyTwoWeek fifty_two_week { get; set; }

    public class FiftyTwoWeek
    {
        public decimal low { get; set; }
        public decimal high { get; set; }
        public decimal low_change { get; set; }
        public decimal high_change { get; set; }
        public decimal low_change_percent { get; set; }
        public decimal high_change_percent { get; set; }
        public string range { get; set; }
    }
}