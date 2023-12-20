using Api.DAL;
using Api.DTOs.Car;
using Api.Entities;
using Api.Repositories.Abstraction;
using Api.Repositories.Implementaion;
using Api.Services.Implimentations;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ICarService _service;

        public CarsController(ICarService service, AppDbContext db)
        {
            _service = service;
            _db = db;
        }

        public AppDbContext Db { get; }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var cars = await _service.GetAllAsync();
            if(cars==null) return NotFound();
            return Ok(cars);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cars = await _service.GetByIdAsync(id);
            if (cars == null) return NotFound();
            return Ok(cars);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateCarDto car)
        {
            await _service.Create(car);
            return StatusCode(StatusCodes.Status201Created,car);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateCarDto dto)
        {/*
            if (dto.Id <= 0) return BadRequest();

            var cars = await _db.Cars.Where(c => c.Id == id).Include(c => c.Brand).Include(c => c.Color).FirstOrDefaultAsync();
            if (cars == null) return NotFound();
            if(await _db.Brands.AnyAsync(c=>c.Id == brandId)) {return NotFound();}
            if(await _db.Colors.AnyAsync(c=>c.Id == colorid)) {return NotFound();}
            cars.Description= des;
            cars.DailyPrice= DailyPrice;
            cars.BrandId= brandId;
            cars.ColorId= colorid;
            cars.ModelYear = ModelYear;
            await _service.Update(cars);
            await _service.SaveChangesAsync();*/
            return StatusCode(StatusCodes.Status201Created/*, cars*/);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();
            var car = await _service.GetByIdAsync(id);
            if (car == null) return NotFound();
            _service.Delete(car);
           // await _service.SaveChangesAsync();
            return Ok();
        }
    }
}
