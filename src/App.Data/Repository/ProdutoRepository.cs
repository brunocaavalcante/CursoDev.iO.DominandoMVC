using App.Business.Interfaces;
using App.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public async Task<Produto> ObeterProdutoFornecedor(Guid id)
        {
            return await Db.Produtos.AsNoTracking()
                .Include(f => f.Fornecedor) //Join tabela fornecedor
                .FirstOrDefaultAsync(p => p.Id == id); //Onde o id passado igual id do produto
        }

        public Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fonecedorId)
        {
            throw new NotImplementedException();
        }
    }
}
