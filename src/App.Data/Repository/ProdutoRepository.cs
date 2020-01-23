using App.Business.Interfaces;
using App.Business.Models;
using App.Datas.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MeuDbContext db) : base(db)
        {
        }

        public async Task<Produto> ObeterProdutoFornecedor(Guid id)
        {
            return await Db.Produtos.AsNoTracking()
                .Include(f => f.Fornecedor) //Join tabela fornecedor
                .FirstOrDefaultAsync(p => p.Id == id); //Onde o id passado igual id do produto
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await Db.Produtos.AsNoTracking()
                  .Include(f => f.Fornecedor).ToListAsync<Produto>(); //Join tabela fornecedor
                   //Onde o id passado igual id do produto
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fonecedorId)
        {
            throw new NotImplementedException();
        }
    }
}
