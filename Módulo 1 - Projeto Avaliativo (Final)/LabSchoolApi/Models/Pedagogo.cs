using System;
using System.Collections.Generic;

namespace LabSchoolApi.Models
{
   public class Pedagogo : Pessoa
    {
        public int QuantidadeAtendimentosPedagogicosRealizados { get; set; }
         public ICollection<AtendimentoPedagogico>? AtendimentosPedagogicos { get; set; }
    }

}