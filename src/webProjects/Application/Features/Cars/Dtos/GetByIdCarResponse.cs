namespace Application.Features.Cars.Dtos;

public class GetByIdCarResponse
{
    public int Id { get; set; }
    public string ModelName { get; set; }
    public int ModelYear { get; set; }
    public string Plate { get; set; }
    public int State { get; set; }  // 1- Available 2- Rented 3-Under Maitenance
    public double DailyPrice { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}