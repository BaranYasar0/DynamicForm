using DynamicForm.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Shared;

namespace DynamicForm.Api.Application.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<AccessToken> CreateAccessToken(User user);
        public Task<RefreshToken> CreateRefreshToken(User user);
        public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
        public Task DeleteOldRefreshTokens(int userId);

    }
}
