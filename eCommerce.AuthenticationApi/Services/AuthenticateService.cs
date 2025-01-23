using eCommerce.AuthenticationApi.Communication.Requests;
using eCommerce.AuthenticationApi.Domain.Entities;
using eCommerce.SharedLibrary.Exceptions;
using eCommerce.SharedLibrary.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eCommerce.AuthenticationApi.Services;

public class AuthenticateService
{
    private readonly IGenericRepository<User> _userRepository;
    private readonly IConfiguration _config;

    public AuthenticateService(IGenericRepository<User> userRepository, IConfiguration config)
    {
        _userRepository = userRepository;
        _config = config;
    }

    public async Task<string> Execute(AuthRequest request)
    {
        var user = await _userRepository.GetByAsync(usr => usr.Email == request.Email);
        if (user is null)
        {
            throw new UnauthorizedException("Invalid Credentials");
        }
        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {
            throw new UnauthorizedException("Invalid Credentials");
        }

        var secretKey = Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"]!);
        var securityKey = new SymmetricSecurityKey(secretKey);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var Claims = new[]
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Email)
        };
        var token = new JwtSecurityToken(
            issuer: _config["JwtSettings:Issuer"],
            audience: _config["JwtSettings:Audience"],
            Claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
