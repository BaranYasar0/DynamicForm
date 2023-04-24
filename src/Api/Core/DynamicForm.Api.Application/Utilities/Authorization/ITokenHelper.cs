using DynamicForm.Api.Domain.Entities;
using DynamicForm.Shared;

namespace DynamicForm.Api.Application.Helpers.Authorization;

public interface ITokenHelper
{
    AccessToken CreateToken(User user, IList<OperationClaim> operationClaims);

    RefreshToken CreateRefreshToken(User user);
}