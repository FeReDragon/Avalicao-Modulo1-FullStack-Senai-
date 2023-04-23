using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LabSchoolApi.Data;
using LabSchoolApi.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using LabSchoolApi.Models;
using LabSchoolApi.Models.Enums;
using System;
using System.Text.Json;
using System.Net;

namespace LabSchoolApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : ControllerBase
    {
        private readonly LabSchoolDbContext _context;
        private readonly IMapper _mapper;

        public AlunosController(LabSchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var alunos = await _context.Alunos.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<AlunoDTO>>(alunos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null) return NotFound();

            return Ok(_mapper.Map<AlunoDTO>(aluno));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AlunoDTO alunoDTO)
        {
            if (!Enum.TryParse<SituacaoMatricula>(alunoDTO.Situacao, true, out var situacaoMatricula))
            {
                return BadRequest("Valor inválido para o campo 'situacao'");
            }

            var aluno = _mapper.Map<Aluno>(alunoDTO);
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = aluno.Codigo }, _mapper.Map<AlunoDTO>(aluno));
        }


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AlunoDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int id, AtualizaSituacaoDTO atualizaSituacaoDTO)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null) return NotFound();

            if (Enum.TryParse<SituacaoMatricula>(atualizaSituacaoDTO.Situacao, true, out var situacaoMatricula))
            {
                aluno.SituacaoMatricula = situacaoMatricula;
                _context.Entry(aluno).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(id)) return NotFound();
                    throw;
                }

                return Ok(_mapper.Map<AlunoDTO>(aluno));
            }
            else
            {
                return BadRequest("Valor inválido para o campo 'situacao'");
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null) return NotFound();

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlunoExists(int id)
        {
            return _context.Alunos.Any(e => e.Codigo == id);
        }
    }
}

