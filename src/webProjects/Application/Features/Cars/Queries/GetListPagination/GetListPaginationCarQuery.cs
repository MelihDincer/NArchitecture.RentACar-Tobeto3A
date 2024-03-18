using Application.Features.Cars.Models;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Cars.Queries.GetListPagination;

public class GetListPaginationCarQuery:IRequest<CarListModel>,ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => "car-list";

    public TimeSpan? SlidingExpiration { get; }
}
