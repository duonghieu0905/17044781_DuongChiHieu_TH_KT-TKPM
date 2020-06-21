namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        macauthu = c.String(nullable: false, maxLength: 128),
                        tencauthu = c.String(),
                        sodt = c.String(),
                        email = c.String(),
                        madoibong = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.macauthu)
                .ForeignKey("dbo.Teams", t => t.madoibong)
                .Index(t => t.madoibong);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        madoibong = c.String(nullable: false, maxLength: 128),
                        tendoibong = c.String(),
                    })
                .PrimaryKey(t => t.madoibong);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "madoibong", "dbo.Teams");
            DropIndex("dbo.Players", new[] { "madoibong" });
            DropTable("dbo.Teams");
            DropTable("dbo.Players");
        }
    }
}
