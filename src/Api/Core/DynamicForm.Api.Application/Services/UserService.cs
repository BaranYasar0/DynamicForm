using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Api.Application.Extensions;
using DynamicForm.Api.Application.Repositories;
using DynamicForm.Api.Application.Services.Interfaces;
using DynamicForm.Api.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace DynamicForm.Api.Application.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(IUserRepository userRepository, IHttpContextAccessor contextAccessor)
        {
            _userRepository = userRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<User?> GetByEmail(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            return user;
        }

        public async Task<User> GetById(int id)
        {
            User? user = await _userRepository.GetAsync(u => u.Id == id);
            return user;
        }

        public async Task<User> Update(User user)
        {
            User updatedUser = await _userRepository.UpdateAsync(user);
            return updatedUser;
        }

        public int GetUserId()
        {
            return _contextAccessor.HttpContext.User.GetUserId();
        }
    }
}
