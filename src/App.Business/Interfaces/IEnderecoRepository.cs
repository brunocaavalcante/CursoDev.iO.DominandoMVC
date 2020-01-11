using App.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Business.Interfaces
{
    public interface IEnderecoRepository:IRepository<Endereco>
    {
        Task<IEnumerable<Endereco>> ObterEnderecoPorFornecedor(Guid fonecedorId);
    }
}
