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

                new Eventos {id_Evento=1, Descricao="s", Dia_Evento= new DateTime(2015,1,1), imagens_Evento="Serra.jpg", nome_Evento="s", nome_Patrocinador="a"}
            };
            e.ForEach (ee => context.Eventos.AddOrUpdate (eee => eee.nome_Evento, ee));
            context.SaveChanges ();

            var b = new List<Beneficios> {
                new Beneficios { id_Beneficio= 1, Categoria="Desconto em cerveja", Descricao="Na compra de uma grade de cerveja tem disconto de 12%"}
            };

            b.ForEach (bb => context.Beneficios.AddOrUpdate (bbb => bbb.id_Beneficio, bb));
            context.SaveChanges ();

            var q = new List<Quotas> {

                new Quotas  {id_Quota = 1, ano_Quota=new DateTime(2017,5,10), Paga=true, Descricao="Pagou a valor da cota total.", PessoaFK=1}

            };

            q.ForEach (qq => context.Quotas.AddOrUpdate (qqq => qqq.id_Quota, qq));
            context.SaveChanges ();

            var pa = new List<Pagamentos> {

                new Pagamentos { id_Pagamento = 1, Valor_Pagamento = 12, data_Pagamento = new DateTime (2018, 12, 1), ultima_Ano_Pago = new DateTime (2017, 1, 31), PessoaFK = 1, QuotaFK = 1 }
            };

            pa.ForEach (paaa => context.Pagamentos.AddOrUpdate (paa => paa.id_Pagamento, paaa));
            context.SaveChanges ();

            var p = new List<Pessoas> {

                new Pessoas {Pessoa_ID = 1,
                    Nome = "Diogo Martins",
                    data_Nascimento = new DateTime(1996,10,27),
                    Sexo ="M",
                    Morada = "Rua Padre Júlio Ambrósio nº2 Vale da Serra",
                    Codigo_Postal ="2350-265 Torres Novas",
                    Nacionalidade ="Portuguesa",
                    Email ="diogomartinsvds@gmail.com" ,
                    Foto ="plaka.jpg",
                    numeroTelefone ="249890917",
                    numeroTelemovel ="916488198",
                    Beneficios = new List<Beneficios> { b[0]},
                    ListaEventos =new List<Eventos> { e[0]} }
            };
            p.ForEach (pp => context.Pessoas.AddOrUpdate (ppp => ppp.Nome, pp));
            context.SaveChanges ();

        }

    }
}
