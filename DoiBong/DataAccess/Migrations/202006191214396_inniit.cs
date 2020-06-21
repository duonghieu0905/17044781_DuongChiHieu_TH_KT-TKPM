namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inniit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CauThus",
                c => new
                    {
                        macauthu = c.Int(nullable: false, identity: true),
                        tencauthu = c.String(),
                        sodt = c.String(),
                        email = c.String(),
                        iddoibong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.macauthu)
                .ForeignKey("dbo.DoiBongs", t => t.iddoibong, cascadeDelete: true)
                .Index(t => t.iddoibong);
            
            CreateTable(
                "dbo.DoiBongs",
                c => new
                    {
                        madoibong = c.Int(nullable: false, identity: true),
                        tendoibong = c.String(),
                    })
                .PrimaryKey(t => t.madoibong);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CauThus", "iddoibong", "dbo.DoiBongs");
            DropIndex("dbo.CauThus", new[] { "iddoibong" });
            DropTable("dbo.DoiBongs");
            DropTable("dbo.CauThus");
        }
    }
}
