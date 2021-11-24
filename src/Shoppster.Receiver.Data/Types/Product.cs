using System;

namespace Shoppster.Receiver.Data.Types
{
    public class Product
    {
        public Guid Id { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
    }
}