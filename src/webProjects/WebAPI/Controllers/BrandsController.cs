using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetAll;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetListDynamic;
using Application.Features.Brands.Queries.GetListPagination;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await Mediator.Send(new GetAllBrandsQuery()));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdBrandQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateBrandCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteBrandCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateBrandCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("Pagination")]
        public async Task<IActionResult> GetListPagination([FromQuery] PageRequest pageRequest)
        {
            GetListPaginationBrandQuery getListPaginationBrandQuery = new() { PageRequest = pageRequest };
            return Ok(await Mediator.Send(getListPaginationBrandQuery));
        }

        [HttpPost("Dynamic")]
        public async Task<IActionResult> GetListDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListBrandDynamicQuery brandDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
            return Ok(await Mediator.Send(brandDynamicQuery));
        }
    }
}