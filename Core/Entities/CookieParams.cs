using Core.Entities.Concretes;
using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class CookieParams
    {
        public AccessToken AccessToken { get; set; }

        public User User { get; set; }
    }
}
