namespace MainConsole
{
    internal class MainInput
    {
        private static async Task Main()
        {
            HelperMethods.LoadApiKey();
            while (true)
            {
                await MainMenu();
            }
        }


        private static async Task MainMenu()
        {
            HelperMethods.CreateDirectories();
            const string prompt = "Welcome! What would you like to do ?";
            string[] options =
            {
                "Get ticker info (current price, time-series, quote...)", "Get technical indicator",
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
                            string responseJsonPrice = await GetFromApi.HttpRequestInfo("price");
                            DataHandler.DataHandleJson(responseJsonPrice, "price");
                            break;
                        case 1:
                            string responseJsonTimeSeries = await GetFromApi.HttpRequestTimeSeries();
                            DataHandler.DataHandleJson(responseJsonTimeSeries, "timeSeries");
                            break;
                        case 2:
                            string responseJsonQuote = await GetFromApi.HttpRequestInfo("quote");
                            DataHandler.DataHandleJson(responseJsonQuote, "quote");
                            break;
                    }

                    break;
                case 1:
                    string responseJsonTech = await GetFromApi.HttpRequestTech();
                    DataHandler.DataHandleJson(responseJsonTech, "technicalIndicator");
                    break;
                case 2:
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
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}