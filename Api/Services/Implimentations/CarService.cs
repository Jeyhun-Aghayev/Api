using Api.DTOs.Car;
using Api.Entities;
using Api.Repositories.Abstraction;
using Api.Services.Interfaces;
using AutoMapper;

namespace Api.Services.Implimentations
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _repos;
        private readonly IMapper _mapper;

        public CarService(ICarRepository repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }

        public async Task Create(CreateCarDto cardto)
        {
            Car car = _mapper.Map<Car>(cardto);
            _repos.Create(car);
            await _repos.SaveChangesAsync();
        }

        
        public void Delete(Car car)
        {
            _repos.Delete(car);
        }

        public async Task<IQueryable<Car>> GetAllAsync()
        {
            return await _repos.GetAllAsync();
        }

        public Task<Car> GetByIdAsync(int id)
        {
            if (id <= 0) throw new Exception("Not Found");
            return _repos.GetById(id);
        }

        public async Task Update(UpdateCarDto cardto)
        {
            Car car = _mapper.Map<Car>(cardto);
            await _repos.Update(car);
            await _repos.SaveChangesAsync();
        }
    }
}
