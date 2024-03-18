using Application.Features.Models.Commands.Create;
using Application.Features.Models.Commands.Delete;
using Application.Features.Models.Commands.Update;
using Application.Features.Models.Models;
using Application.Features.Models.Queries.GetAll;
using Application.Features.Models.Queries.GetById;
using Application.Features.Models.Queries.GetListDynamic;
using Application.Features.Models.Queries.GetListPagination;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await Mediator.Send(new GetAllModelsQuery()));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdModelQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateModelCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteModelCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateModelCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("Pagination")]
        public async Task<IActionResult> GetListPagination([FromQuery] PageRequest pageRequest)
        {
            GetListPaginationModelQuery query = new() { PageRequest = pageRequest };
            ModelListModel result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("Dynamic")]
        public async Task<IActionResult> GetListDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListModelDynamicQuery modelDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
            ModelListModel result = await Mediator.Send(modelDynamicQuery);
            return Ok(result);
        }
    }
}