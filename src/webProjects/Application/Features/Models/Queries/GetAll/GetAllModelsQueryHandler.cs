using Application.Features.Models.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetAll;

public partial class GetAllModelsQuery
{
    public class GetAllModelsQueryHandler : IRequestHandler<GetAllModelsQuery, List<GetAllModelsResponse>>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public GetAllModelsQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllModelsResponse>> Handle(GetAllModelsQuery request, CancellationToken cancellationToken)
        {
            List<Model> models = await _modelRepository.GetAllAsync(include: x => x.Include(x => x.Brand));
            List<GetAllModelsResponse> responses = _mapper.Map<List<GetAllModelsResponse>>(models);
            return responses;
        }
    }
}