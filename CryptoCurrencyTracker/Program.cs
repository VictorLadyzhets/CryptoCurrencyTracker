
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CryptoCurrencyTracker.Models;
using CryptoCurrencyTracker.Models.API;
using CryptoCurrencyTrackerCommon.Models;
using CryptoCurrencyTrackerCommon.Models.DataLayer;
namespace CryptoCurrencyTracker
{
    class Program
    {
        // TO DO:
        // ADD Logging
        // Not use While True
        // Add Configs
        // Add Comments
        // Research on optimazing
        static void Main(string[] args)
        {
            List<ApiInfo> apis = new List<ApiInfo>();
            List<ExchangeCurrencyInfo> currency = new List<ExchangeCurrencyInfo>();
            using (var context = new CryptoCurrencyTrackerContext())
            {
                apis = context.API.ToList();
                currency = context.Currency.ToList();
            }
            Tracker tracker = new Tracker(apis, currency);
            tracker.Start();

        }


    }
}
