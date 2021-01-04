using App.Business.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Business.Core.Service
{
    public abstract class BaseService
    {
        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var valido = validacao.Validate(entidade);

            if (!valido.IsValid)
                return false;

            return true;
        }
    }
}
