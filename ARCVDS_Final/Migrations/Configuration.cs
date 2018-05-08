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
        }
        protected override void Seed ( ARCVDS_Final.Models.SociosDB context) {

            var e = new List<Eventos> {

                new Eventos {id_Evento=1, Descricao="s", Dia_Evento= new DateTime(2015,1,1), imagens_Evento="Serra.jpg", nome_Evento="s", nome_Patrocinador="a", Pessoas=null }
            };
            e.ForEach (ee => context.Eventos.AddOrUpdate (eee => eee.nome_Evento,ee));
            context.SaveChanges ();
        }


    }
}
