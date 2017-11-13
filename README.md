# cryptocompare-api

[![Build status](https://ci.appveyor.com/api/projects/status/eliq53hhs8rsbq18?svg=true)](https://ci.appveyor.com/project/joancaron/cryptocompare-api)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/2dec058efba4445ba2af6e0e54308758)](https://www.codacy.com/app/joancaron/cryptocompare-api?utm_source=github.com&utm_medium=referral&utm_content=joancaron/cryptocompare-api&utm_campaign=badger)
[![NuGet](https://img.shields.io/nuget/v/CryptoCompare.svg)](https://www.nuget.org/packages/CryptoCompare/)

![logo](cryptocompare_logo.png)

An async-based CryptoCompare API client library for .NET and .NET Core

## Supported platforms

* .NET Core 1.0
* .NET Framework 4.5
* Mono 4.6
* Xamarin.iOS 10.0
* Xamarin.Android 7.0
* Universal Windows Platform 10
* Windows 8.0
* Windows Phone 8.1

## Installation
This CryptoCompare api wrapper library is available on NuGet

Package manager
````
Install-Package CryptoCompare
````

.NET CLI
````
dotnet add package CryptoCompare
````

Paket CLI
````
paket add CryptoCompare
````

### Dev packages
Unstable NuGet packages that track the develop branch of this repository are available at
[https://www.myget.org/F/ci-joancaron/api/v3/index.json](https://www.myget.org/F/ci-joancaron/api/v3/index.json)

## Basic usage
````csharp
// Using ctor
 var client = new CryptoCompareClient();
 var eth = await client.Coins.SnapshotFullAsync(7605);
 Console.WriteLine(eth.Data.General.Name);

// Using Singleton 
var btc = await CryptoCompareClient.Instance.Coins.SnapshotFullAsync(1182);
Console.WriteLine(eth.Data.General.Name);
````
### TODO: Api Endpoints

- [x] [Rate limits (hour)](https://min-api.cryptocompare.com/stats/rate/hour/limit)
- [x] [Rate limits (minute)](https://min-api.cryptocompare.com/stats/rate/minute/limit)
- [x] [Rate limits (second)](https://min-api.cryptocompare.com/stats/rate/second/limit)
- [x] [All Exchanges](https://min-api.cryptocompare.com/data/all/exchanges)
- [x] [All coins](https://min-api.cryptocompare.com/data/all/coinlist)
- [x] [Coin snapshot](https://www.cryptocompare.com/api/data/coinsnapshot/?fsym=BTC&tsym=USD)
- [x] [Coin snapshot full](https://www.cryptocompare.com/api/data/coinsnapshotfullbyid/?id=7605)
- [x] [Price single](https://min-api.cryptocompare.com/data/price?fsym=ETH&tsyms=BTC,USD,EUR)
- [x] [Price multi](https://min-api.cryptocompare.com/data/pricemulti?fsyms=ETH,DASH&tsyms=BTC,USD,EUR)
- [x] [Price multi full](https://min-api.cryptocompare.com/data/pricemultifull?fsyms=ETH,DASH&tsyms=BTC,USD,EUR)
- [x] [Price historical](https://min-api.cryptocompare.com/data/pricehistorical?fsym=BTC&tsyms=USD,EUR&ts=1452680400)
- [x] [Generate Average price](https://min-api.cryptocompare.com/data/generateAvg?fsym=BTC&tsym=USD&e=Coinbase,Kraken,Bitstamp,Bitfinex)
- [ ] [Day average price](https://min-api.cryptocompare.com/data/dayAvg?fsym=ETH&tsym=GBP&toTs=1487116800&extraParams=your_app_name)
- [ ] [Social stats](https://www.cryptocompare.com/api/data/socialstats/?id=1182)
- [x] [History (minute)](https://min-api.cryptocompare.com/data/histominute?fsym=BTC&tsym=USD&limit=60&aggregate=3&e=CCCAGG)
- [x] [History (hour)](https://min-api.cryptocompare.com/data/histohour?fsym=BTC&tsym=USD&limit=60&aggregate=3&e=CCCAGG)
- [x] [History (day)](https://min-api.cryptocompare.com/data/histoday?fsym=BTC&tsym=USD&limit=60&aggregate=3&e=CCCAGG)
- [ ] [Mining contracts](https://www.cryptocompare.com/api/data/miningcontracts/)
- [ ] [Minig equipments](https://www.cryptocompare.com/api/data/miningequipment/)
- [x] [Top pairs](https://min-api.cryptocompare.com/data/top/pairs?fsym=ETH)
- [x] [Top exchanges](https://min-api.cryptocompare.com/data/top/exchanges?fsym=BTC&tsym=USD)
- [x] [Top volumes](https://min-api.cryptocompare.com/data/top/volumes?tsym=BTC)
- [x] [Streamer subscription channels](https://min-api.cryptocompare.com/data/subs?fsym=BTC&tsyms=USD)
- [ ] [Subscription channels watchlist](https://min-api.cryptocompare.com/data/subsWatchlist?fsyms=BTC,ETH,XMR,MLN,DASH&tsym=USD&extraParams=your_app_name)
- [ ] [News providers](https://min-api.cryptocompare.com/data/news/providers)
- [ ] [News](https://min-api.cryptocompare.com/data/news/)


----------
