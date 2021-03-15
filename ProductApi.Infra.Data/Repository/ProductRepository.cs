using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductApi.Domain.Interfaces;
using ProductApi.Domain.Models;
using ProductApi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;

namespace ProductApi.Infra.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        protected readonly ProdutoContext Db;
        protected readonly DbSet<Product> DbSet;

        public ProductRepository(ProdutoContext context)
        {
            Db = context;
            DbSet = Db.Set<Product>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<Product> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<Product> GetByName(string name)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public void Add(Product product)
        {
            DbSet.Add(product);
        }

        public void Update(Product product)
        {
            DbSet.Update(product);
        }

        public void Remove(Product product)
        {
            DbSet.Remove(product);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
