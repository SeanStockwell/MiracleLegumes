using System;
using System.Threading.Tasks;
using Alpaca.Markets;
using MiracleLegumes.Alpaca.AlpacaClient;

namespace MiracleLegumes
{
    class DemoProgram
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World! Let's try to get some market data");
            // TODO: Move keys to AppConfig or something (need to brush up on how .NET / c# programs read from configuration files)
            // https://stackoverflow.com/questions/1189364/reading-settings-from-app-config-or-web-config-in-net
            Console.WriteLine("Enter API Key");
            String apiKey = Console.ReadLine();
            Console.WriteLine("Enter API Secret");
            String apiSecret = Console.ReadLine();
            
            IAlpacaDataClient alpacaDataClient = Environments.Paper.GetAlpacaDataClient(new SecretKey(apiKey, apiSecret));
            IAlpacaTradingClient alpacaTradingClient = Environments.Paper.GetAlpacaTradingClient(new SecretKey(apiKey, apiSecret));
            IAlpacaClientAdapter alpacaClientAdapter = new AlpacaClientAdapterImpl(alpacaDataClient, alpacaTradingClient);
            //alpacaClientAdapter.GetLastQuote("TSLA");
            Console.WriteLine("hello?");
            //alpacaClientAdapter.GetPositions();
            await alpacaClientAdapter.GetAccountBalance();
            ILastQuote lastQuote = await alpacaClientAdapter.GetLastQuote("TSLA");
            Console.WriteLine($"TSLA had a bid price of {lastQuote.BidPrice} and an ask price of {lastQuote.AskPrice}");
        }
    }
}
