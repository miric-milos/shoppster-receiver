namespace Shoppster.Receiver.RabbitMQ.Options
{
    public interface IRabbitMQOptions
    {
        string HostName { get; set; }
        string ProductQueueName { get; set; }
        string ProductRoutingKey { get; set; }
    }

    public class RabbitMQOptions : IRabbitMQOptions
    {
        public string HostName { get; set; }
        public string ProductQueueName { get; set; }
        public string ProductRoutingKey { get; set; }
    }
}