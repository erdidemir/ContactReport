using EventBus.Messages.Commons;
using EventBus.Messages.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RaporConsumer.MesageBroker
{
    public static class Message
    {
        public static void SendMesage(RaporUpdateEvent raporUpdateEvent)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: EventBusConstants.RaporUpdateQueue,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = JsonSerializer.Serialize(raporUpdateEvent);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: EventBusConstants.RaporUpdateQueue,
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
