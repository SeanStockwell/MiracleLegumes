

using System;
using System.Threading.Tasks;
using Alpaca.Markets;

namespace MiracleLegumes.Alpaca.AlpacaClient
{
    interface IAlpacaClientAdapter
    {
        void ListAssets();

        Task<ILastQuote> GetLastQuote(string symbol);

        Task<decimal> GetAccountBalance();

        void GetPositions();

        void GetPositionBySymbol(string symbol);

        void BuyNSharesOfAssetMarketOrder(string symbol, long quantity);

        void BuyNSharesOfAssetLimitOrder(string symbol, decimal limitPrice, long quantity);

        void SellNSharesOfAssetMarketOrder(string symbol, long quantity);

        void SellNSharesOfAssetLimitOrder(string symbol, decimal limitPrice, long quantity);

        void SellAllSharesOfAsset(string symbol);

        void CloseAllPositions();
    }
}