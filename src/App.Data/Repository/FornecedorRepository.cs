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
    public class FornecedorRepository: Repository<Fornecedor>,IFornecedorRepository
    {
        public FornecedorRepository(MeuDbContext context) : base(context)
        {

        }
        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
           return await Db.Fornecedores.AsNoTracking().Include(c=>c.Endereco).FirstOrDefaultAsync(c=>c.Id == id)
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
