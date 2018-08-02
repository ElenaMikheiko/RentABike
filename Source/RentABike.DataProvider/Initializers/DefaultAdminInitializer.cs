using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RentABike.Models;

namespace RentABike.DataProvider.Initializers
{
    public static class DefaultAdminInitializer
    {
        public static void Initialize(RentABikeDbContext context)
        {
            if (!context.Users.Any())
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                //TODO:
                // create default roles
                var roles = new List<IdentityRole>
                {
                    new IdentityRole {Name = "Admin"},
                    new IdentityRole {Name = "User"},
                    new IdentityRole {Name = "Seller"}
                };

                // add roles in DB
                foreach (var role in roles)
                {
                    roleManager.Create(role);
                }

                // create default admin
                var admin = new ApplicationUser { Email = "defaultadmin@gmail.com", UserName = "defaultadmin@gmail.com" };
                string password = "ad46D_";
                var userInfoAdmin = new UserInfo
                {
                    User = admin,
                    Email = admin.Email,
                    Name = "Admin",
                    Surname = "Admin",
                    Phone = "+375 (29) 123-45-67",
                };
                context.UserInfos.Add(userInfoAdmin);
                var result = userManager.Create(admin, password);

                // if the user creation was successful
                if (result.Succeeded)
                {
                    // create role for default admin
                    userManager.AddToRole(admin.Id, roles.FirstOrDefault(r=>r.Name == "Admin")?.Name);
                }
            }
        }

    }
}
