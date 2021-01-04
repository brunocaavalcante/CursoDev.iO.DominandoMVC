using App.Business.Interfaces.Financas;
using App.Business.Models.Financas;
using App.Datas.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class FinancaRepository : Repository<Conta>, IFinancaRepository
    {
        public FinancaRepository(MeuDbContext db) : base(db)
        {
        }
        public async Task<Conta> ObeterContas(Guid id)
        {
            return await Db.Contas.AsNoTracking()
                .Include(f => f.Natureza) //Join tabela Natureza
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<IEnumerable<Conta>> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Conta>> ObterProdutosPorFornecedor(Guid fonecedorId)
        {
            throw new NotImplementedException();
        }
    }
}
