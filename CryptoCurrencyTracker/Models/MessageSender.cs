using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
namespace CryptoCurrencyTracker.Models
{
    class MessageSender
    {
        public static void SendMessages(List<string> messages)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "CurrencyRates",
                                        durable: false, 
                                        exclusive: false, 
                                        autoDelete: false, 
                                        arguments: null);
                    foreach (var message in messages)
                    {
                        channel.BasicPublish(exchange: "",
                                   routingKey: "CurrencyRates",
                                   basicProperties: null,
                                   body: Encoding.UTF8.GetBytes(message.ToCharArray()));
                    }

                }
            }
        }
    }
}
