using DynamicForm.Api.Application.Features.Dtos.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Api.Application.Features.Dtos.Forms
{
    public class GetFormListDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int CreatedBy { get; set; }
        public ICollection<GetFieldListDto>? GetFieldListDto { get; set; }
    }
}
