using System;
using LabSchoolApi.Data;
using LabSchoolApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using LabSchoolApi.DTOs;
using AutoMapper;
using LabSchoolApi.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace LabSchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoPedagogicoController : ControllerBase
    {
        private readonly LabSchoolDbContext _context;
        private readonly IMapper _mapper;

        public AtendimentoPedagogicoController(LabSchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPut]
        public async Task<IActionResult> RealizarAtendimento([FromBody] AtendimentoPedagogicoRequestDTO requestDto)
        {
            try
            {
                var aluno = await _context.Alunos.SingleOrDefaultAsync(a => a.Codigo == requestDto.CodigoAluno);
                if (aluno == null)
                {
                    throw new ArgumentException("Aluno não encontrado com o código informado.");
                }

                var pedagogo = await _context.Pedagogos.SingleOrDefaultAsync(p => p.Codigo == requestDto.CodigoPedagogo);
                if (pedagogo == null)
                {
                    throw new ArgumentException("Pedagogo não encontrado com o código informado.");
                }

                aluno.QuantidadeAtendimentosPedagogicos++;
                aluno.SituacaoMatricula = SituacaoMatricula.AtendimentoPedagogico;
                pedagogo.QuantidadeAtendimentosPedagogicosRealizados++;

                await _context.SaveChangesAsync();

                var responseDto = new AtendimentoPedagogicoResponseDTO
                {
                    Aluno = _mapper.Map<AlunoDTO>(aluno),
                    Pedagogo = _mapper.Map<PedagogoDTO>(pedagogo)
                };

                // Adicionando as propriedades faltantes
                responseDto.Aluno.Situacao = aluno.SituacaoMatricula.ToString();
                responseDto.Aluno.Atendimentos = aluno.QuantidadeAtendimentosPedagogicos;
                responseDto.Pedagogo.Atendimentos = pedagogo.QuantidadeAtendimentosPedagogicosRealizados;

                return Ok(responseDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Ocorreu um erro inesperado: {ex.Message}" });
            }
        }
    }
}
