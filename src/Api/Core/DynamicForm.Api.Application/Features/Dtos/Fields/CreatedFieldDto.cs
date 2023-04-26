using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Api.Application.Features.Dtos.Fields
{
    public class CreatedFieldDto
    {
        public bool Required { get; set; } = true;
        public string DataType { get; set; } = "STRING";
        public string Name { get; set; }
    }
}
