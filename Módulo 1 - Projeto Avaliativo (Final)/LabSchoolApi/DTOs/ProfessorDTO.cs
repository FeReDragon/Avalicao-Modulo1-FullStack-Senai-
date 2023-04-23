using System;
using LabSchoolApi.Models.Enums;

namespace LabSchoolApi.DTOs
{
    public class ProfessorDTO
    {
        public int Codigo { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? CPF { get; set; }
        public string? FormacaoAcademica { get; set; }
        public int ExperienciaDesenvolvimento { get; set; }
        public string? Estado { get; set; }
    }
}

