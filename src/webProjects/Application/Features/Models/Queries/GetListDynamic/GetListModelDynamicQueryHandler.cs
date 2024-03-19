using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetListDynamic;

public class GetListModelDynamicQueryHandler : IRequestHandler<GetListModelDynamicQuery, ModelListModel>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public GetListModelDynamicQueryHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<ModelListModel> Handle(GetListModelDynamicQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Model> models = await _modelRepository.GetListByDynamicAsync(request.Dynamic, include: m => m.Include(c => c.Brand), index: request.PageRequest.Page, size: request.PageRequest.PageSize);
        ModelListModel modelListModel = _mapper.Map<ModelListModel>(models);
        return modelListModel;
    }
}
