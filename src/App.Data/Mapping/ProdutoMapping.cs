using App.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Mapping
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id); //Definindo chave primaria

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)"); //Para usar o atributo HasColumnType temos que baixa o package  Install-Package Microsoft.EntityFrameworkCore.Relational

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(1000)"); //Para usar o atributo HasColumnType temos que baixa o package  Install-Package Microsoft.EntityFrameworkCore.Relational

            builder.Property(p => p.Imagem)
                .IsRequired()
                .HasColumnType("varchar(100)"); //Para usar o atributo HasColumnType temos que baixa o package  Install-Package Microsoft.EntityFrameworkCore.Relational

            builder.Property(p => p.Valor)
                .IsRequired()
                .HasColumnType("decimal(5, 2)"); 

            builder.ToTable("Produtos");
        }
    }
}
