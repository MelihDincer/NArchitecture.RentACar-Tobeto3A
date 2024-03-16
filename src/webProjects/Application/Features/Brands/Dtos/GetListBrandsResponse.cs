﻿namespace Application.Features.Brands.Dtos;

public class GetListBrandsResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
