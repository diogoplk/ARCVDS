namespace ARCVDS_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
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
                        Sexo = c.String(nullable: false, maxLength: 1),
                        Morada = c.String(nullable: false, maxLength: 50),
                        Codigo_Postal = c.String(nullable: false, maxLength: 25),
                        Nacionalidade = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 30),
                        Foto = c.String(nullable: false, maxLength: 30),
                        numeroTelefone = c.String(nullable: false, maxLength: 13),
                        numeroTelemovel = c.String(nullable: false, maxLength: 13),
                    })
                .PrimaryKey(t => t.Pessoa_ID);
            
            CreateTable(
                "dbo.Pagamentos",
                c => new
                    {
                        id_Pagamento = c.Int(nullable: false, identity: true),
                        Valor_Pagamento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        data_Pagamento = c.DateTime(nullable: false),
                        ultima_Ano_Pago = c.DateTime(nullable: false),
                        PessoaFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_Pagamento)
                .ForeignKey("dbo.Pessoas", t => t.PessoaFK, cascadeDelete: true)
                .Index(t => t.PessoaFK);
            
            CreateTable(
                "dbo.Eventos",
                c => new
                    {
                        id_Evento = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 255),
                        Dia_Evento = c.DateTime(nullable: false),
                        numero_Pessoas = c.Single(nullable: false),
                        imagens_Evento = c.String(nullable: false, maxLength: 30),
                        nome_Patrocinador = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.id_Evento);
            
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        id_FuncionarioFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_FuncionarioFK)
                .ForeignKey("dbo.Pessoas", t => t.id_FuncionarioFK)
                .Index(t => t.id_FuncionarioFK);
            
            CreateTable(
                "dbo.Socios",
                c => new
                    {
                        id_SocioFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_SocioFK)
                .ForeignKey("dbo.Pessoas", t => t.id_SocioFK)
                .Index(t => t.id_SocioFK);
            
            CreateTable(
                "dbo.PessoasBeneficios",
                c => new
                    {
                        Pessoas_Pessoa_ID = c.Int(nullable: false),
                        Beneficios_id_Beneficio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pessoas_Pessoa_ID, t.Beneficios_id_Beneficio })
                .ForeignKey("dbo.Pessoas", t => t.Pessoas_Pessoa_ID, cascadeDelete: true)
                .ForeignKey("dbo.Beneficios", t => t.Beneficios_id_Beneficio, cascadeDelete: true)
                .Index(t => t.Pessoas_Pessoa_ID)
                .Index(t => t.Beneficios_id_Beneficio);
            
            CreateTable(
                "dbo.FuncionariosEventos",
                c => new
                    {
                        Funcionarios_id_FuncionarioFK = c.Int(nullable: false),
                        Eventos_id_Evento = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Funcionarios_id_FuncionarioFK, t.Eventos_id_Evento })
                .ForeignKey("dbo.Funcionarios", t => t.Funcionarios_id_FuncionarioFK, cascadeDelete: true)
                .ForeignKey("dbo.Eventos", t => t.Eventos_id_Evento, cascadeDelete: true)
                .Index(t => t.Funcionarios_id_FuncionarioFK)
                .Index(t => t.Eventos_id_Evento);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Socios", "id_SocioFK", "dbo.Pessoas");
            DropForeignKey("dbo.Funcionarios", "id_FuncionarioFK", "dbo.Pessoas");
            DropForeignKey("dbo.FuncionariosEventos", "Eventos_id_Evento", "dbo.Eventos");
            DropForeignKey("dbo.FuncionariosEventos", "Funcionarios_id_FuncionarioFK", "dbo.Funcionarios");
            DropForeignKey("dbo.Pagamentos", "PessoaFK", "dbo.Pessoas");
            DropForeignKey("dbo.PessoasBeneficios", "Beneficios_id_Beneficio", "dbo.Beneficios");
            DropForeignKey("dbo.PessoasBeneficios", "Pessoas_Pessoa_ID", "dbo.Pessoas");
            DropIndex("dbo.FuncionariosEventos", new[] { "Eventos_id_Evento" });
            DropIndex("dbo.FuncionariosEventos", new[] { "Funcionarios_id_FuncionarioFK" });
            DropIndex("dbo.PessoasBeneficios", new[] { "Beneficios_id_Beneficio" });
            DropIndex("dbo.PessoasBeneficios", new[] { "Pessoas_Pessoa_ID" });
            DropIndex("dbo.Socios", new[] { "id_SocioFK" });
            DropIndex("dbo.Funcionarios", new[] { "id_FuncionarioFK" });
            DropIndex("dbo.Pagamentos", new[] { "PessoaFK" });
            DropTable("dbo.FuncionariosEventos");
            DropTable("dbo.PessoasBeneficios");
            DropTable("dbo.Socios");
            DropTable("dbo.Funcionarios");
            DropTable("dbo.Eventos");
            DropTable("dbo.Pagamentos");
            DropTable("dbo.Pessoas");
            DropTable("dbo.Beneficios");
        }
    }
}
