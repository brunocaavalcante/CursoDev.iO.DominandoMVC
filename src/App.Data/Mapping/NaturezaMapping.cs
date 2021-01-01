using App.Business.Models.Financas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Mapping
{
    public class NaturezaMapping : IEntityTypeConfiguration<Natureza>
    {
        public void Configure(EntityTypeBuilder<Natureza> builder)
        {
            builder.HasKey(p => p.Id); //Definindo chave primaria

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)");
        }
    }
}
