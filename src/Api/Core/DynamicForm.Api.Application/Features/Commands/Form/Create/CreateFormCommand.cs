using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DynamicForm.Api.Application.Extensions;
using DynamicForm.Api.Application.Features.Dtos.Fields;
using DynamicForm.Api.Application.Features.Dtos.Form;
using DynamicForm.Api.Application.Repositories;
using DynamicForm.Api.Application.Services.Interfaces;
using DynamicForm.Api.Application.Utilities.Pipelines;
using DynamicForm.Api.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace DynamicForm.Api.Application.Features.Commands.Form.Create
{
    public class CreateFormCommand : IRequest<CreatedFormDto>,ISecuredRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<CreatedFieldDto>? CreatedFieldDtos { get; set; }
        
        //deneme rolüne sahip kişiler ekleme yapabilir.
        public string[] Roles => new[] { "deneme" };
    }

    public class CreateFormCommandHandler : IRequestHandler<CreateFormCommand, CreatedFormDto>
    {
        private readonly IFormRepository _formRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserService _userService;

        public CreateFormCommandHandler(IFormRepository formRepository, IMapper mapper, IHttpContextAccessor contextAccessor, IUserService userService)
        {
            _formRepository = formRepository;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _userService = userService;
        }

        public async Task<CreatedFormDto> Handle(CreateFormCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Form mappedForm = _mapper.Map<Domain.Entities.Form>(request);
            
            //mappedForm.CreatedBy = _contextAccessor.HttpContext.User.GetUserId();
            mappedForm.CreatedBy = Convert.ToInt32(_contextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value);
            //mappedForm.CreatedBy = _userService.GetUserId();
            var addedForm = await _formRepository.AddAsync(mappedForm);
            CreatedFormDto toBeMappedForm = _mapper.Map<CreatedFormDto>(addedForm);
            return toBeMappedForm;
        }
    }
}
