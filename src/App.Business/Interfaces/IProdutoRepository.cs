using App.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Business.Interfaces
{
    public interface IProdutoRepository:IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fonecedorId);
        Task<IEnumerable<Produto>> ObterProdutosFornecedores();
        Task<Produto> ObeterProdutoFornecedor(Guid id);
    }
}
