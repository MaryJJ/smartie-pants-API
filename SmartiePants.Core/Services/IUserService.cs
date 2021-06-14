using SmartiePants.Core.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartiePants.Core.Services
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(UserRegisterDto userForCreationDto);
        Task<UserDto> Login(UserLoginDto userLoginDto);
    }
}