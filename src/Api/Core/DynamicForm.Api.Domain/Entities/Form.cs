using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Api.Domain.Entities
{
    public class Form:BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int CreatedBy { get; set; }
        public ICollection<Field>? Fields { get; set; }

        public Form() { }

        public Form( int createdBy,string? name=null, string? description=null):this()
        {
            Name = name;
            Description = description;
            CreatedBy = createdBy;
        }
    }
}
