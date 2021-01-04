using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Business.Models.Financas.Validations
{
    public class ContaValidation : AbstractValidator<Conta>
    {
        public ContaValidation()
        {
            RuleFor(f => DataValida(f.DataCadastro)).Equal(false)
                .WithMessage("Erro ao cadastrar, {PropertyName} inválida!")
                .NotEmpty().WithMessage("Erro ao cadastrar, {PropertyName} inválida!");

            RuleFor(f => DataValida(f.DataVencimento)).Equal(false)
                .WithMessage("Erro ao cadastrar, {PropertyName} inválida!")
                .NotEmpty().WithMessage("Erro ao cadastrar, {PropertyName} inválida!");

            RuleFor(f => f.Descricao).Length(2, 200)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.")
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido.");

            RuleFor(f => f.Valor >= 0).Equal(false).WithMessage("O campo {PropertyName} não pode ser negativo.")
                .NotNull().NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido.");
        }

        private bool DataValida(DateTime data)
        {
            if (data == null)
                return false;
            else if (data < DateTime.Now)
                return false;

            return true;
        }
    }
}
