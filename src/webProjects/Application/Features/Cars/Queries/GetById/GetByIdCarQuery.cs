using Application.Features.Cars.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Queries.GetById
{
    public class GetByIdCarQuery : IRequest<GetByIdCarResponse>
    {
        public int Id { get; set; }

        public class GetByIdCarQueryHandler : IRequestHandler<GetByIdCarQuery, GetByIdCarResponse>
        {
            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;

            public GetByIdCarQueryHandler(ICarRepository carRepository, IMapper mapper)
            {
                _carRepository = carRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdCarResponse> Handle(GetByIdCarQuery request, CancellationToken cancellationToken)
            {
                Car? car = await _carRepository.GetAsync(c => c.Id == request.Id, include: x => x.Include(x => x.Model));
                GetByIdCarResponse response = _mapper.Map<GetByIdCarResponse>(car);
                return response;
            }
        }
    }
}
