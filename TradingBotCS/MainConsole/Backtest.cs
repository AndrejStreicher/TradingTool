namespace MainConsole;

public class Backtest
{
    public static bool _longBuy;
    public static bool _shortSell;

    public static void LongBuy(string datetime)
    {
        _longBuy = true;
        Console.WriteLine($"Long trade: {datetime}");
    }

    public static void ShortSell(string datetime)
    {
        _shortSell = true;
        Console.WriteLine($"Short trade: {datetime}");
    }
}