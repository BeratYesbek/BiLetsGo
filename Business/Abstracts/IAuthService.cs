using Core.Entities.Concretes;
using Core.Utilities.Result;
using Core.Utilities.Security.JWT;
using Entity.Concretes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IResult VerifyEmail(int userId);
        IDataResult<AccessToken> CreateAccessToken(User user, DateTime dateTime = default);
        IDataResult<User> IsLoggedIn();
    }
}
