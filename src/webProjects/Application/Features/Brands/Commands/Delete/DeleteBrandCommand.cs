using Application.Features.Brands.Dtos;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Brands.Commands.Delete
{
    public class DeleteBrandCommand : IRequest<DeletedBrandResponse>, ICacheRemoverRequest
    {
        public int Id { get; set; }
        public int Interval => 1;

        public bool BypassCache { get; }
        public string CacheKey => "brand-list";
    }
}
