﻿namespace MainConsole
{
    internal class MainInput
    {
        private static string _apiKey = File.ReadAllText(@"C:\Projects\TradingBotCS\MainConsole\TwelveDataAPI.txt");

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
                "Execute real-time strategy", "Backtest an existing strategy","Exit"
            };
            Menu mainMenu = new Menu(prompt, options);
            int selectedItem = mainMenu.Run();
            switch (selectedItem)
            {
                case 0:
                    string promptInfo = "What info would you like ?";
                    string[] optionsInfo = { "Current price", "Time-series", "Quote" };
                    Menu infoMenu = new Menu(promptInfo, optionsInfo);
                    int selectedItemInfo = infoMenu.Run();
                    switch (selectedItemInfo)
                    {
                        case 0:
                            string responseJsonPrice = await GetFromApi.HttpRequestInfo(_apiKey, "price");
                            Console.WriteLine(responseJsonPrice);
                            Console.ReadLine();
                            break;
                        case 1:
                            string responseJsonTimeSeries = await GetFromApi.HttpRequestTimeSeries(_apiKey);
                            Console.WriteLine(responseJsonTimeSeries);
                            Console.ReadLine();
                            break;
                        case 2:
                            string responseJsonQuote = await GetFromApi.HttpRequestInfo(_apiKey, "quote");
                            Console.WriteLine(responseJsonQuote);
                            Console.ReadLine();
                            break;
                    }
                    break;
                case 1:
                    string responseJsonTech  = await GetFromApi.HttpRequestTech(_apiKey);
                    Console.WriteLine(responseJsonTech);
                    Console.ReadLine();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}