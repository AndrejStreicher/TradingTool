namespace MainConsole;

public class SymbolLookupClass
{
    public class Root
    {
        public List<Data> DataSets { get; set; }
        public string Status { get; set; }
    }

    public class Data
    {
        public string Symbol { get; set; }
        public string Instrument_Name { get; set; }
        public string Exchange { get; set; }
        public string Mic_Code { get; set; }
        public string Exchange_Timezone { get; set; }
        public string Instrument_Type { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
    }
}