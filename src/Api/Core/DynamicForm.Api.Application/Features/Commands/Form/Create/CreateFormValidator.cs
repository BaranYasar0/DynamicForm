using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Api.Application.Features.Constants;
using FluentValidation;

namespace DynamicForm.Api.Application.Features.Commands.Form.Create
{
    public class CreateFormValidator:AbstractValidator<CreateFormCommand>
    {
        public CreateFormValidator()
        {
            RuleFor(x => x.Name)
                .MinimumLength(3).WithMessage(FormConstants.NameLength);
        }

    }
}
