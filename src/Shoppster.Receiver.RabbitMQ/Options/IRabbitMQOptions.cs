namespace Shoppster.Receiver.RabbitMQ.Options
{
    public interface IRabbitMQOptions
    {
        string HostName { get; set; }
        int Port { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string ProductQueueName { get; set; }
        string ProductRoutingKey { get; set; }
    }

    public class RabbitMQOptions : IRabbitMQOptions
    {
        public string HostName { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ProductQueueName { get; set; }
        public string ProductRoutingKey { get; set; }
    }
}