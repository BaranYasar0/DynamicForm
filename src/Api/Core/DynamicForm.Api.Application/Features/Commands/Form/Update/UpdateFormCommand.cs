using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DynamicForm.Api.Application.Features.Dtos.Fields;
using DynamicForm.Api.Application.Features.Dtos.Forms;
using DynamicForm.Api.Application.Features.Rules;
using DynamicForm.Api.Application.Repositories;
using DynamicForm.Api.Application.Utilities.Pipelines;
using MediatR;

namespace DynamicForm.Api.Application.Features.Commands.Form.Update
{
    public class UpdateFormCommand : IRequest<UpdatedFormDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int CreatedBy { get; set; }
        public ICollection<CreatedFieldDto>? CreatedFieldDtos { get; set; }

        public string[] Roles => new[] { "deneme" };

    }

    public class UpdateFormCommandHandler : IRequestHandler<UpdateFormCommand, UpdatedFormDto>
    {
        private readonly IFormRepository _formRepository;
        private readonly IMapper _mapper;
        private readonly FormBusinessRules _formBusinessRules;

        public UpdateFormCommandHandler(IFormRepository formRepository, IMapper mapper, FormBusinessRules formBusinessRules)
        {
            _formRepository = formRepository;
            _mapper = mapper;
            _formBusinessRules = formBusinessRules;
        }

        public async Task<UpdatedFormDto> Handle(UpdateFormCommand request, CancellationToken cancellationToken)
        {
            await _formBusinessRules.UpdatedFormShouldBeExist(request.Id);

            Domain.Entities.Form existForm = _mapper.Map<Domain.Entities.Form>(request);
            Domain.Entities.Form updatedForm = await _formRepository.UpdateAsync(existForm);
            UpdatedFormDto result = _mapper.Map<UpdatedFormDto>(updatedForm);

            return result;
        }
    }
}
