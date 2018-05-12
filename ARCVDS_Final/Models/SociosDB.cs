using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace ARCVDS_Final.Models {
    public class SociosDB : DbContext {

        public SociosDB() : base("AppBD") { }

        public virtual DbSet<Beneficios> Beneficios { get; set; }
        public virtual DbSet<Eventos> Eventos { get; set; }
        //public virtual DbSet<Funcionarios> Funcionarios { get; set; }
        public virtual DbSet<Pagamentos> Pagamentos { get; set; }
        public virtual DbSet<Pessoas> Pessoas { get; set; }
        public virtual DbSet<Quotas> Quotas { get; set; }
        //public virtual DbSet<Socios> Socios { get; set; }
        public virtual DbSet<FotografiasEventos> FotografiasEventos {
            get;set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating (modelBuilder);

        }
    }

}