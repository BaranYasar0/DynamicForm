using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Api.Application.Features.Constants;
using DynamicForm.Api.Application.Repositories;
using DynamicForm.Api.Application.Utilities.Exceptions;
using DynamicForm.Api.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace DynamicForm.Api.Application.Features.Rules
{
    public class FormBusinessRules : BaseBusinessRules<Form>
    {
        private readonly IFormRepository _formRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public FormBusinessRules(IFormRepository formRepository, IHttpContextAccessor contextAccessor)
        {
            _formRepository = formRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task UpdatedFormShouldBeExist(int formId)
        {
          Form checkForm= await _formRepository.GetAsync(x => x.Id == formId);
          if (checkForm == null) throw new BusinessException("Form doesn't exist!");
        }

        public async Task UserShouldBeAuthenticated()
        {
            if (!_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
                throw new BusinessException(FormConstants.UserIsntAuth);
        }

        public async Task CheckDataType(string dataType)
        {
            var tempData = dataType.ToLower();
            //if(tempData=="string"||tempData=="strıng")

        }
    }
}
