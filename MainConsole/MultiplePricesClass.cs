namespace MainConsole;

public class MultiplePricesClass
{
    public class Root
    {
        public Dictionary<string, Price> Prices { get; set; }
    }

    public class Price
    {
        public string price { get; set; }
    }
}