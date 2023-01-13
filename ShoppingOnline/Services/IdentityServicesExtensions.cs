//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.DependencyInjection;
//using ShoppingOnline.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ShoppingOnline.Services
//{
//    public static class IdentityServicesExtensions
//    {
//        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
//        {
//            var builder = services.AddIdentityCore<AppUser>();

//            builder = new IdentityBuilder(builder.UserType, builder.Services);
//            builder.AddEntityFrameworkStores<AppIdentityDBContext>();
//            builder.AddSignInManager<SignInManager<AppUser>>();

//            return services;
//        }
//    }
//}
