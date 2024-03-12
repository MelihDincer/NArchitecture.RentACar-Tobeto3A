using Application.Features.Cars.Dtos;
using MediatR;

namespace Application.Features.Cars.Commands.Delete;

public class DeleteCarCommand : IRequest<DeletedCarResponse>
{
    public int Id { get; set; }
}