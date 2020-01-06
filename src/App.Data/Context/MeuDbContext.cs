using Microsoft.EntityFrameworkCore;
using App.Business.Models;

namespace App.Datas.Context
{
    class MeuDbContext : DbContext 
    {
        public MeuDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

    }
}
