namespace MainConsole
{
    internal class MainInput
    {
        private static async Task Main()
        {
            HelperMethods.LoadApiKey();
            HelperMethods.CreateDirectories();
            HelperMethods.UpdateLists();
            while (true)
            {
                await MainMenu();
            }
        }


        private static async Task MainMenu()
        {
            const string prompt = "Welcome! What would you like to do ?";
            string[] options =
            {
                "Get ticker info (current price, time-series, quote...)", "Get technical indicator", "Symbol search",
                "Backtest an existing strategy", "Exit"
            };
            Menu mainMenu = new Menu(prompt, options);
            int selectedItem = mainMenu.CreateMenu();
            switch (selectedItem)
            {
                case 0:
                    const string promptInfo = "What info would you like ?";
                    string[] optionsInfo = { "Current price", "Time-series", "Quote" };
                    Menu infoMenu = new Menu(promptInfo, optionsInfo);
                    int selectedItemInfo = infoMenu.CreateMenu();
                    switch (selectedItemInfo)
                    {
                        case 0:
                            await GetFromApi.HttpRequestInfo("price");
                            break;
                        case 1:
                            await GetFromApi.HttpRequestTimeSeries();
                            break;
                        case 2:
                            await GetFromApi.HttpRequestInfo("quote");
                            break;
                    }

                    break;
                case 1:
                    await GetFromApi.HttpRequestTech();
                    break;
                case 2:
                    await GetFromApi.HttpRequestLookup();
                    break;
                case 3:
                    const string promptBacktest = "Which strategy would you like to backtest ?";
                    string[] optionsBacktest = { "MACD Strategy" };
                    Menu backTestMenu = new Menu(promptBacktest, optionsBacktest);
                    int selectedItemBacktest = backTestMenu.CreateMenu();
                    switch (selectedItemBacktest)
                    {
                        case 0:
                            break;
                    }

                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}