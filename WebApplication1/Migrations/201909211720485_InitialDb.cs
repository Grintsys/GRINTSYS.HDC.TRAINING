namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountEntries",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AccountId = c.Long(nullable: false),
                        Description = c.String(nullable: false),
                        Debit = c.Double(nullable: false),
                        Credit = c.Double(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        IsEnable = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AccNumber = c.String(nullable: false),
                        AccFatherNumber = c.String(),
                        Name = c.String(nullable: false, maxLength: 200),
                        Total = c.Double(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        IsEnable = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountEntries", "AccountId", "dbo.Accounts");
            DropIndex("dbo.AccountEntries", new[] { "AccountId" });
            DropTable("dbo.Accounts");
            DropTable("dbo.AccountEntries");
        }
    }
}
