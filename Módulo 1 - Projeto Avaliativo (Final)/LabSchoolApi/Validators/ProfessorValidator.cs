using FluentValidation;
using LabSchoolApi.DTOs;
using System;
using LabSchoolApi.Models;
using LabSchoolApi.Models.Enums;

namespace LabSchoolApi.Validators
{
    public class ProfessorValidator : AbstractValidator<ProfessorDTO>
    {
        public ProfessorValidator()
        {
            RuleFor(x => x.Codigo).NotEmpty();
            RuleFor(x => x.Nome).NotEmpty().Length(1, 100);
            RuleFor(x => x.Telefone).NotEmpty().Length(1, 20);
            RuleFor(x => x.DataNascimento).NotEmpty().LessThan(DateTime.Now);
            RuleFor(x => x.CPF).NotEmpty().Length(11);
            RuleFor(x => x.FormacaoAcademica).NotEmpty().Length(1, 200);
            RuleFor(x => x.ExperienciaDesenvolvimento).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Estado).IsInEnum();
        }
    }
}

