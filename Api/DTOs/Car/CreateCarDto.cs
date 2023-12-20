namespace Api.DTOs.Car
{
    public class CreateCarDto
    {
        public string Description { get; set; }
        public int ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
    }
}
