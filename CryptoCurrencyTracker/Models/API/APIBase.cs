using System.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencyTracker.Models.API
{
    abstract class APIBase
    {
        /// <summary>
        /// TODO ---- move to configuration
        /// </summary>
        protected abstract string BaseURL { get; }
        protected abstract Task<string> GetApiResponse(string currency);
        protected abstract string ParseResponse(string response);
        public virtual async Task<string> GetPriceForCurrency(string currency)
        {
            string apiResponse =  await GetApiResponse(currency);
            string price = ParseResponse(apiResponse);
            return price;
        }
    }
}
