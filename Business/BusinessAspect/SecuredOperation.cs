using Business.Concretes;
using Castle.DynamicProxy;
using Core.Entities.Concretes;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using DataAccess.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessAspect
{
    public class SecuredOperation : MethodInterception
    {
        private readonly string[] _roles;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(",");
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            // a sample jwt encoded token string which is supposed to be extracted from 'Authorization' HTTP header in your Web Api controller
            var nameIdentifier = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var cookieEmail = _httpContextAccessor.HttpContext?.Request.Cookies["Email"];

            var roleClaims = _httpContextAccessor.HttpContext?.User.ClaimRoles();
            var exp = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(t => t.Type == "exp");

            if (nameIdentifier is not null)
                SetCurrentUser(nameIdentifier);

            if (exp == null)
                throw new Exception("Your session has been expired.");


            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                    return;

            }
            // throw new AuthenticationFailedException("You have no authorization.");
        }
        private static User SetCurrentUser(string nameIdentifier)
        {
            var result = new UserManager(new EfUserDal()).Get(int.Parse(nameIdentifier));
            if (result.Success)
            {
                CurrentUser.User = result.Data;
            }
            return result.Data;
        }

    }

}

