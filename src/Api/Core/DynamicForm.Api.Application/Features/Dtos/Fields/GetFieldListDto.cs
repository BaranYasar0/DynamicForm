﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Api.Application.Features.Dtos.Fields
{
    public class GetFieldListDto
    {
        public bool Required { get; set; } = true;
        public string Name { get; set; }
        public string DataType { get; set; } = "STRING";
    }
}
