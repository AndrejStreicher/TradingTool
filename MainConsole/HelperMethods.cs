namespace MainConsole;

public class HelperMethods
{
    public static void ReturnToMenu()
    {
        Console.WriteLine("Press any key to return to main menu...");
        Console.ReadKey(true);
    }

    public static void CheckForDirectories()
    {
        if (Directory.Exists(@".\Data\price") == false)
        {
            Directory.CreateDirectory(@".\Data\price");
        }

        if (Directory.Exists(@".\Data\quote") == false)
        {
            Directory.CreateDirectory(@".\Data\quote");
        }
        if (Directory.Exists(@".\Data\technicalIndicator") == false)
        {
            Directory.CreateDirectory(@".\Data\technicalIndicator");
        }
        if (Directory.Exists(@".\Data\timeSeries") == false)
        {
            Directory.CreateDirectory(@".\Data\timeSeries");
        }
    }
}