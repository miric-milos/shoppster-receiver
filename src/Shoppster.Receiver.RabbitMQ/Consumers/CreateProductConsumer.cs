using RabbitMQ.Client;
using System;

namespace Shoppster.Receiver.RabbitMQ.Consumers
{
    public class CreateProductConsumer : DefaultBasicConsumer
    {
        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, ReadOnlyMemory<byte> body)
        {
            Console.WriteLine($"[{DateTime.Now}] Received message");
        }
    }
}