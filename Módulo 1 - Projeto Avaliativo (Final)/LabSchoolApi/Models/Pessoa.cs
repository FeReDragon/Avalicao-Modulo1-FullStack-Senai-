using System;
using System.Collections.Generic;

namespace LabSchoolApi.Models
{
    public abstract class Pessoa
    {
        public int Codigo { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? CPF { get; set; }
    }

}