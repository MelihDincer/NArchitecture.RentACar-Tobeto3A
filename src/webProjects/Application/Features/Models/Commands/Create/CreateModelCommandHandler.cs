using Application.Features.Models.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands.Create;

public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, CreatedModelResponse>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public CreateModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<CreatedModelResponse> Handle(CreateModelCommand request, CancellationToken cancellationToken)
    {
        Model model = _mapper.Map<Model>(request);
        Model createdModel = await _modelRepository.AddAsync(model);
        CreatedModelResponse response = _mapper.Map<CreatedModelResponse>(createdModel);
        return response;
    }
}
