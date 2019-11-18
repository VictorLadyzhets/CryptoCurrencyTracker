using System;
using System.Collections.Generic;
using System.Text;
using CryptoCurrencyTracker.Models.API;
namespace CryptoCurrencyTracker.Models
{
    class APIFactory
    {
        public static APIBase GetAPIModel(string type)
        {
            switch (type)
            {
                case "hitBtc":
                    return new HitBtcAPI();
                case "Binance":
                    return new BinanceAPI();
                default:
                    throw new Exception("No such API found");
            }
        }
    }
}
