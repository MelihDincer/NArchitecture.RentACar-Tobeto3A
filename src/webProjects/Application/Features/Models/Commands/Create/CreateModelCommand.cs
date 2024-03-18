using Application.Features.Models.Dtos;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Models.Commands.Create;

public class CreateModelCommand : IRequest<CreatedModelResponse> , ICacheRemoverRequest
{
    public int BrandId { get; set; }
    public string Name { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => "model-list";
}
