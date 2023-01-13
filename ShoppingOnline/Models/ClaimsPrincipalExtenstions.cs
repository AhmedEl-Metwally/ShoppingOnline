using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShoppingOnline.Models
{
    public static class ClaimsPrincipalExtenstions
    {
        public static string RetrieveEmailPrincipal ( this ClaimsPrincipal user)
        {
            return user?.Claims?.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value;
        }

    }
}
