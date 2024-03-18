using Application.Features.Brands.Dtos;
using Application.Features.Models.Dtos;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Models.Queries.GetAll;

public partial class GetAllModelsQuery : IRequest<List<GetAllModelsResponse>>, ICachableRequest
{
    public bool BypassCache { get; }

    public string CacheKey => "model-list";

    public TimeSpan? SlidingExpiration { get; }
}
