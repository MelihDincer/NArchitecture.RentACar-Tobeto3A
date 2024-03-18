using Application.Features.Models.Dtos;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Models.Commands.Delete;

public class DeleteModelCommand : IRequest<DeletedModelResponse> , ICacheRemoverRequest
{
    public int Id { get; set; }
    public bool BypassCache { get; }
    public string CacheKey => "model-list";
}