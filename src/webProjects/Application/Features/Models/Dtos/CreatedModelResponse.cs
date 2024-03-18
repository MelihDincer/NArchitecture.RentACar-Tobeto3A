namespace Application.Features.Models.Dtos;

public class CreatedModelResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BrandId { get; set; }
    public string BrandName { get; set; }
    public DateTime CreatedDate { get; set; }
}