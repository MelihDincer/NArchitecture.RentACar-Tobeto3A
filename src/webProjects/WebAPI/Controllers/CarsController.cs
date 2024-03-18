using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Commands.Delete;
using Application.Features.Cars.Commands.Update;
using Application.Features.Cars.Models;
using Application.Features.Cars.Queries.GetAll;
using Application.Features.Cars.Queries.GetById;
using Application.Features.Cars.Queries.GetListDynamic;
using Application.Features.Cars.Queries.GetListPagination;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : BaseController
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await Mediator.Send(new GetAllCarsQuery()));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdCarQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateCarCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteCarCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCarCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("Pagination")]
        public async Task<IActionResult> GetListPagination([FromQuery] PageRequest pageRequest)
        {
            GetListPaginationCarQuery query = new() { PageRequest = pageRequest };
            CarListModel result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("Dynamic")]
        public async Task<IActionResult> GetListDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListCarDynamicQuery carDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
            CarListModel result = await Mediator.Send(carDynamicQuery);
            return Ok(result);
        }
    }
}