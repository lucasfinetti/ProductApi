using NetDevPack.Data;
using ProdutosTeste.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProdutosTeste.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetById(Guid id);
        Task<Product> GetByName(string name);
        Task<IEnumerable<Product>> GetAll();

        void Add(Product product);
        void Update(Product product);
        void Remove(Product product);
    }
}
