﻿using DynamicForm.Api.Domain.Entities;
using DynamicForm.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Api.Application.Features.Dtos.Auth.Login
{
    public class LoggedDto
    {
        public AccessToken? AccessToken { get; set; }
        public RefreshToken? RefreshToken { get; set; }

        public LoggedResponseDto CreateResponseDto()
        {
            return new() { AccessToken = AccessToken };
        }


        public class LoggedResponseDto
        {
            public AccessToken? AccessToken { get; set; }
        }
    }
}
