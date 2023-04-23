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
    public class PedagogosController : ControllerBase
    {
        private readonly LabSchoolDbContext _context;
        private readonly IMapper _mapper;

        public PedagogosController(LabSchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pedagogos = await _context.Pedagogos.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<PedagogoDTO>>(pedagogos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var pedagogo = await _context.Pedagogos.FindAsync(id);
            if (pedagogo == null) return NotFound();

            return Ok(_mapper.Map<PedagogoDTO>(pedagogo));
        }

        [HttpPost]
        public async Task<IActionResult> Create(PedagogoDTO pedagogoDTO)
        {
            var pedagogo = _mapper.Map<Pedagogo>(pedagogoDTO);
            _context.Pedagogos.Add(pedagogo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = pedagogo.Codigo }, _mapper.Map<PedagogoDTO>(pedagogo));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PedagogoDTO pedagogoDTO)
        {
            if (id != pedagogoDTO.Codigo) return BadRequest();

            var pedagogo = _mapper.Map<Pedagogo>(pedagogoDTO);
            _context.Entry(pedagogo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedagogoExists(id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pedagogo = await _context.Pedagogos.FindAsync(id);
            if (pedagogo == null) return NotFound();

            _context.Pedagogos.Remove(pedagogo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedagogoExists(int id)
        {
            return _context.Pedagogos.Any(e => e.Codigo == id);
        }
    }
}

