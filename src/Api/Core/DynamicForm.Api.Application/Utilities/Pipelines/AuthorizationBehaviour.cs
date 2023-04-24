﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Api.Application.Extensions;
using DynamicForm.Api.Application.Utilities.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace DynamicForm.Api.Application.Utilities.Pipelines
{
    public class AuthorizationBehaviour<TRequest,TResponse>:IPipelineBehavior<TRequest,TResponse> where TRequest : IRequest<TResponse>, ISecuredRequest
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthorizationBehaviour(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            List<string>? roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            
            if (roleClaims == null) throw new AuthorizationException("Claims not found.");


            var isNotMatchedARoleClaimWithRequestRoles = roleClaims.FirstOrDefault(roleClaim => request.Roles.Any(role => role == roleClaim));
            
            if (isNotMatchedARoleClaimWithRequestRoles=="") throw new AuthorizationException("You are not authorized.");

            TResponse response = await next();
            return response;
        }
    }
}
