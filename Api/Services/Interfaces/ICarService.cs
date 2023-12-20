using Api.DTOs.Car;
using Api.Entities;

namespace Api.Services.Interfaces
{
    public interface ICarService
    {
        Task<IQueryable<Car>> GetAllAsync();
        Task<Car> GetByIdAsync(int id);
        Task Create(CreateCarDto car);
        Task Update(UpdateCarDto car);
        void Delete(Car CAr);
    }
}
