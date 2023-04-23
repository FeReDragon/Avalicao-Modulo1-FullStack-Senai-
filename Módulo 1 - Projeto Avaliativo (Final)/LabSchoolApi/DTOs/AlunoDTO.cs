using System;
using LabSchoolApi.Models.Enums;

namespace LabSchoolApi.DTOs
{
    public class AlunoDTO
    {
        public int Codigo { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Cpf { get; set; }
        public double Nota { get; set; }
        public string? Situacao { get; set; }
        public int Atendimentos { get; set; }
    }
}

