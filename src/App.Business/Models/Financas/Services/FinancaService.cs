using App.Business.Core.Service;
using App.Business.Interfaces.Financas;
using App.Business.Models.Financas.Validations;
using System;
using System.Threading.Tasks;

namespace App.Business.Models.Financas.Services
{
    public class FinancaService : BaseService, IFinancaService
    {
        public readonly IFinancaRepository _contaRepository;
        public FinancaService(IFinancaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }
        public async Task AdicionarConta(Conta conta)
        {
            if (!ExecutarValidacao(new ContaValidation(), conta)) return;

            await _contaRepository.Adicionar(conta);
        }

        public Task AtualizarConta(Conta conta)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task ExcluirConta(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
