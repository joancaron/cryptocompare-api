using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCompare
{
    public class ExchangeGeneralInfo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string LogoUrl { get; set; }
        public List<ItemType> ItemType { get; set; }
        public CentralizationType CentralizationType { get; set; }
        public string InternalName { get; set; }
        public Uri AffiliateUrl { get; set; }
        public string Country { get; set; }
        public bool OrderBook { get; set; }
        public bool Trades { get; set; }
        public string Description { get; set; }
        public string FullAddress { get; set; }
        public string Fees { get; set; }
        public string DepositMethods { get; set; }
        public string WithdrawalMethods { get; set; }
        public bool Sponsored { get; set; }
        public bool Recommended { get; set; }
        public Rating Rating { get; set; }
        public Totalvolume24H Totalvolume24H { get; set; }
    }

    public partial class Totalvolume24H
    {
        public double Btc { get; set; }
    }

    public partial class Rating
    {
        public long One { get; set; }
        public long Two { get; set; }
        public long Three { get; set; }
        public long Four { get; set; }
        public long Five { get; set; }
        public double Avg { get; set; }
        public long TotalUsers { get; set; }
    }

    public enum CentralizationType { Centralized, Decentralized };

    public enum ItemType { Cryptocurrency, Derivatives, Fiat, StableCoins, Tokens };
}
