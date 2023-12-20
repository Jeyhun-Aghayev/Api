using Api.Entities.Base;
using System.Reflection.PortableExecutable;

namespace Api.Entities
{
    public class Car : BaseEntity
    {
        public string Description { get; set; }
        public int ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
    }
}
