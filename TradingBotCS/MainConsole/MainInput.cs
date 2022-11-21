namespace MainConsole
{
    internal class MainInput
    {
        private static string _apiKey = File.ReadAllText(@".\TwelveDataAPI.txt");

        private static async Task Main(string[] args)
        {
            while (true)
            {
                await MainMenu();
            }
        }

        private static async Task MainMenu()
        {
            string prompt = "Welcome! What would you like to do ?";
            string[] options =
            {
                "Get ticker info (current price, time-series, quote...)", "Get technical indicator",
                "Execute real-time strategy", "Backtest an existing strategy", "Exit"
            };
            Menu mainMenu = new Menu(prompt, options);
            int selectedItem = mainMenu.CreateMenu();
            switch (selectedItem)
            {
                case 0:
                    string promptInfo = "What info would you like ?";
                    string[] optionsInfo = { "Current price", "Time-series", "Quote" };
                    Menu infoMenu = new Menu(promptInfo, optionsInfo);
                    int selectedItemInfo = infoMenu.CreateMenu();
                    switch (selectedItemInfo)
                    {
                        case 0:
                            string responseJsonPrice = await GetFromApi.HttpRequestInfo(_apiKey, "price");
                            DataHandler.DataHandle(responseJsonPrice);
                            break;
                        case 1:
                            string responseJsonTimeSeries = await GetFromApi.HttpRequestTimeSeries(_apiKey);
                            DataHandler.DataHandle(responseJsonTimeSeries);
                            break;
                        case 2:
                            string responseJsonQuote = await GetFromApi.HttpRequestInfo(_apiKey, "quote");
                            DataHandler.DataHandle(responseJsonQuote);
                            break;
                    }

                    break;
                case 1:
                    string responseJsonTech = await GetFromApi.HttpRequestTech(_apiKey);
                    DataHandler.DataHandle(responseJsonTech);
                    break;
                case 2:
                    break;
                case 3:
                    string promptBacktest = "Which strategy would you like to backtest ?";
                    string[] optionsBacktest = { "MACD Strategy" };
                    Menu BackTestMenu = new Menu(promptBacktest,optionsBacktest);
                    int selectedItemBacktest = BackTestMenu.CreateMenu();
                    switch (selectedItemBacktest)
                    {
                        case 0:
                            Backtest.MacdStrategy(_apiKey);
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