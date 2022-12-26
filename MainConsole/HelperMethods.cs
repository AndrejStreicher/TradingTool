namespace MainConsole;

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
        if (Directory.Exists(@".\Downloaded data\price") == false)
        {
            Directory.CreateDirectory(@".\Downloaded data\price");
        }

        if (Directory.Exists(@".\Downloaded data\quote") == false)
        {
            Directory.CreateDirectory(@".\Downloaded data\quote");
        }

        if (Directory.Exists(@".\Downloaded data\technicalIndicator") == false)
        {
            Directory.CreateDirectory(@".\Downloaded data\technicalIndicator");
        }

        if (Directory.Exists(@".\Downloaded data\timeSeries") == false)
        {
            Directory.CreateDirectory(@".\Downloaded data\timeSeries");
        }

        if (Directory.Exists(@".\Available symbols") == false)
        {
            Directory.CreateDirectory(@".\Available symbols");
        }

        if (Directory.Exists(@".\Downloaded data\symbolLookup") == false)
        {
            Directory.CreateDirectory(@".\Downloaded data\symbolLookup");
        }
    }

    public static async Task UpdateLists()
    {
        if (File.Exists(@".\Available symbols\stockSymbols.json") &&
            File.Exists(@".\Available symbols\forexSymbols.json") &&
            File.Exists(@".\Available symbols\cryptoSymbols.json") &&
            File.Exists(@".\Available symbols\etfSymbols.json") &&
            File.Exists(@".\Available symbols\indexSymbols.json"))
        {
            FileInfo stockSymbolInfo = new FileInfo(@".\Available symbols\stockSymbols.json");
            DateTime stockSymbolCreationTime = stockSymbolInfo.CreationTime;
            FileInfo forexSymbolInfo = new FileInfo(@".\Available symbols\forexSymbols.json");
            DateTime forexSymbolCreationTime = forexSymbolInfo.CreationTime;
            FileInfo cryptoSymbolInfo = new FileInfo(@".\Available symbols\cryptoSymbols.json");
            DateTime cryptoSymbolCreationTime = cryptoSymbolInfo.CreationTime;
            FileInfo etfSymbolInfo = new FileInfo(@".\Available symbols\etfSymbols.json");
            DateTime etfSymbolCreationTime = etfSymbolInfo.CreationTime;
            FileInfo indexSymbolInfo = new FileInfo(@".\Available symbols\indexSymbols.json");
            DateTime indexSymbolCreationTime = indexSymbolInfo.CreationTime;
            DateTime currentTime = DateTime.Now;
            TimeSpan timeDifferenceStock = currentTime - stockSymbolCreationTime;
            TimeSpan timeDifferenceForex = currentTime - forexSymbolCreationTime;
            TimeSpan timeDifferenceCrypto = currentTime - cryptoSymbolCreationTime;
            TimeSpan timeDifferenceEtf = currentTime - etfSymbolCreationTime;
            TimeSpan timeDifferenceIndex = currentTime - indexSymbolCreationTime;
            if (timeDifferenceStock.TotalHours > 24 ||
                timeDifferenceForex.TotalHours > 24 ||
                timeDifferenceCrypto.TotalHours > 24 ||
                timeDifferenceEtf.TotalHours > 24 ||
                timeDifferenceIndex.TotalHours > 24)
            {
                DownloadLists();
                Console.WriteLine("Available symbols updated!");
            }
        }
        else
        {
            DownloadLists();
        }
    }

    private static async Task DownloadLists()
    {
        HttpRequests getStocks =
            new HttpRequests("stocks");
        string stockSymbols = await getStocks.ApiCall();
        HttpRequests getForexPairs = new HttpRequests("forex_pairs");
        string forexSymbols = await getForexPairs.ApiCall();
        HttpRequests getCrypto = new HttpRequests("cryptocurrencies");
        string cryptoSymbols = await getCrypto.ApiCall();
        HttpRequests getEtf = new HttpRequests("etf");
        string etfSymbols = await getEtf.ApiCall();
        HttpRequests getIndices = new HttpRequests("indices");
        string indicesSymbols = await getIndices.ApiCall();
        File.WriteAllText(@".\Available symbols\stockSymbols.json", stockSymbols);
        File.WriteAllText(@".\Available symbols\forexSymbols.json", forexSymbols);
        File.WriteAllText(@".\Available symbols\cryptoSymbols.json", cryptoSymbols);
        File.WriteAllText(@".\Available symbols\etfSymbols.json", etfSymbols);
        File.WriteAllText(@".\Available symbols\indicesSymbols.json", indicesSymbols);
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
                Console.WriteLine("TwelveDataAPI key not found, please enter it:");
                ApiKey = Console.ReadLine() ?? string.Empty;
            } while (ApiKey == string.Empty);

            File.WriteAllText(@".\TwelveDataAPI.txt", ApiKey);
        }
    }

    public static string FormatFilename(string fileName)
    {
        if (fileName.Contains(@"\"))
        {
            fileName = fileName.Replace(@"\", "-");
        }

        if (fileName.Contains(@"/"))
        {
            fileName = fileName.Replace(@"/", "-");
        }

        if (fileName.Contains("["))
        {
            fileName = fileName.Replace("[", "");
        }

        if (fileName.Contains("]"))
        {
            fileName = fileName.Replace("]", "");
        }

        if (fileName.Contains("'"))
        {
            fileName = fileName.Replace("'", "");
        }

        if (fileName.Contains(":"))
        {
            fileName = fileName.Replace(":", "-");
        }

        fileName = fileName.ToUpper();
        return fileName;
    }
}