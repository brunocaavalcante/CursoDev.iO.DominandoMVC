using App.Business.Models.Financas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Mapping
{
    public class ContaMapping : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.HasKey(p => p.Id); //Definindo chave primaria

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)"); //Para usar o atributo HasColumnType temos que baixa o package  Install-Package Microsoft.EntityFrameworkCore.Relational

            builder.Property(p => p.DataCadastro)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(p => p.DataVencimento)
               .IsRequired()
               .HasColumnType("datetime");

            builder.Property(p => p.Valor)
                .IsRequired()
                .HasColumnType("decimal(5, 2)");

            // 1 : 1 => Fornecedores : Endereco  Relacionamento 1 para 1 entre fornecedores e enderecos
            builder.HasOne(c => c.Natureza); //Conta tem uma Natureza
                

            builder.ToTable("Contas");
        }
    }
}
