using Application.Features.Models.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetById;

public class GetByIdModelQuery : IRequest<GetByIdModelResponse>
{
    public int Id { get; set; }
    public class GetByIdModelQueryHandler : IRequestHandler<GetByIdModelQuery, GetByIdModelResponse>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public GetByIdModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdModelResponse> Handle(GetByIdModelQuery request, CancellationToken cancellationToken)
        {
            Model? model = await _modelRepository.GetAsync(m => m.Id == request.Id, include: x => x.Include(x => x.Brand));
            GetByIdModelResponse response = _mapper.Map<GetByIdModelResponse>(model);
            return response;
        }
    }
}
