using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Api.Application.Repositories;
using DynamicForm.Api.Application.Utilities.Exceptions;
using DynamicForm.Api.Domain.Entities;

namespace DynamicForm.Api.Application.Features.Rules
{
    public class FormBusinessRules : BaseBusinessRules<Form>
    {
        private readonly IFormRepository _formRepository;

        public FormBusinessRules(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public async Task UpdatedFormShouldBeExist(int formId)
        {
          Form checkForm= await _formRepository.GetAsync(x => x.Id == formId);
          if (checkForm == null) throw new BusinessException("Form doesn't exist!");
        }
    }
}
