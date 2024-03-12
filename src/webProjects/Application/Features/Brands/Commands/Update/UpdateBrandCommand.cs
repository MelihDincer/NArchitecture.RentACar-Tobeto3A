using Application.Features.Brands.Dtos;
using MediatR;

namespace Application.Features.Brands.Commands.Update;

public class UpdateBrandCommand : IRequest<UpdatedBrandResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
}
