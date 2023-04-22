using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DynamicForm.Api.Domain.Entities
{
    //[Owned]
    public class Field:BaseEntity
    {
        public bool Required { get; set; } = true;
        public string Name { get; set; }
        public string DataType { get; set; } = "STRING";

        public Field()
        {
                
        }

        public Field(bool required, string name, string dataType)
        {
            Required = required;
            Name = name;
            DataType = dataType;
        }
    }
}
