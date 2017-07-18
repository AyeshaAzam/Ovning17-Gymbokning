namespace Gymbokning_v0._1.Migrations
{
using Gymbokning_v0._1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

//https://stackoverflow.com/questions/19280527/mvc-5-seed-users-and-roles



    internal sealed class Configuration : DbMigrationsConfiguration<Gymbokning_v0._1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
     
        
        protected override void Seed(Gymbokning_v0._1.Models.ApplicationDbContext context)
        {
          

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var roleName = "Admin";
            if (!context.Roles.Any(r => r.Name == roleName))
            {
                //create role
                var role = new IdentityRole { Name = roleName };

                var result = roleManager.Create(role);
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join("\n", result.Errors)); // radbryttning mellan resultatet
                }

            }

            var date = DateTime.Now;
           
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var email = "admin@Gymbokning.se";
            if (!context.Users.Any(u => u.UserName == email))
            {

                var user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    TimeOfRegistration = date


                };

                var result = userManager.Create(user, "foobar123!");
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join("\n", result.Errors));
                }

            }

            var adminUser = userManager.FindByName("admin@Gymbokning.se");
            userManager.AddToRole(adminUser.Id, "Admin");
        }
    }
}

