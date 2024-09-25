using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text;

namespace APITestes.Service.Messages
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly RabbitMQConfig _config;

        public RabbitMQService(IOptions<RabbitMQConfig> config)
        {
            _config = config.Value;
        }

        public void PublishMessage(string message, int contagem)
        {
            var factory = new ConnectionFactory
            {
                HostName = _config.HostName,
                //Port = _config.Port,
                //UserName = _config.UserName,
                //Password = _config.Password
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            
            channel.QueueDeclare(queue: "message_queue",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            string messageWithCount = $"{message} - {contagem}";
            var body = Encoding.UTF8.GetBytes(messageWithCount);

            channel.BasicPublish(exchange: "",
                                routingKey: "message_queue",
                                basicProperties: null,
                                body: body);
            Console.WriteLine($" [x] Sent {messageWithCount}");
        }
    }
}
