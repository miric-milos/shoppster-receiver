using Newtonsoft.Json;
using System.Text;

namespace Shoppster.Receiver.Services.Deserializer
{
    public class MessageDeserializer : IMessageDeserializer
    {
        public T Deserialize<T>(byte[] message)
        {
            var jsonMessage = Encoding.UTF8.GetString(message);
            return JsonConvert.DeserializeObject<T>(jsonMessage);
        }
    }
}