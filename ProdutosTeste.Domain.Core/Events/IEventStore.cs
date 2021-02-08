using NetDevPack.Messaging;

namespace ProdutosTeste.Domain.Core.Events
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
