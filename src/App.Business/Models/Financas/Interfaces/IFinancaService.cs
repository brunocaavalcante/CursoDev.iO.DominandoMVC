using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Models.Financas.Services
{
    public interface IFinancaService : IDisposable
    {
        Task AdicionarConta(Conta conta);
        Task AtualizarConta(Conta conta);
        Task ExcluirConta(Guid Id);
    }
}
