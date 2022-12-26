namespace MainConsole;

public class CurrentPriceClass
{
    public class Root
    {
        public List<Price> Prices { get; set; }
    }

    public class Price
    {
        public string price { get; set; }
    }
}