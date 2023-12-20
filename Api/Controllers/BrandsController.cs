using Api.DAL;
using Api.DTOs.BrandDto;
using Api.Entities;
using Api.Repositories.Abstraction;
using Api.Repositories.Implementaion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IRepository<Brand> _repos;
        public BrandsController(IRepository<Brand> repos)
        {
            _repos = repos;
        }

   

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Brands = _repos.GetAllAsync();
            if (Brands == null) return NotFound();
            return Ok(Brands);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest();
            var Brand = await _repos.GetById(id);
            if (Brand == null) return NotFound();
            return Ok(Brand);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateBrandDto Brand)
        {
            Brand brand = new Brand();
            brand.Name= Brand.Name;
            await _repos.Create(brand);
            await _repos.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, brand);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, string name)
        {
            if (id <= 0) return BadRequest();
            var Brand = await _repos.GetById(id);
            if (Brand == null) return NotFound();
            Brand.Name = name;
            _repos.Update(Brand);
            await _repos.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, Brand);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();
            var Brand = await _repos.GetById(id);
            if (Brand == null) return NotFound();
            _repos.Delete(Brand);
            await _repos.SaveChangesAsync();
            return Ok();
        }
    }
}
