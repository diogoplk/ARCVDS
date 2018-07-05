using ARCVDS_Final.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;

namespace ARCVDS_Final
{

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            iniciaRoles();
        }

        private void iniciaRoles()
        {

            ApplicationDbContext db = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            if (!roleManager.RoleExists("Funcionarios"))
            {

                var roleFun = new IdentityRole();
                roleFun.Name = "Funcionarios";
                roleManager.Create(roleFun);

                var user = new ApplicationUser();
                user.UserName = "jorge@gmail.com";
                user.Email = "jorge@gmail.com";

                string jorgePassword = "Qwer4545#";

                var chkUser = userManager.Create(user, jorgePassword);

                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Funcionarios");
                }

            }

            if (!roleManager.RoleExists("Socios"))
            {

                var roleSocio = new IdentityRole();
                roleSocio.Name = "Socios";
                roleManager.Create(roleSocio);

                var user = new ApplicationUser();
                user.UserName = "ricardo@gmail.com";
                user.Email = "ricardo@gmail.com";

                string luisPassword = "Qwer4#";

                var chkUser = userManager.Create(user, luisPassword);

                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Socios");
                }
            }

            if (!roleManager.RoleExists("Administrador"))
            {

                var roleAdmin = new IdentityRole();
                roleAdmin.Name = "Administrador";
                roleManager.Create(roleAdmin);

                var user = new ApplicationUser();
                user.UserName = "diogomartinsvds@gmail.com";
                user.Email = "diogomartinsvds@gmail.com";

                string plakaPassword = "Qwer4545#";
                var chkUser = userManager.Create(user, plakaPassword);

                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Administrador");
                }

            }

        }
    }
}
