using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CryptoCurrencyTracker.Models.API;
using Newtonsoft.Json.Linq;

namespace CryptoCurrencyTracker.Models
{
    class HitBtcAPI : APIBase
    {

        protected override string BaseURL => @"https://api.hitbtc.com/api/2/public/ticker";

        protected override async Task<string> GetApiResponse(string currency)
        {
            using (WebClient client = new WebClient())
            {
                string url = String.Format("{0}/{1}" ,BaseURL, currency);
              
                var response = await client.DownloadStringTaskAsync(new Uri(url));
                return response;
            }
        }
        
        protected override string ParseResponse(string response)
        {
            JObject responseModel = JObject.Parse(response);
            return responseModel.SelectToken("last").Value<string>();
        }
    }
}
