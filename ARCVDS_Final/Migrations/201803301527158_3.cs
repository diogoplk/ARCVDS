namespace ARCVDS_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quotas", "PessoaFK", c => c.Int(nullable: false));
            CreateIndex("dbo.Quotas", "PessoaFK");
            AddForeignKey("dbo.Quotas", "PessoaFK", "dbo.Pessoas", "Pessoa_ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Quotas", "PessoaFK", "dbo.Pessoas");
            DropIndex("dbo.Quotas", new[] { "PessoaFK" });
            DropColumn("dbo.Quotas", "PessoaFK");
        }
    }
}
