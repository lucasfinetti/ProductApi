using System;
using NetDevPack.Domain;

namespace ProductApi.Domain.Models
{
    public class Product : Entity, IAggregateRoot
    {
        public Product(Guid id, string name, decimal value, string image)
        {
            Id = id;
            Name = name;
            Value = value;
            Image = image;
        }

        // Empty constructor for EF
        protected Product() { }

        public string Name { get; private set; }

        public decimal Value { get; private set; }

        public string Image { get; private set; }
    }
}
