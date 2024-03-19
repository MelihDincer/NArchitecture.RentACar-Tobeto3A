using Application.Features.Cars.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Queries.GetListDynamic;

public class GetListCarDynamicQueryHandler : IRequestHandler<GetListCarDynamicQuery, CarListModel>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetListCarDynamicQueryHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<CarListModel> Handle(GetListCarDynamicQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Car> cars = await _carRepository.GetListByDynamicAsync(request.Dynamic, include: c => c.Include(c => c.Model).Include(x => x.Model.Brand), index: request.PageRequest.Page, size: request.PageRequest.PageSize);
        CarListModel carListModel = _mapper.Map<CarListModel>(cars);
        return carListModel;
    }
}