using DynamicForm.Api.Application.Repositories;
using DynamicForm.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Api.Application.Utilities.Exceptions;
using DynamicForm.Api.Application.Utilities.Authorization.Hashing;

namespace DynamicForm.Api.Application.Features.Rules
{
    public class AuthBusinessRules: BaseBusinessRules<Form>
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCannotBeDuplicatedWhenRegistered(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException("Mail already exists.");
        }

        public Task UserShouldBeExists(User? user)
        {
            if (user == null) throw new BusinessException("User don't exists.");
            return Task.CompletedTask;
        }

        public async Task UserPasswordShouldBeMatch(int id, string password)
        {
            User? user = await _userRepository.GetAsync(u => u.Id == id);
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new BusinessException("Password don't match.");
        }
    }

}
