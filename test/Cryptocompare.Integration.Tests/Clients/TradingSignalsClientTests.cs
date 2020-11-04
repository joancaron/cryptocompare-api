using System.Threading.Tasks;

using CryptoCompare;

using Xunit;

namespace Cryptocompare.Integration.Tests.Clients
{
    public class TradingSignalsClientTests
    {
        [Fact]
        public async Task CanCallTradingSignalsBySymbolEndpoint()
        {
            var result = await CryptoCompareClient.Instance.TradingSignals.BySymbol("BTC");
            Assert.NotNull(result);
        }
    }
}