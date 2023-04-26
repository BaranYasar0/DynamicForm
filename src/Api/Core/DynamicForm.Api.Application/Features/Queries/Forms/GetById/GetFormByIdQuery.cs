using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DynamicForm.Api.Application.Features.Dtos.Forms;
using DynamicForm.Api.Application.Repositories;
using DynamicForm.Api.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DynamicForm.Api.Application.Features.Queries.Forms.GetById
{
    public class GetFormByIdQuery : IRequest<GetFormListDto>
    {
        public int Id { get; set; }
    }

    public class GetFormByIdQueryHandler:IRequestHandler<GetFormByIdQuery, GetFormListDto>
    {
        private readonly IFormRepository _formRepository;
        private readonly IMapper _mapper;

        public GetFormByIdQueryHandler(IFormRepository formRepository, IMapper mapper)
        {
            _formRepository = formRepository;
            _mapper = mapper;
        }

        public async Task<GetFormListDto> Handle(GetFormByIdQuery request, CancellationToken cancellationToken)
        {
            Form? existForm = await _formRepository.GetAsync(predicate: x => x.Id == request.Id, disableTracking: false,include:x=>x.Include(y=>y.Fields));
            GetFormListDto mappedList = _mapper.Map<GetFormListDto>(existForm);
            return mappedList;
        }
    }
}
