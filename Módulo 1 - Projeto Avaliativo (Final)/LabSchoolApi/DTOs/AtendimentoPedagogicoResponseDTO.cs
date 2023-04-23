using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSchoolApi.DTOs
{
    public class AtendimentoPedagogicoResponseDTO
    {
        public AlunoDTO? Aluno { get; set; }
        public PedagogoDTO? Pedagogo { get; set; }
    }
}