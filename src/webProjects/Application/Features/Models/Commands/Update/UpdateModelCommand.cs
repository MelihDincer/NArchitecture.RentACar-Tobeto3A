using Application.Features.Models.Dtos;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Models.Commands.Update;

public class UpdateModelCommand : IRequest<UpdatedModelResponse> , ICacheRemoverRequest
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public string Name { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => "model-list";
}