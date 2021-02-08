using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutosTeste.Domain.Models;

namespace ProdutosTeste.Infra.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Value)
                .HasColumnType("decimal(10,0)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Image)
                .HasColumnType("varchar(max)")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
