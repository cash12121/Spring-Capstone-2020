namespace WPFPresentation.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DataTransferObjects;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using WPFPresentation.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WPFPresentation.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WPFPresentation.Models.ApplicationDbContext";
        }

        /// <summary>
        /// Updater: Zach Behrensmeyer
        /// Updated: 4/21/2020
        /// Update: Added Identity System Logic
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(WPFPresentation.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            const string admin = "PUadmin@PetUniverse.com";
            const string adminPassword = "C@pstone20";

            LogicLayer.UserManager usermgr = new LogicLayer.UserManager();
            LogicLayer.ERoleManager rolemgr = new LogicLayer.ERoleManager();
            var roles = rolemgr.RetrieveAllERoles();
            List<string> RoleNames = new List<string>();

            foreach (var role in roles)
            {
                RoleNames.Add(role.ERoleID);
            }

            foreach (var role in RoleNames)
            {
                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole() { Name = role });
            }
            if (!RoleNames.Contains("Administrator"))
            {
                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole() { Name = "Administrator" });
            }

            if (!context.Users.Any(u => u.UserName == admin))
            {
                var user = new ApplicationUser()
                {
                    UserName = admin,
                    Email = admin,
                    GivenName = "PUAdmin",
                    FamilyName = "Company"
                };

                IdentityResult result = userManager.Create(user, adminPassword);
                context.SaveChanges();

                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Administrator");
                    context.SaveChanges();
                }
            }
        }
    }
}
