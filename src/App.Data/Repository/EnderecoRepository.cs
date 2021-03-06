﻿using App.Business.Interfaces;
using App.Business.Models;
using App.Datas.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class EnderecoRepository: Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MeuDbContext db):base(db)
        {

        }

        public Task<IEnumerable<Endereco>> ObterEnderecoPorFornecedor(Guid fonecedorId)
        {
            throw new NotImplementedException();
        }
    }
}
