using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Api.Application.Utilities.Pipelines
{
    public interface ISecuredRequest
    {
        public string[] Roles { get; }

    }
}
