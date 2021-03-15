using System;
using NetDevPack.Messaging;

namespace ProductApi.Domain.Commands.ProductsCommands
{
    public abstract class ProductCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public decimal Value { get; protected set; }
        public string Image { get; protected set; }
    }
}
