namespace Web.Site.Product.Application.Service
{
    using System;
    using System.Text;
    using Newtonsoft.Json;
    using RabbitMQ.Client;

    public class AmqpApplicationService: IAmqpApplicationService
    {

        private readonly ConnectionFactory _connectionFactory;
        private const string QueueName = "EventsQueue";

        public AmqpApplicationService(string url)
        {
            _connectionFactory = new ConnectionFactory
            {
                Uri = new Uri(url)
            };
        }

        public void PublishMessage(object message)
        {
            using (var conn = _connectionFactory.CreateConnection())
            {
                using (var channel = conn.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: QueueName,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                    );

                    var jsonPayload = JsonConvert.SerializeObject(message);
                    var body = Encoding.UTF8.GetBytes(jsonPayload);

                    channel.BasicPublish(exchange: "",
                        routingKey: QueueName,
                        basicProperties: null,
                        body: body
                    );
                }
            }
        }
    }
}
