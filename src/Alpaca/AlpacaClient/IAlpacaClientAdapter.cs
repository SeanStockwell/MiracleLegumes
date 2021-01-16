

namespace MiracleLegumes.Alpaca.AlpacaClient
{
    interface IAlpacaClientAdapter
    {
        void ListAssets();

        void GetLastQuote(string symbol);

        void GetAccountBalance();

        void GetPositions();

        void GetPositionBySymbol(string symbol);

        void BuyNSharesOfAsset(string symbol, int quantity);

        void SellNSharesOfAsset(string symbol, int quantity);

        void SellAllSharesOfAsset(string symbol);

        void CloseAllPositions();
    }
}