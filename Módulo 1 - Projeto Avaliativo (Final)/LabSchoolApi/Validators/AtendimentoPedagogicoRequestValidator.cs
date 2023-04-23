using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using LabSchoolApi.DTOs;

namespace LabSchoolApi.Validators
{
    public class AtendimentoPedagogicoRequestValidator : AbstractValidator<AtendimentoPedagogicoRequestDTO>
    {
        public AtendimentoPedagogicoRequestValidator()
        {
            RuleFor(x => x.CodigoAluno).NotNull().WithMessage("Código do aluno é obrigatório.");
            RuleFor(x => x.CodigoPedagogo).NotNull().WithMessage("Código do pedagogo é obrigatório.");
        }
    }
}
