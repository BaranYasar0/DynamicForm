using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace DynamicForm.Api.Application.Utilities.Pipelines
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            ValidationContext<object> context = new(request);
            List<ValidationFailure> failures = _validators.Select(vld => vld.Validate(context))
                .SelectMany(y => y.Errors)
                .Where(z => z != null)
                .ToList();
            if (failures.Count != 0)
                throw new ValidationException(failures);

            return next();
        }
    }
}
