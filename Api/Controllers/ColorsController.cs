using Api.DAL;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ColorsController(AppDbContext db)
        {
            _db = db;
        }

        public AppDbContext Db { get; }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Color> colors = await _db.Colors.ToListAsync();
            if (colors == null) return NotFound();
            return Ok(colors);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest();
            var color = await _db.Colors.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (color == null) return NotFound();
            return Ok(color);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Color color)
        {
            await _db.Colors.AddAsync(color);
            await _db.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, color);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, string name)
        {
            if (id <= 0) return BadRequest();
            var color = await _db.Colors.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (color == null) return NotFound();
            color.Name = name;
            await _db.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, color);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();
            var color = await _db.Colors.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (color == null) return NotFound();
            _db.Colors.Remove(color);
            return Ok();
        }
    }
}
