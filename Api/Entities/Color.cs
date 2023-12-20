using Api.Entities.Base;

namespace Api.Entities
{
    public class Color : BaseEntity
    {
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
    }
}
