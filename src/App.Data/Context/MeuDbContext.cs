using Microsoft.EntityFrameworkCore;
using App.Business.Models;
using System.Linq;

namespace App.Datas.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
            {
                property.Relational().ColumnType = "varchar(100)";
            }


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly); //Aplicando o mapeamento das classes

            /*Quando for deletado um nó que tenha filhos, com essa configuração abaixo não é apagado seus filhos somente o nó em questão se não apaga o pai e seus filhos*/
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            base.OnModelCreating(modelBuilder);
        }
    }
}
