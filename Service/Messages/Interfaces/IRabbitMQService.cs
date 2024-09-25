namespace APITestes.Service.Messages
{
    public interface IRabbitMQService
    {
        void PublishMessage(string message, int contagem);
    }
}
