using Application.Features.Cars.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Commands.Create;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CreatedCarResponse>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public CreateCarCommandHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<CreatedCarResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        Car car = _mapper.Map<Car>(request);
        Car createdBrand = await _carRepository.AddAsync(car);
        CreatedCarResponse response = _mapper.Map<CreatedCarResponse>(createdBrand);
        return response;
    }
}
