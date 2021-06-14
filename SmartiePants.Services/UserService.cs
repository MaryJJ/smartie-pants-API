using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SmartiePants.Core.Models;
using SmartiePants.Core.Resources;
using SmartiePants.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartiePants.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserService(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<UserDto> CreateUserAsync(UserRegisterDto userForCreationDto)
        {
            User user = _mapper.Map<User>(userForCreationDto);
            IdentityResult userCreateResult = await _userManager.CreateAsync(user, userForCreationDto.Password);
            if (userCreateResult.Succeeded)
            {
                return _mapper.Map<UserDto>(user);
            }
            else
            {
                throw new ValidationException(userCreateResult.Errors.First().Description);
            }
        }

        public async Task<UserDto> Login(UserLoginDto userLoginDto)
        {
            User user = _userManager.Users.SingleOrDefault(u => u.UserName == userLoginDto.Email);
            if (user != null)
            {
                bool userLoginResult = await _userManager.CheckPasswordAsync(user, userLoginDto.Password);
                if (userLoginResult)
                {
                    return _mapper.Map<UserDto>(user);
                }
            }
            throw new Exception("Email or password incorrect.");
        }
    }
}