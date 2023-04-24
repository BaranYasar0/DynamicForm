using System.Data;
using System.Runtime.CompilerServices;
using DynamicForm.Api.Application.Features.Commands.Form.Create;
using DynamicForm.Api.Application.Features.Dtos.Forms;
using DynamicForm.Api.Application.Features.Queries.Forms;
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

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateFormCommand createFormCommand)
        {
            return Ok(await Mediator.Send(createFormCommand));
        }

        [Authorize(Roles = "deneme")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetFormListQuery query = new GetFormListQuery();
            IEnumerable<GetFormListDto>? result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
