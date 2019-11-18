using CryptoCurrencyTrackerCommon.Models;
using CryptoCurrencyTrackerCommon.Models.DataLayer;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace CryptoCurrencyDataLayer
{
    class Program
    {
        static void Main(string[] args)
        {

                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "CurrencyRates",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {

                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        if (!String.IsNullOrEmpty(message))
                        {
                                        using (var context = new CryptoCurrencyTrackerContext())
            {
                            RatesInfo messageInfo = JsonConvert.DeserializeObject<RatesInfo>(message);
                            RatesInfo rate = context.Rates.Where(x => x.ApiId == messageInfo.ApiId && x.CurrencyId == messageInfo.CurrencyId).FirstOrDefault();
                            try
                            {
                                if (rate!=null && rate.ID>0)
                                {
                                    rate.RateTime = messageInfo.RateTime;
                                    rate.Price = messageInfo.Price;
                                    context.Rates.Update(rate);
                                }
                                else
                                {
                                    context.Rates.Add(messageInfo);                      
                                }
                                context.SaveChanges();
                            }
                            catch(Exception e)
                            {
                                //TO DO Add logging here
                            }
            }
                        }


                    };
                    while (true)
                    {
                        channel.BasicConsume(queue: "CurrencyRates",
                        autoAck: true,
                        consumer: consumer);
                        Thread.Sleep(100);
                    }

            }
        }
    }
}
