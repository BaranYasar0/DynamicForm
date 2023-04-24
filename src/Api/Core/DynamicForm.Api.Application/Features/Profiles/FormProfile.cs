using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DynamicForm.Api.Application.Features.Commands.Form.Create;
using DynamicForm.Api.Application.Features.Dtos.Fields;
using DynamicForm.Api.Application.Features.Dtos.Form;
using DynamicForm.Api.Application.Features.Dtos.Forms;
using DynamicForm.Api.Application.Features.Queries.Forms;
using DynamicForm.Api.Domain.Entities;

namespace DynamicForm.Api.Application.Features.Profiles
{
    public class FormProfile:Profile
    {
        public FormProfile()
        {
            //Create Command
            CreateMap<CreateFormCommand, Form>().ForMember(x => x.Fields, y => y.MapFrom(z => z.CreatedFieldDtos))
                .ReverseMap();
            CreateMap<Form, CreatedFormDto>().ForMember(x => x.CreatedFieldDtos, y => y.MapFrom(z => z.Fields))
                .ReverseMap();

            CreateMap<CreatedFieldDto, Field>().ReverseMap();
            CreateMap<GetFieldListDto, Field>().ReverseMap();


            //Get List Query
            CreateMap<Form, GetFormListDto>().ForMember(x => x.GetFieldListDto, y => y.MapFrom(z => z.Fields))
                .ReverseMap();
        }

    }
}

