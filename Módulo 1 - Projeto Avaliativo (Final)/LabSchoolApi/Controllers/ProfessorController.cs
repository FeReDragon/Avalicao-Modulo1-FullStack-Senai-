using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LabSchoolApi.Data;
using LabSchoolApi.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using LabSchoolApi.Models;

namespace LabSchoolApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessoresController : ControllerBase
    {
        private readonly LabSchoolDbContext _context;
        private readonly IMapper _mapper;

        public ProfessoresController(LabSchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var professores = await _context.Professores.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<ProfessorDTO>>(professores));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var professor = await _context.Professores.FindAsync(id);
            if (professor == null) return NotFound();

            return Ok(_mapper.Map<ProfessorDTO>(professor));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProfessorDTO professorDTO)
        {
            var professor = _mapper.Map<Professor>(professorDTO);
            _context.Professores.Add(professor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = professor.Codigo }, _mapper.Map<ProfessorDTO>(professor));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProfessorDTO professorDTO)
        {
            if (id != professorDTO.Codigo) return BadRequest();

            var professor = _mapper.Map<Professor>(professorDTO);
            _context.Entry(professor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessorExists(id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var professor = await _context.Professores.FindAsync(id);
            if (professor == null) return NotFound();

            _context.Professores.Remove(professor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfessorExists(int id)
        {
            return _context.Professores.Any(e => e.Codigo == id);
        }
    }
}

