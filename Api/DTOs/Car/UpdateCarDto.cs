namespace Api.DTOs.Car
{
    public class UpdateCarDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }

    }
}
