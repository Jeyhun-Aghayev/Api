using Api.DTOs.Car;
using Api.Entities;
using AutoMapper;

namespace Api
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateCarDto, Car>();
            CreateMap<Car, CreateCarDto>();
            CreateMap<Car, UpdateCarDto>();
            CreateMap<UpdateCarDto, Car>();
        }
    }
}
