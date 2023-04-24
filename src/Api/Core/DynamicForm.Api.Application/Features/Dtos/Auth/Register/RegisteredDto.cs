using DynamicForm.Api.Domain.Entities;
using DynamicForm.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Api.Application.Features.Dtos.Auth.Register
{
    public class RegisteredDto
    {
        public AccessToken AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
