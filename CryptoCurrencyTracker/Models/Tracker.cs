using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CryptoCurrencyTrackerCommon.Models;
namespace CryptoCurrencyTracker.Models
{
    class Tracker
    {
        private List<ApiInfo> APIs { get; set; }
        private List<ExchangeCurrencyInfo> Currencies { get; set; }

        public Tracker(List<ApiInfo> apis, List<ExchangeCurrencyInfo> currencies)
        {
            APIs = apis;
            Currencies = currencies;
        }


        public void Start()
        {
            while (true)
            {
                ProcessStep();
                Thread.Sleep(100);
            }
        }

        public void End()
        {

        }
        private async void ProcessStep()
        {
            List<string> JsonData = await CollectData();
            MessageSender.SendMessages(JsonData);
        }

        public async Task<List<string>> CollectData()
        {
            List<string> jsonData = new List<string>();
            var tasks = new List<Task<string>>();
            foreach (var rate in Currencies)
            {
                foreach (var api in APIs)
                {
                    tasks.Add(Track(api, rate));
                }
            }
            var messages = await Task.WhenAll(tasks);
            foreach(var message in messages)
            {
                if(!String.IsNullOrEmpty(message))
                    jsonData.Add(message);
            }

            return jsonData;
        }


        private async Task<string> Track(ApiInfo api, ExchangeCurrencyInfo currency)
        {
            try
            {
                var response = await APIFactory.GetAPIModel(api.Name).GetPriceForCurrency(currency.Name);
                return JsonConvert.SerializeObject(new RatesInfo{ ApiId = api.ID, CurrencyId = currency.ID, Price = response, RateTime = DateTime.Now });
            }
            catch
            {
                return String.Empty;
            }
        }
    }
}
