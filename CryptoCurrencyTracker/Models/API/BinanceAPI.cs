using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CryptoCurrencyTracker.Models.API;
using Newtonsoft.Json.Linq;

namespace CryptoCurrencyTracker.Models.API
{
    class BinanceAPI : APIBase
    {
        protected override string BaseURL => @"https://api.binance.com/api/v3/ticker/price";

        protected override async Task<string> GetApiResponse(string currency)
        {
            using (WebClient client = new WebClient())
            {
                client.QueryString.Add("symbol", currency);

                
                var response = await client.DownloadStringTaskAsync(new Uri(BaseURL));
                return response;
            }
        }

        protected override string ParseResponse(string response)
        {
            JObject responseModel = JObject.Parse(response);
            return responseModel.SelectToken("price").Value<string>();
        }
    }
}
