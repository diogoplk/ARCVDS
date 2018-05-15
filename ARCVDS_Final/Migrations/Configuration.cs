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

        protected override void Seed(ARCVDS_Final.Models.SociosDB context)
        {
            var bene = new List<Beneficios> {
               new Beneficios { id_Beneficio=1, Categoria="Bar", Descricao="Descontos em bebidas de bar"},
               new Beneficios { id_Beneficio = 2, Categoria="Desporto", Descricao="Desconto na ginastica"},
               new Beneficios {id_Beneficio=3,Categoria="Passeios", Descricao="Descontos em passeios com idas à serra da estrela."},
        };
            bene.ForEach (aa => context.Beneficios.AddOrUpdate (a => a.id_Beneficio,aa));
            context.SaveChanges ();

            var pess = new List<Pessoas> {
               new Pessoas {Pessoa_ID=1, Nome="Diogo Martins", data_Nascimento=new DateTime(2017,1,1), Sexo="M", Morada="asdasdsa",Codigo_Postal="2350-265 Torres Novas" , Nacionalidade="Po", Email="diogomartinsvds@gmail.com", Foto="plaka.jpg", numeroTelefone="123456789", numeroTelemovel="916488198", dataEntradaClube = new DateTime(2017,1,1), ListaBeneficios = new List<Beneficios> { bene[0], bene[1] } },
               new Pessoas {Pessoa_ID=2, Nome="Luis Martins", data_Nascimento=new DateTime(2017,1,1), Sexo="M", Morada="asdasdsa",Codigo_Postal="2350-265 Torres Novas" , Nacionalidade="Po", Email="luismartins@gmail.com", Foto="alex.jpg", numeroTelefone="123456789", numeroTelemovel="916488198", dataEntradaClube = new DateTime(2017,1,1), ListaBeneficios = new List<Beneficios> { bene[0], bene[1] } },
            };
            pess.ForEach (pp => context.Pessoas.AddOrUpdate (p => p.Nome,pp));
            context.SaveChanges ();

            var eve = new List<Eventos> {
               new Eventos {id_Evento=1, nome_Evento="Prova das Sopas", Descricao="Concurso onde ganhará a melhor sopa", Dia_Evento=new DateTime(2017,5,5), nome_Patrocinador="PUNHETA",Pessoas = new List<Pessoas> { pess[0]}},
               new Eventos {id_Evento=2, nome_Evento="Prova das Sopas", Descricao="Concurso onde ganhará a melhor sopa", Dia_Evento=new DateTime(2017,5,5), nome_Patrocinador="PUNHETAAS",Pessoas = new List<Pessoas> { pess[0]}},
               new Eventos {id_Evento=3, nome_Evento="Prova das Sopas", Descricao="Concurso onde ganhará a melhor sopa", Dia_Evento=new DateTime(2017,5,5), nome_Patrocinador="Punhetas69",Pessoas = new List<Pessoas> { pess[0]}},
            };

            eve.ForEach (aa => context.Eventos.AddOrUpdate (a => a.id_Evento,aa));
            context.SaveChanges ();

            var foevt = new List<FotografiasEventos> {
               new FotografiasEventos {id_Fotografia=1, Imagens="Serra.jpg", EventoFK=1},
               new FotografiasEventos {id_Fotografia=2, Imagens="Serra.jpg", EventoFK=2},
               new FotografiasEventos {id_Fotografia=3, Imagens="Serra.jpg", EventoFK=3},

            };
            foevt.ForEach (fe => context.FotografiasEventos.AddOrUpdate (fee => fee.id_Fotografia,fe));
            context.SaveChanges ();

            var quo = new List<Quotas> {
               new Quotas {id_Quota=1, ano_Quota= new DateTime(2017,1,1), Valor_Quota=12, Descricao="Pagou somente 6€", Paga=false, PessoaFK = 1},
               new Quotas {id_Quota=2, ano_Quota= new DateTime(2017,1,1), Valor_Quota=12, Descricao="Pagou somente 6€", Paga=false, PessoaFK = 2},
               new Quotas { id_Quota = 3,ano_Quota = new DateTime (2016,1,1),Valor_Quota = 12,Descricao = "Pagou somente 6€",Paga = false,PessoaFK = 1 },
         };
            quo.ForEach (aa => context.Quotas.AddOrUpdate (a => a.id_Quota,aa));
            context.SaveChanges ();

            var pag = new List<Pagamentos> {
               new Pagamentos {id_Pagamento=1, Valor_Pagamento=12, data_Pagamento=new DateTime(2017,1,1), ultima_Ano_Pago=new DateTime(2016,1,1), QuotaFK=1},
               new Pagamentos {id_Pagamento=2, Valor_Pagamento=12, data_Pagamento=new DateTime(2017,1,1), ultima_Ano_Pago=new DateTime(2016,1,1), QuotaFK=2},
               new Pagamentos {id_Pagamento=3, Valor_Pagamento=12, data_Pagamento=new DateTime(2017,1,1), ultima_Ano_Pago=new DateTime(2016,1,1), QuotaFK=3},

            };
            pag.ForEach (aa => context.Pagamentos.AddOrUpdate (a => a.id_Pagamento,aa));
            context.SaveChanges ();

        }
    }
}
