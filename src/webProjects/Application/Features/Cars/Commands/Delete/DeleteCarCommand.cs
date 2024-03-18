using Application.Features.Cars.Dtos;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Cars.Commands.Delete;

public class DeleteCarCommand : IRequest<DeletedCarResponse>, ICacheRemoverRequest
{
    public int Id { get; set; }
    public bool BypassCache { get; }
    public string CacheKey => "car-list";
}