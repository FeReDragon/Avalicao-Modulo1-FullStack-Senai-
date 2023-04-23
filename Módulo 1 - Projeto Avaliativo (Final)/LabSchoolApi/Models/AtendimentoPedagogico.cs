using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabSchoolApi.Models;
using LabSchoolApi.Models.Enums;

namespace LabSchoolApi.Models
{
    public class AtendimentoPedagogico
    {
        public class Request
        {
            [Required]
            public int? CodigoAluno { get; set; }
            
            [Required]
            public int? CodigoPedagogo { get; set; }
        }

        public class Response
        {
            public Aluno? Aluno { get; set; }
            public Pedagogo? Pedagogo { get; set; }
        }

        [Key]
        public int Codigo { get; set; }

        [Required]
        [ForeignKey("Aluno")]
        public int CodigoAluno { get; set; }

        [Required]
        [ForeignKey("Pedagogo")]
        public int CodigoPedagogo { get; set; }
        
        public Aluno? Aluno { get; set; }
        public Pedagogo? Pedagogo { get; set; }
    }
}
