namespace ARCVDS_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quotas",
                c => new
                    {
                        id_Quota = c.Int(nullable: false, identity: true),
                        ano_Quota = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id_Quota);
            
            AddColumn("dbo.Pagamentos", "QuotaFK", c => c.Int(nullable: false));
            CreateIndex("dbo.Pagamentos", "QuotaFK");
            AddForeignKey("dbo.Pagamentos", "QuotaFK", "dbo.Quotas", "id_Quota", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pagamentos", "QuotaFK", "dbo.Quotas");
            DropIndex("dbo.Pagamentos", new[] { "QuotaFK" });
            DropColumn("dbo.Pagamentos", "QuotaFK");
            DropTable("dbo.Quotas");
        }
    }
}
