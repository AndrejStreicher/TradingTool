﻿namespace MainConsole;

public static class HelperMethods
{
    internal static string ApiKey;

    public static void ReturnToMenu()
    {
        Console.WriteLine("Press any key to return to main menu...");
        Console.ReadKey(true);
    }

    public static void CreateDirectories()
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

    public static void LoadApiKey()
    {
        if (File.Exists(@".\TwelveDataAPI.txt") && new FileInfo(@".\TwelveDataAPI.txt").Length > 0)
        {
            ApiKey = File.ReadAllText(@".\TwelveDataAPI.txt");
        }
        else if (File.Exists(@".\TwelveDataAPI.txt") == false || new FileInfo(@".\TwelveDataAPI.txt").Length == 0)
        {
            do
            {
                Console.WriteLine("API key not found, please enter it:");
                ApiKey = Console.ReadLine() ?? string.Empty;
            } while (ApiKey == string.Empty);
            File.WriteAllText(@".\TwelveDataAPI.txt", ApiKey);
        }
    }
}