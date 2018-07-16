namespace ARCVDS_Final.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var bene = new List<Beneficios> {
               new Beneficios { id_Beneficio=1, Categoria="Bar", Descricao="Descontos em bebidas de bar"},
               new Beneficios { id_Beneficio = 2, Categoria="Desporto", Descricao="Desconto na ginastica"},
               new Beneficios {id_Beneficio=3,Categoria="Passeios", Descricao="Descontos em passeios com idas à serra da estrela."},
        };
            bene.ForEach (aa => context.Beneficios.AddOrUpdate (a => a.id_Beneficio,aa));
            context.SaveChanges ();

            var pess = new List<Pessoas> {
               new Pessoas {Id=1,  Nome="Diogo Martins", data_Nascimento=new DateTime(2017,1,1), Sexo="M", Morada="Rua Banheira",Codigo_Postal="2350-265 Torres Novas" ,
                   Nacionalidade ="Portuguesa", Email="diogomartinsvds@gmail.com", /*Foto="plaka.jpg"*/ numeroTelefone="249890931", numeroTelemovel="916488198",
                   dataEntradaClube = new DateTime(2017,1,1), UserName ="diogomartinsvds@gmail.com" ,ListaBeneficios = new List<Beneficios> { bene[0], bene[1], bene[2] } },
               new Pessoas {Id=2, Nome="Luis Martins", data_Nascimento=new DateTime(2017,1,1), Sexo="M", Morada="Rua Santo António",Codigo_Postal="2350-265 Torres Novas" , Nacionalidade="Portuguesa",
                   Email ="luismartins@gmail.com", /*Foto="alex.jpg"*/ numeroTelefone="249890932", numeroTelemovel="916488198", dataEntradaClube = new DateTime(2017,1,1),
                   UserName = "luismartins@gmail.com",ListaBeneficios = new List<Beneficios> { bene[0], bene[1] ,bene[2]} },
               new Pessoas {Id=3, Nome="Ricardo Formiga", data_Nascimento=new DateTime(2017,1,1), Sexo="M", Morada="Rua da Gaiola",Codigo_Postal="2350-265 Torres Novas" , Nacionalidade="Portuguesa",
                   Email ="ricardo@gmail.com", /*Foto="alex.jpg"*/ numeroTelefone="249890917", numeroTelemovel="916488198", dataEntradaClube = new DateTime(2017,1,1),
                   UserName = "ricardo@gmail.com",ListaBeneficios = new List<Beneficios> { bene[0], bene[1], bene[2] } },
            };
            pess.ForEach (pp => context.Pessoas.AddOrUpdate (p => p.Nome,pp));
            context.SaveChanges ();

            var quo = new List<Quotas> {
               new Quotas {id_Quota=1, ano_Quota= new DateTime(2017,1,1), Valor_Quota=12, Descricao="Pagou somente 6€", Paga=false, PessoaFK = 1},
               new Quotas {id_Quota=2, ano_Quota= new DateTime(2017,1,1), Valor_Quota=12, Descricao="Pagou somente 6€", Paga=false, PessoaFK = 2},
               new Quotas {id_Quota=3,ano_Quota = new DateTime (2016,1,1),Valor_Quota = 12,Descricao = "Pagou somente 6€",Paga = false,Email="ricardo@gmail.com",PessoaFK = 3 },
               new Quotas {id_Quota=4,ano_Quota = new DateTime (2017,1,1),Valor_Quota = 12,Descricao = "Pagou somente 6€",Paga = false,Email="ricardo@gmail.com",PessoaFK = 3 },
               new Quotas {id_Quota=5,ano_Quota = new DateTime (2018,1,1),Valor_Quota = 12,Descricao = "Pagou somente 6€",Paga = false,Email="ricardo@gmail.com",PessoaFK = 3 },
         };
            quo.ForEach (aa => context.Quotas.AddOrUpdate (a => a.id_Quota,aa));
            context.SaveChanges ();

            var pag = new List<Pagamentos> {
               new Pagamentos {id_Pagamento=1, Valor_Pagamento=12, data_Pagamento=new DateTime(2017,1,1), ultima_Ano_Pago=new DateTime(2016,1,1), QuotaFK=1},
               new Pagamentos {id_Pagamento=2, Valor_Pagamento=12, data_Pagamento=new DateTime(2017,1,1), ultima_Ano_Pago=new DateTime(2016,1,1), QuotaFK=2},
               new Pagamentos {id_Pagamento=3, Valor_Pagamento=12, data_Pagamento=new DateTime(2017,1,1), ultima_Ano_Pago=new DateTime(2016,1,1),Email="ricardo@gmail.com", QuotaFK=3},
               new Pagamentos {id_Pagamento=4, Valor_Pagamento=12, data_Pagamento=new DateTime(2017,1,1), ultima_Ano_Pago=new DateTime(2016,1,1),Email="ricardo@gmail.com",QuotaFK=4},
               new Pagamentos {id_Pagamento=5, Valor_Pagamento=12, data_Pagamento=new DateTime(2017,1,1), ultima_Ano_Pago=new DateTime(2016,1,1),Email="ricardo@gmail.com",QuotaFK=5},
            };
            pag.ForEach (aa => context.Pagamentos.AddOrUpdate (a => a.id_Pagamento,aa));
            context.SaveChanges ();

        }
    }
}
