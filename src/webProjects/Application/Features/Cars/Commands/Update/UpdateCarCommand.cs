﻿using Application.Features.Cars.Dtos;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Cars.Commands.Update
{
    public class UpdateCarCommand : IRequest<UpdatedCarResponse>, ICacheRemoverRequest
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int ModelYear { get; set; }
        public string Plate { get; set; }
        public int State { get; set; }  // 1- Available 2- Rented 3-Under Maitenance
        public double DailyPrice { get; set; }

        public bool BypassCache { get; }
        public string CacheKey => "car-list";
    }
}