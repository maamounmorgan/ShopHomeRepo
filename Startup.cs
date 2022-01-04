using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using ShopHomepage.Models;

[assembly: OwinStartupAttribute(typeof(ShopHomepage.Startup))]
namespace ShopHomepage
{
    public partial class Startup
    {

        ApplicationDbContext context = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRoles();
            createUsers();
        }
        // In this method we will create default User roles and Admin user for login    
        public void createRoles()
        {

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            IdentityRole role;

    
            if (!roleManager.RoleExists("Admin"))
            {

                role = new IdentityRole();

                role.Name = "Admin";
                roleManager.Create(role);                 
            }
            if (!roleManager.RoleExists("Salers"))
            {

                role = new IdentityRole();
                role.Name = "Salers";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Buyers"))
            {

                role = new IdentityRole();
                role.Name = "Buyers";
                roleManager.Create(role);
            }
        }
        public void createUsers() {

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser();
            user.Email = "maamounmorgan@gmail.com";
            user.UserName = "maamoun";
            var check = UserManager.Create(user,"Asmagroup2015@");
            if (check.Succeeded)
            {
                UserManager.AddToRole(user.Id, "Admin");
            }
        }

    }
}
