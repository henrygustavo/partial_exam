namespace Worker
{
    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;
    using System;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            string rabbitmqUrl = Environment.GetEnvironmentVariable("DCS_RABBITMQ_URL");
            factory.Uri = new Uri(rabbitmqUrl);
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "events", durable: true, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0} and now you can process the product", message);
                };
                channel.BasicConsume(queue: "events", autoAck: true, consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
