using EventBus.Messages.Commons;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RaporConsumer
{
    public class Worker : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private string _consumerTag;

        public Worker()
        {
           
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";

            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                channel.BasicConsume(EventBusConstants.RaporCreateQueue, false, consumer);
                consumer.Received += (sender, e) =>
                {
                    //e.Body : Kuyruktaki mesaj� verir.
                    var body = e.Body.ToArray();
                    var jsonString = Encoding.UTF8.GetString(body);

                    Console.WriteLine($"Json receievd as {jsonString}");

                    Console.Read();
                };
            }
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            //_channel.BasicCancel(_consumerTag);
            //_channel.Close();
            //_connection.Close();
            return base.StopAsync(cancellationToken);
        }
    }
}
