using Core.Entities;
using Core.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class CookieExtension
    {

        public static void SetCookie(this HttpContext httpContext, CookieParams cookieParams)
        {
            httpContext.Response.Cookies.Append(CookieKey.AuthorizationKey, cookieParams.AccessToken.Token,
                new CookieOptions { Expires = cookieParams.AccessToken.Expiration, HttpOnly = true, Secure = true });

            httpContext.Response.Cookies.Append(CookieKey.ExpireKey, cookieParams.AccessToken.Token,
                new CookieOptions { Expires = cookieParams.AccessToken.Expiration, HttpOnly = true, Secure = true });

            httpContext.Response.Cookies.Append(CookieKey.Email, cookieParams.User.Email,
                new CookieOptions { Expires = cookieParams.AccessToken.Expiration, HttpOnly = true, Secure = true });

        }

        public static void DeleteCookies(this HttpContext httpContext)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTimeOffset.Now;
            option.Secure = true;
            option.IsEssential = true;
            httpContext.Response.Cookies.Append(CookieKey.AuthorizationKey, string.Empty, option);
            httpContext.Response.Cookies.Append(CookieKey.ExpireKey, string.Empty, option);
            httpContext.Response.Cookies.Append(CookieKey.Email, string.Empty, option);
            httpContext.Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, string.Empty, option);


            httpContext.Response.Cookies.Delete(CookieKey.AuthorizationKey);
            httpContext.Response.Cookies.Delete(CookieKey.ExpireKey);
            httpContext.Response.Cookies.Delete(CookieKey.Email);
            httpContext.Response.Cookies.Delete(CookieRequestCultureProvider.DefaultCookieName);


        }
    }
}
