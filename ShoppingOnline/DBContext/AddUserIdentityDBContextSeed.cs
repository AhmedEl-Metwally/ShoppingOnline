using Microsoft.AspNetCore.Identity;
using ShoppingOnline.Services;
using ShoppingOnline.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnline.DBContext
{
    public class AddUserIdentityDBContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> UserManage)
        {
            if (!UserManage.Users.Any())
            {
                var Users = new AppUser
                {
                    DisplayName = "Ahmed",
                    Email = "ahmedmohamed22551144@gmail.com",
                    UserName = "Meto",
                    Address = new Address
                    {
                        FirstName = "Ahmed",
                        LastName = "Mohamed",
                        street = "208 alhadayiq alquba",
                        city = "Cairo",
                        state = "Egypt",
                        zipcode = "11646"
                    }
                };

                await UserManage.CreateAsync(Users, "Pa$$wOrd");
            }
        }
    }
}
