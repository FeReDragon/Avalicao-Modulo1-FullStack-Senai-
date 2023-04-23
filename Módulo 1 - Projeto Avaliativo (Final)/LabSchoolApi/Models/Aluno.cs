using System;
using System.Collections.Generic;
using LabSchoolApi.Models;
using LabSchoolApi.Models.Enums;

namespace LabSchoolApi.Models
{
  public class Aluno : Pessoa
  {
      public double Nota { get; set; }
      public int QuantidadeAtendimentosPedagogicos { get; set; }
      public SituacaoMatricula SituacaoMatricula { get; set; }
      public ICollection<AtendimentoPedagogico>? AtendimentosPedagogicos { get; set; }
  }
}