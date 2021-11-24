namespace Shoppster.Receiver.Services.Deserializer
{
    public interface IMessageDeserializer
    {
        T Deserialize<T>(byte[] message);
    }
}