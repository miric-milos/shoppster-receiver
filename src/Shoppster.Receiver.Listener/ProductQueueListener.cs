using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Shoppster.Receiver.Data.Types;
using Shoppster.Receiver.RabbitMQ.Options;
using Shoppster.Receiver.Services.Deserializer;
using System;

namespace Shoppster.Receiver.Listener
{
    public class ProductQueueListener
    {
        private readonly IModel _model;
        private readonly IRabbitMQOptions _options;
        private readonly IMessageDeserializer _messageDeserializer;
        private readonly EventingBasicConsumer _consumer;

        public ProductQueueListener(ServiceProvider serviceProvider)
        {
            _options = serviceProvider.GetService<IRabbitMQOptions>();
            _model = serviceProvider.GetService<IModel>();
            _messageDeserializer = serviceProvider.GetService<IMessageDeserializer>();

            Console.WriteLine($"[{DateTime.Now}] Declaring queue: {_options.ProductQueueName}");
            _model.QueueDeclare(_options.ProductQueueName, exclusive: false, autoDelete: false);

            _consumer = new EventingBasicConsumer(_model);
            _consumer.Received += HandleMessage;
            _model.BasicConsume(_options.ProductQueueName, autoAck: false, _consumer);
        }

        private void HandleMessage(object sender, BasicDeliverEventArgs e)
        {
            if(e.RoutingKey != _options.ProductRoutingKey)
            {
                Console.WriteLine($"[{DateTime.Now}] Rejecting message for routing key: {e.RoutingKey}");
                _model.BasicReject(e.DeliveryTag, requeue: false);
                return;
            }

            if(e.Body.IsEmpty)
            {
                throw new ArgumentNullException($"[{DateTime.Now}] Message body is empty");
            }

            var message = _messageDeserializer.Deserialize<Product>(e.Body.ToArray());

            _model.BasicAck(e.DeliveryTag, multiple: false);
            Console.WriteLine($"[{DateTime.Now}] Message acknowledged: {JsonConvert.SerializeObject(message)}");
        }
    }
}