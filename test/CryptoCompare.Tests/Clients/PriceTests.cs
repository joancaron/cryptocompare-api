using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CryptoCompare.Tests.Clients
{
    [TestFixture]
    public class PriceTests
    {
        [Test]
        public async Task GetPriceHistorical_NoMarkets()
        {
            var client = CryptoCompareClient.Instance;
            var ticker = await client.Prices.HistoricalAsync("BTC",new []{"USD","XLM"},DateTimeOffset.Now.AddDays(-1));
            Assert.IsNotNull(ticker);
            Assert.Greater(ticker.Count, 0);
        }

        [Test]
        public async Task GetPriceHistorical_PoloniexKrakenMarkets()
        {
            var client = CryptoCompareClient.Instance;
            var ticker = await client.Prices.HistoricalAsync("BTC", new[] { "USD", "XLM" }, DateTimeOffset.Now.AddDays(-1),new []{"Poloniex","Kraken"});
            Assert.IsNotNull(ticker);
            Assert.Greater(ticker.Count, 0);
        }
    }
}
