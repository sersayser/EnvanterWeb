namespace EnvanterWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeBakim : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bakimlar", "CihazId", "dbo.Cihazlar");
            DropForeignKey("dbo.Bakimlar", "FirmaId", "dbo.Firmalar");
            DropIndex("dbo.Bakimlar", new[] { "CihazId" });
            DropIndex("dbo.Bakimlar", new[] { "FirmaId" });
            DropTable("dbo.Bakimlar");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Bakimlar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CihazId = c.Int(nullable: false),
                        FirmaId = c.Int(nullable: false),
                        Tarih = c.DateTime(nullable: false),
                        BakimYapildiMi = c.Boolean(nullable: false),
                        ParcaDahilMi = c.Boolean(nullable: false),
                        BakimSayisi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Bakimlar", "FirmaId");
            CreateIndex("dbo.Bakimlar", "CihazId");
            AddForeignKey("dbo.Bakimlar", "FirmaId", "dbo.Firmalar", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bakimlar", "CihazId", "dbo.Cihazlar", "Id", cascadeDelete: true);
        }
    }
}
