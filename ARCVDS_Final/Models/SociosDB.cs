using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace ARCVDS_Final.Models {
    public class SociosDB : DbContext {

        public SociosDB() : base("AppBD") { }

    }

}