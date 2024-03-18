using Application.Features.Models.Models;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;

namespace Application.Features.Models.Queries.GetListDynamic;

public class GetListModelDynamicQuery : IRequest<ModelListModel>
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Dynamic { get; set; }
}
