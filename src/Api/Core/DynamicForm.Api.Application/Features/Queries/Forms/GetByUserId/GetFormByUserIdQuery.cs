using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DynamicForm.Api.Application.Features.Dtos.Forms;
using DynamicForm.Api.Application.Features.Rules;
using DynamicForm.Api.Application.Repositories;
using DynamicForm.Api.Application.Services.Interfaces;
using DynamicForm.Api.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DynamicForm.Api.Application.Features.Queries.Forms.GetByUserId
{
    public class GetFormByUserIdQuery:IRequest<List<GetFormListDto>>
    {
    }
    public class GetFormByUserIdQueryHandler:IRequestHandler<GetFormByUserIdQuery, List<GetFormListDto>>
    {
        private readonly IFormRepository _formRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private FormBusinessRules _formBusinessRules;

        public GetFormByUserIdQueryHandler(IFormRepository formRepository, IMapper mapper, IUserService userService, FormBusinessRules formBusinessRules)
        {
            _formRepository = formRepository;
            _mapper = mapper;
            _userService = userService;
            _formBusinessRules = formBusinessRules;
        }


        public async Task<List<GetFormListDto>> Handle(GetFormByUserIdQuery request, CancellationToken cancellationToken)
        {
            await _formBusinessRules.UserShouldBeAuthenticated();
            List<Form> existForm = await _formRepository.GetListAsync(predicate: x => x.CreatedBy == _userService.GetUserId(),
                disableTracking: false, include: x => x.Include(y => y.Fields));

            List<GetFormListDto> mappedForm = _mapper.Map<List<GetFormListDto>>(existForm);
            return mappedForm;
        }
    }
}
