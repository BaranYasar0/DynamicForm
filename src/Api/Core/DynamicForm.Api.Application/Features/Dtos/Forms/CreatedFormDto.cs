using DynamicForm.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Api.Application.Features.Dtos.Fields;

namespace DynamicForm.Api.Application.Features.Dtos.Form
{
    public class CreatedFormDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int CreatedBy { get; set; }
        public ICollection<CreatedFieldDto>? CreatedFieldDtos { get; set; }
    }
}
