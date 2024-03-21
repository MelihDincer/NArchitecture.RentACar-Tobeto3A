using Application.Features.Models.Commands.Create;
using Application.Features.Models.Commands.Delete;
using Application.Features.Models.Commands.Update;
using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Models.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Model, CreateModelCommand>().ReverseMap();
            CreateMap<Model, CreatedModelResponse>().ForMember(c => c.BrandName, opt => opt.MapFrom(c => c.Brand.Name)).ReverseMap();

            CreateMap<Model, DeleteModelCommand>().ReverseMap();
            CreateMap<Model, DeletedModelResponse>().ReverseMap();

            CreateMap<Model, UpdateModelCommand>().ReverseMap();
            CreateMap<Model, UpdatedModelResponse>().ReverseMap();

            CreateMap<Model, GetAllModelsResponse>().ReverseMap();
            CreateMap<Model, GetByIdModelResponse>().ReverseMap();

            CreateMap<IPaginate<Model>, ModelListModel>().ReverseMap();
        }
    }
}