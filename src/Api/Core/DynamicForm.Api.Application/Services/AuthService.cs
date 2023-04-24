using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Api.Application.Helpers.Authorization;
using DynamicForm.Api.Application.Repositories;
using DynamicForm.Api.Application.Services.Interfaces;
using DynamicForm.Api.Application.Utilities.Authorization;
using DynamicForm.Api.Domain.Entities;
using DynamicForm.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DynamicForm.Api.Application.Services;

public class AuthService:IAuthService
{
        
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly ITokenHelper _tokenHelper;
    private readonly TokenOptions _tokenOptions;
    public IConfiguration Configuration;


    public AuthService(IConfiguration configuration,IRefreshTokenRepository refreshTokenRepository, IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _userOperationClaimRepository = userOperationClaimRepository;
        _tokenHelper = tokenHelper;
        Configuration = configuration;
        _tokenOptions = new TokenOptions
        {
            Audience = Configuration["TokenOptions:Audience"],
            Issuer = Configuration["TokenOptions:Issuer"],
            AccessTokenExpiration = int.Parse(Configuration["TokenOptions:AccessTokenExpiration"]),
            SecurityKey = Configuration["TokenOptions:SecurityKey"],
            RefreshTokenTTL = int.Parse(Configuration["TokenOptions:RefreshTokenTTL"])
        }; ;
    }

    public async Task<AccessToken> CreateAccessToken(User user)
    {
        List<UserOperationClaim> userOperationClaims= await _userOperationClaimRepository.GetListAsync(u => u.UserId == user.Id, include: u => u.Include(u => u.OperationClaim));

        IList<OperationClaim> operationClaims = userOperationClaims.Select(y => new OperationClaim { Id = y.OperationClaim.Id, Name = y.OperationClaim.Name }).ToList();
        
        AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
        return accessToken;
    }

    public async Task<RefreshToken> CreateRefreshToken(User user)
    {
        RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user);
        return await Task.FromResult(refreshToken);
    }

    public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
    {
        RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
        return addedRefreshToken;
    }
    public async Task DeleteOldRefreshTokens(int userId)
    {
        IList<RefreshToken> refreshTokens = (await _refreshTokenRepository.GetListAsync(r =>
                r.UserId == userId &&
                r.Revoked == null && r.Expires >= DateTime.UtcNow &&
                r.Created.AddDays(_tokenOptions.RefreshTokenTTL) <=
                DateTime.UtcNow)
            );
        foreach (RefreshToken refreshToken in refreshTokens) await _refreshTokenRepository.DeleteAsync(refreshToken);
    }

}