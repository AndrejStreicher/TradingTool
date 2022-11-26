namespace MainConsole;

public class Backtest
{
    public static bool BuyingLong;
    public static bool SellingShort;

    public static void LongBuy(string datetime)
    {
        BuyingLong = true;
        Console.WriteLine($"Long trade: {datetime}");
    }

    public static void ShortSell(string datetime)
    {
        SellingShort = true;
        Console.WriteLine($"Short trade: {datetime}");
    }
}