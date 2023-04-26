using System.Data;
using System.Runtime.CompilerServices;
using DynamicForm.Api.Application.Features.Commands.Form.Create;
using DynamicForm.Api.Application.Features.Commands.Form.Update;
using DynamicForm.Api.Application.Features.Dtos.Forms;
using DynamicForm.Api.Application.Features.Queries.Forms;
using DynamicForm.Api.Application.Features.Queries.Forms.GetById;
using DynamicForm.Api.Application.Features.Queries.Forms.GetByUserId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicForm.Api.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : BaseController
    {

        //[Authorize(Roles = "deneme")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateFormCommand createFormCommand)
        {
            return Ok(await Mediator.Send(createFormCommand));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetFormListQuery query = new GetFormListQuery();
            IEnumerable<GetFormListDto>? result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("Güncelle")]
        public async Task<IActionResult> Update([FromBody] UpdateFormCommand updateFormCommand)
        {
            return Ok(await Mediator.Send(updateFormCommand));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> Get([FromQuery]int id)
        {
            GetFormByIdQuery query = new GetFormByIdQuery(){Id = id};
            GetFormListDto result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetByUserId")]
        public async Task<IActionResult> GetByUserId()
        {
            GetFormByUserIdQuery query = new GetFormByUserIdQuery();
            List<GetFormListDto> result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
