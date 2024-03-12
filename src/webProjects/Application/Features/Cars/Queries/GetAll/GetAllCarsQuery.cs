using Application.Features.Cars.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Queries.GetAll;

public class GetAllCarsQuery : IRequest<List<GetAllCarsResponse>>
{
    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, List<GetAllCarsResponse>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetAllCarsQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllCarsResponse>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            List<Car> cars = await _carRepository.GetAllAsync(include: x => x.Include(x => x.Model));
            List<GetAllCarsResponse> responses = _mapper.Map<List<GetAllCarsResponse>>(cars);
            return responses;
        }
    }
}
