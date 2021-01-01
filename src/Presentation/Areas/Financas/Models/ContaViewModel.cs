using System;

namespace Presentation.Areas.Financas.Models
{
    public class ContaViewModel
    {
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public string Natureza { get; set; }
        public string Status { get; set; }
    }
}
