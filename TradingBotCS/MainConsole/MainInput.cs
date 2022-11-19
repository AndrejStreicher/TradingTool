namespace MainConsole
{
    internal class MainInput
    {
        private static string _apiKey = File.ReadAllText(@"C:\Projects\TradingBotCS\MainConsole\TwelveDataAPI.txt");

        private static async Task Main(string[] args)
        {
            WelcomeOptions();
            var firstInput = Console.ReadLine();
            switch (firstInput)
            {
                case "1":
                    Console.Clear();
                    GetTickerOptions();
                    string inputTwo = Console.ReadLine();
                    if (inputTwo == "1")
                    {
                        string responseJson = await GetFromApi.HttpRequestInfo(_apiKey,"price");
                    }
                    else if (inputTwo == "2")
                    {
                        string responseJson = await GetFromApi.HttpRequestTimeSeries(_apiKey);
                    }
                    else if (inputTwo == "3")
                    {
                        string responseJson = await GetFromApi.HttpRequestInfo(_apiKey,"quote");
                    }

                    break;
                case "2":
                    Console.Clear();
                    string responseJsonTech = await GetFromApi.HttpRequestTech(_apiKey);
                    break;
            }
        }

        private static void WelcomeOptions()
        {
            Console.WriteLine("Welcome! What would you like to do ?");
            Console.WriteLine("1.Get ticker info (current price, time-series, quote...)");
            Console.WriteLine("2.Get technical indicator");
            Console.WriteLine("3.Execute real-time strategy");
            Console.WriteLine("4.Backtest an existing strategy");
        }

        private static void GetTickerOptions()
        {
            Console.WriteLine("1. Current price");
            Console.WriteLine("2. Time-series");
            Console.WriteLine("3. Quote");
        }
    }
}