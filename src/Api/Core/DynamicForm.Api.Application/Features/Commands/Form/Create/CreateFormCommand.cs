using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DynamicForm.Api.Application.Features.Dtos.Fields;
using DynamicForm.Api.Application.Features.Dtos.Form;
using DynamicForm.Api.Application.Repositories;
using DynamicForm.Api.Domain.Entities;
using MediatR;

namespace DynamicForm.Api.Application.Features.Commands.Form.Create
{
    public class CreateFormCommand : IRequest<CreatedFormDto>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int CreatedBy { get; set; } = 1;
        public ICollection<CreatedFieldDto>? CreatedFieldDtos { get; set; }
    }

    public class CreateFormCommandHandler : IRequestHandler<CreateFormCommand, CreatedFormDto>
    {
        private readonly IFormRepository _formRepository;
        private readonly IMapper _mapper;

        public CreateFormCommandHandler(IFormRepository formRepository, IMapper mapper)
        {
            _formRepository = formRepository;
            _mapper = mapper;
        }

        public async Task<CreatedFormDto> Handle(CreateFormCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Form mappedForm = _mapper.Map<Domain.Entities.Form>(request);

            var addedForm = await _formRepository.AddAsync(mappedForm);
            CreatedFormDto toBeMappedForm = _mapper.Map<CreatedFormDto>(addedForm);
            return toBeMappedForm;
        }
    }
}
