using FluentValidation;
using LabSchoolApi.DTOs;
using LabSchoolApi.Models;
using System;

namespace LabSchoolApi.Validators
{
    public class AlunoValidator : AbstractValidator<AlunoDTO>
    {
        public AlunoValidator()
        {
            RuleFor(x => x.Codigo).NotEmpty();
            RuleFor(x => x.Nome).NotEmpty().Length(1, 100);
            RuleFor(x => x.Telefone).NotEmpty().Length(1, 20);
            RuleFor(x => x.DataNascimento).NotEmpty().LessThan(DateTime.Now);
            RuleFor(x => x.Cpf).NotEmpty().Length(11);
            RuleFor(x => x.Nota).InclusiveBetween(0, 100);
            RuleFor(x => x.Atendimentos).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Situacao).NotNull();
        }
    }
}
