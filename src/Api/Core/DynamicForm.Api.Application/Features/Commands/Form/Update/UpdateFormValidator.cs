using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DynamicForm.Api.Application.Features.Commands.Form.Update
{
    public class UpdateFormValidator:AbstractValidator<UpdateFormCommand>
    {
        public UpdateFormValidator()
        {
            RuleFor(x => x.Name)
                .MinimumLength(3).WithMessage("Name cannot be less than 3 words!");
        }
    }
}
