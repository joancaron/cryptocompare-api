using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CryptoCompare;

using Xunit;

namespace Cryptocompare.Integration.Tests.Clients
{
    public class PriceClientTests
    {
        [Fact]
        public async Task CanCallSingleSymbolPriceEndpoint()
        {
            var result = await CryptoCompareClient.Instance.Prices.SingleAsync("BTC", new[] { "USD", "JPY", "EUR" });
            Assert.NotNull(result);
        }
    }
}
