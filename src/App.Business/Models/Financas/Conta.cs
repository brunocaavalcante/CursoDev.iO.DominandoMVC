using System;
using System.Collections.Generic;
using System.Text;

namespace App.Business.Models.Financas
{
    public class Conta : Entity
    {
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public Natureza Natureza { get; set; }
        public Status Status { get; set; }
    }
}
