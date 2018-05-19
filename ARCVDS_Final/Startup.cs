using ARCVDS_Final.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;

namespace ARCVDS_Final {

    public partial class Startup {
        public void Configuration (IAppBuilder app) {
            ConfigureAuth (app);
            iniciaRoles ();
        }
        
        private void iniciaRoles () {

            ApplicationDbContext db = new ApplicationDbContext ();

            var roleManager = new RoleManager<IdentityRole> (new RoleStore<IdentityRole> (db));
            var userManager = new UserManager<ApplicationUser> (new UserStore<ApplicationUser> (db));

            /*if(!roleManager.RoleExists ("Funcionarios")) {

                var roleFun = new IdentityRole ();
                roleFun.Name = "Funcionarios";
                roleManager.Create (roleFun);

                var user = new ApplicationUser ();
                user.UserName = "Jorge";
                user.Email = "jorge@gmail.com";

                string jorgePassword = "123";

                var chkUser = userManager.Create (user,jorgePassword);

                if(chkUser.Succeeded) {
                    var result1 = userManager.AddToRole (user.Id,"Funcionarios");
                }

            }

            if(!roleManager.RoleExists ("Socios")) {

                var roleSocio = new IdentityRole ();
                roleSocio.Name = "Socios";
                roleManager.Create (roleSocio);

                var user = new ApplicationUser ();
                user.UserName = "Luis";
                user.Email = "luis@gmail.com";

                string luisPassword = "123";

                var chkUser = userManager.Create (user,luisPassword);

                if(chkUser.Succeeded) {
                    var result1 = userManager.AddToRole (user.Id,"Socios");
                }
            }

            if(!roleManager.RoleExists ("Admin")) {

                var roleAdmin = new IdentityRole ();
                roleAdmin.Name = "Admin";
                roleManager.Create (roleAdmin);

                var user = new ApplicationUser ();
                user.UserName = "plaka";
                user.Email = "diogomartinsvds@gmail.com";

                string plakaPassword = "Qwer4545#";
                var chkUser = userManager.Create (user,plakaPassword);

                if(chkUser.Succeeded) {
                    var result1 = userManager.AddToRole (user.Id,"Admin");
                }
                */
            }
       
    }
}
