using Api.DAL;
using Api.Entities;
using Api.Repositories.Abstraction;

namespace Api.Repositories.Implementaion
{
    public class CarRepository: Repository<Car>, ICarRepository
    {
        public CarRepository(AppDbContext context):base(context)
        {

        }
    }
}
