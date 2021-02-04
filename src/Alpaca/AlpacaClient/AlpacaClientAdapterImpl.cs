using System.Threading.Tasks;
using Alpaca.Markets;

namespace MiracleLegumes.Alpaca.AlpacaClient {
    class AlpacaClientAdapterImpl : IAlpacaClientAdapter
    {
        //TODO: Thought is that during module injection (or whatever C# equivalent is), I'll use configuration file to get 
        //stage as well as the secret access keys (different config file)
        private IAlpacaDataClient alpacaDataClient;
        private IAlpacaTradingClient alpacaTradingClient;

        public AlpacaClientAdapterImpl(IAlpacaDataClient alpacaDataClient, IAlpacaTradingClient alpacaTradingClient) {
            this.alpacaDataClient = alpacaDataClient;
            this.alpacaTradingClient = alpacaTradingClient;
        }
        public void ListAssets()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ILastQuote> GetLastQuote(string symbol)
        {
            return await alpacaDataClient.GetLastQuoteAsync(symbol);
            
        }

        public async Task<decimal> GetAccountBalance()
        {
            // Get account info
            var account = await alpacaTradingClient.GetAccountAsync();

            // Check our current balance vs. our balance at the last market close
            var balance_change = account.Equity;
            decimal equity = account.Equity;
            System.Console.WriteLine($"Today's portfolio balance change: ${balance_change}");
            return balance_change;
        }

        public async void GetPositions()
        {
            var positions = await alpacaTradingClient.ListPositionsAsync();
            System.Console.WriteLine(positions.Count);

            // Print the quantity of shares for each position.
            foreach (var position in positions)
            {
                System.Console.WriteLine($"{position.Quantity} shares of {position.Symbol}.");
            }
        } 

        public void GetPositionBySymbol(string symbol)
        {
            throw new System.NotImplementedException();
        }

        public void BuyNSharesOfAssetMarketOrder(string symbol, long quantity)
        {
            
            alpacaTradingClient.PostOrderAsync(MarketOrder.Buy(symbol, quantity));
            throw new System.NotImplementedException();
        }

        public void BuyNSharesOfAssetLimitOrder(string symbol, decimal limitPrice, long quantity)
        {
            alpacaTradingClient.PostOrderAsync(LimitOrder.Buy(symbol, quantity, limitPrice));
            throw new System.NotImplementedException();
        }

        public void SellNSharesOfAssetMarketOrder(string symbol, long quantity)
        {
            alpacaTradingClient.PostOrderAsync(MarketOrder.Sell(symbol, quantity));
            throw new System.NotImplementedException();
        }

        public void SellNSharesOfAssetLimitOrder(string symbol, decimal limitPrice, long quantity)
        {
            alpacaTradingClient.PostOrderAsync(LimitOrder.Buy(symbol, quantity, limitPrice));
            throw new System.NotImplementedException();
        }

        public void SellAllSharesOfAsset(string symbol)
        {
            throw new System.NotImplementedException();
        }

        public void CloseAllPositions()
        {
            throw new System.NotImplementedException();
        }
    }
}