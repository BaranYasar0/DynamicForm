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

namespace DynamicForm.Api.Application.Features.Queries.Forms
{
    public class GetFormListQuery:IRequest<IEnumerable<GetFormListDto>>
    {
        
    }
    public class GetFormListQueryHandler:IRequestHandler<GetFormListQuery,IEnumerable<GetFormListDto>>
    {
        private readonly IFormRepository _formRepository;
        private readonly IMapper _mapper;

        public GetFormListQueryHandler(IFormRepository formRepository, IMapper mapper)
        {
            _formRepository = formRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetFormListDto>> Handle(GetFormListQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Form>? toBeMappedforms = await _formRepository.GetListAsync(include: x => x.Include(y => y.Fields),
                disableTracking:false,
                orderBy:x=>x.OrderByDescending(y=>y.CreatedBy));

            IEnumerable<GetFormListDto> mappedForms = _mapper.Map<IEnumerable<GetFormListDto>>(toBeMappedforms);

            return mappedForms;
        }
    }
}
