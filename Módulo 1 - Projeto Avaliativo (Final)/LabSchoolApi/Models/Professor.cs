using System;
using System.Collections.Generic;
using LabSchoolApi.Models.Enums;

namespace LabSchoolApi.Models
{
    public class Professor : Pessoa
    {
        public string? FormacaoAcademica { get; set; }
        public int ExperienciaDesenvolvimento { get; set; }
        public StatusProfessor Estado { get; set; }
    }
}

