using FluentValidation;
using LabSchoolApi.DTOs;
using System;
using LabSchoolApi.Models;

namespace LabSchoolApi.Validators
{
    public class PedagogoValidator : AbstractValidator<PedagogoDTO>
    {
        public PedagogoValidator()
        {
            RuleFor(x => x.Codigo).NotEmpty();
            RuleFor(x => x.Nome).NotEmpty().Length(1, 100);
            RuleFor(x => x.Telefone).NotEmpty().Length(1, 20);
            RuleFor(x => x.DataNascimento).NotEmpty().LessThan(DateTime.Now);
            RuleFor(x => x.CPF).NotEmpty().Length(11);
            RuleFor(x => x.Atendimentos).GreaterThanOrEqualTo(0);
        }
    }
}
