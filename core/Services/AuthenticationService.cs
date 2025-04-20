using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Identity;
using Domain.Exceptions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Services.Abstractions;
using shared.Security;

namespace Services
{
    public class AuthenticationService(Microsoft.AspNetCore.Identity.UserManager<User> userManager) : IAuthenticationService
    {
        public async Task<UserResultDto> LoginAsync(LoginDto loginDto)
        {
            var User = await userManager.FindByEmailAsync(loginDto.Email);
            if (User == null) throw new UnAuthorizedException("Incorrect email");

             var Result = await userManager.CheckPasswordAsync(User,loginDto.Password);
            if(!Result) throw new UnAuthorizedException("incorrect password");

            return new UserResultDto(
                User.DisplayName,
                User.Email,
                "Token"
                );


        }

      

        public async Task<UserResultDto> ReagisterAsync(UserRegisterDto registerDto)
        {
            var User = new User()
            {
                Email = registerDto.Email,
                DisplayName = registerDto.DisplayName,
                PhoneNumber = registerDto.phoneNo,
                UserName=registerDto.userName
            };
            var Result = await userManager.CreateAsync(User, registerDto.Password);
            if (!Result.Succeeded)
            {
                var errors = Result.Errors.Select(e => e.Description).ToList();
                throw new RegisterValidationException(errors);
            }
            return new UserResultDto(
                User.DisplayName,
                User.Email,
                "Token");
        }
    }
}
