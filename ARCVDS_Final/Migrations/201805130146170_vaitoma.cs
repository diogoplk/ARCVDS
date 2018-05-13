namespace ARCVDS_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vaitoma : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beneficios",
                c => new
                    {
                        id_Beneficio = c.Int(nullable: false, identity: true),
                        Categoria = c.String(nullable: false, maxLength: 20),
                        Descricao = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id_Beneficio);
            
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        Pessoa_ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        data_Nascimento = c.DateTime(nullable: false),
                        Sexo = c.String(maxLength: 1),
                        Morada = c.String(nullable: false, maxLength: 50),
                        Codigo_Postal = c.String(nullable: false, maxLength: 25),
                        Nacionalidade = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 30),
                        Foto = c.String(),
                        numeroTelefone = c.String(nullable: false, maxLength: 13),
                        numeroTelemovel = c.String(nullable: false, maxLength: 13),
                    })
                .PrimaryKey(t => t.Pessoa_ID);
            
            CreateTable(
                "dbo.Eventos",
                c => new
                    {
                        id_Evento = c.Int(nullable: false, identity: true),
                        nome_Evento = c.String(nullable: false, maxLength: 25),
                        Descricao = c.String(nullable: false, maxLength: 255),
                        Dia_Evento = c.DateTime(nullable: false),
                        nome_Patrocinador = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.id_Evento);
            
            CreateTable(
                "dbo.FotografiasEventos",
                c => new
                    {
                        id_Fotografia = c.Int(nullable: false, identity: true),
                        Imagens = c.String(),
                        EventoFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_Fotografia)
                .ForeignKey("dbo.Eventos", t => t.EventoFK)
                .Index(t => t.EventoFK);
            
            CreateTable(
                "dbo.Quotas",
                c => new
                    {
                        id_Quota = c.Int(nullable: false, identity: true),
                        ano_Quota = c.DateTime(nullable: false),
                        Valor_Quota = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descricao = c.String(nullable: false),
                        Paga = c.Boolean(nullable: false),
                        PessoaFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_Quota)
                .ForeignKey("dbo.Pessoas", t => t.PessoaFK)
                .Index(t => t.PessoaFK);
            
            CreateTable(
                "dbo.Pagamentos",
                c => new
                    {
                        id_Pagamento = c.Int(nullable: false, identity: true),
                        Valor_Pagamento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        data_Pagamento = c.DateTime(nullable: false),
                        ultima_Ano_Pago = c.DateTime(nullable: false),
                        QuotaFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_Pagamento)
                .ForeignKey("dbo.Quotas", t => t.QuotaFK)
                .Index(t => t.QuotaFK);
            
            CreateTable(
                "dbo.PessoasBeneficios",
                c => new
                    {
                        Pessoas_Pessoa_ID = c.Int(nullable: false),
                        Beneficios_id_Beneficio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pessoas_Pessoa_ID, t.Beneficios_id_Beneficio })
                .ForeignKey("dbo.Pessoas", t => t.Pessoas_Pessoa_ID)
                .ForeignKey("dbo.Beneficios", t => t.Beneficios_id_Beneficio)
                .Index(t => t.Pessoas_Pessoa_ID)
                .Index(t => t.Beneficios_id_Beneficio);
            
            CreateTable(
                "dbo.EventosPessoas",
                c => new
                    {
                        Eventos_id_Evento = c.Int(nullable: false),
                        Pessoas_Pessoa_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Eventos_id_Evento, t.Pessoas_Pessoa_ID })
                .ForeignKey("dbo.Eventos", t => t.Eventos_id_Evento)
                .ForeignKey("dbo.Pessoas", t => t.Pessoas_Pessoa_ID)
                .Index(t => t.Eventos_id_Evento)
                .Index(t => t.Pessoas_Pessoa_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Quotas", "PessoaFK", "dbo.Pessoas");
            DropForeignKey("dbo.Pagamentos", "QuotaFK", "dbo.Quotas");
            DropForeignKey("dbo.EventosPessoas", "Pessoas_Pessoa_ID", "dbo.Pessoas");
            DropForeignKey("dbo.EventosPessoas", "Eventos_id_Evento", "dbo.Eventos");
            DropForeignKey("dbo.FotografiasEventos", "EventoFK", "dbo.Eventos");
            DropForeignKey("dbo.PessoasBeneficios", "Beneficios_id_Beneficio", "dbo.Beneficios");
            DropForeignKey("dbo.PessoasBeneficios", "Pessoas_Pessoa_ID", "dbo.Pessoas");
            DropIndex("dbo.EventosPessoas", new[] { "Pessoas_Pessoa_ID" });
            DropIndex("dbo.EventosPessoas", new[] { "Eventos_id_Evento" });
            DropIndex("dbo.PessoasBeneficios", new[] { "Beneficios_id_Beneficio" });
            DropIndex("dbo.PessoasBeneficios", new[] { "Pessoas_Pessoa_ID" });
            DropIndex("dbo.Pagamentos", new[] { "QuotaFK" });
            DropIndex("dbo.Quotas", new[] { "PessoaFK" });
            DropIndex("dbo.FotografiasEventos", new[] { "EventoFK" });
            DropTable("dbo.EventosPessoas");
            DropTable("dbo.PessoasBeneficios");
            DropTable("dbo.Pagamentos");
            DropTable("dbo.Quotas");
            DropTable("dbo.FotografiasEventos");
            DropTable("dbo.Eventos");
            DropTable("dbo.Pessoas");
            DropTable("dbo.Beneficios");
        }
    }
}
