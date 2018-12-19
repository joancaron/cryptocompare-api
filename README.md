# cryptocompare-api

[![Build status](https://dev.azure.com/joan-caron-oss/cryptocompare-api/_apis/build/status/cryptocompare-api-windows)](https://dev.azure.com/joan-caron-oss/cryptocompare-api/_build/latest?definitionId=1)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/2dec058efba4445ba2af6e0e54308758)](https://www.codacy.com/app/joancaron/cryptocompare-api?utm_source=github.com&utm_medium=referral&utm_content=joancaron/cryptocompare-api&utm_campaign=badger)
[![NuGet](https://img.shields.io/nuget/v/CryptoCompare.svg)](https://www.nuget.org/packages/CryptoCompare/)

![logo](https://raw.githubusercontent.com/joancaron/cryptocompare-api/master/cryptocompare_logo.png)

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
