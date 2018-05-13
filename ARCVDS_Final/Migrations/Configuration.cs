namespace ARCVDS_Final.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ARCVDS_Final.Models.SociosDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;

        }

        protected override void Seed(ARCVDS_Final.Models.SociosDB context)
        {
            
            
        }
    }
}
