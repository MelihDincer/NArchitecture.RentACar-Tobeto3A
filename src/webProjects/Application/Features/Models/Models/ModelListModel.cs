using Application.Features.Models.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Models.Models;

public class ModelListModel : BasePageableModel
{
    public List<GetAllModelsResponse> Items { get; set; }
}