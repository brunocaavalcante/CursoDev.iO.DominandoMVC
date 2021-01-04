using App.Business.Models.Financas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Business.Interfaces.Financas
{
    public interface IFinancaRepository:IRepository<Conta>
    {
        Task<IEnumerable<Conta>> ObterProdutosPorFornecedor(Guid fonecedorId);
        Task<IEnumerable<Conta>> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim);
        Task<Conta> ObeterContas(Guid id);
    }
}
