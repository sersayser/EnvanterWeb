namespace EnvanterWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arizalar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CihazId = c.Int(nullable: false),
                        Tarih = c.DateTime(nullable: false),
                        KullaniciId = c.Int(nullable: false),
                        Aciklama = c.String(),
                        ArizaBittiMi = c.Boolean(nullable: false,defaultValue:false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cihazlar", t => t.CihazId, cascadeDelete: true)
                .ForeignKey("dbo.Kullanicilar", t => t.KullaniciId, cascadeDelete: true)
                .Index(t => t.CihazId)
                .Index(t => t.KullaniciId);
            
            CreateTable(
                "dbo.Cihazlar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BolumId = c.Int(nullable: false),
                        UretimYili = c.Int(nullable: false),
                        MarkaId = c.Int(nullable: false),
                        CihazTipiId = c.Int(nullable: false),
                        Model = c.String(nullable: false, maxLength: 50),
                        SeriNo = c.String(nullable: false, maxLength: 50),
                        GarantiliMi = c.Boolean(nullable: false,defaultValue:true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bolumler", t => t.BolumId, cascadeDelete: true)
                .ForeignKey("dbo.CihazTipleri", t => t.CihazTipiId, cascadeDelete: true)
                .ForeignKey("dbo.Markalar", t => t.MarkaId, cascadeDelete: true)
                .Index(t => t.BolumId)
                .Index(t => t.MarkaId)
                .Index(t => t.CihazTipiId);
            
            CreateTable(
                "dbo.Bolumler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BolumAdi = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CihazTipleri",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CihazTipiAdi = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Markalar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MarkaAdi = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kullanicilar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KullaniciAdi = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        AdSoyad = c.String(nullable: false, maxLength: 50),
                        KullaniciTipi = c.Int(nullable: false),
                        BolumId = c.Int(nullable: false),
                        AktifMi = c.Boolean(nullable: false, defaultValue:true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bolumler", t => t.BolumId, cascadeDelete: false)
                .Index(t => t.BolumId);
            
            CreateTable(
                "dbo.Bakimlar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CihazId = c.Int(nullable: false),
                        FirmaId = c.Int(nullable: false),
                        Tarih = c.DateTime(nullable: false),
                        BakimYapildiMi = c.Boolean(nullable: false,defaultValue:false),
                        ParcaDahilMi = c.Boolean(nullable: false,defaultValue:false),
                        BakimSayisi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cihazlar", t => t.CihazId, cascadeDelete: true)
                .ForeignKey("dbo.Firmalar", t => t.FirmaId, cascadeDelete: true)
                .Index(t => t.CihazId)
                .Index(t => t.FirmaId);
            
            CreateTable(
                "dbo.Firmalar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirmaAdi = c.String(nullable: false, maxLength: 50),
                        TelefonNo = c.String(nullable: false, maxLength: 15),
                        KontakKisi = c.String(),
                        KontakTelefon = c.String(),
                        AktifMi = c.Boolean(nullable: false, defaultValue:true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KullaniciTipleri",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipi = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bakimlar", "FirmaId", "dbo.Firmalar");
            DropForeignKey("dbo.Bakimlar", "CihazId", "dbo.Cihazlar");
            DropForeignKey("dbo.Arizalar", "KullaniciId", "dbo.Kullanicilar");
            DropForeignKey("dbo.Kullanicilar", "BolumId", "dbo.Bolumler");
            DropForeignKey("dbo.Arizalar", "CihazId", "dbo.Cihazlar");
            DropForeignKey("dbo.Cihazlar", "MarkaId", "dbo.Markalar");
            DropForeignKey("dbo.Cihazlar", "CihazTipiId", "dbo.CihazTipleri");
            DropForeignKey("dbo.Cihazlar", "BolumId", "dbo.Bolumler");
            DropIndex("dbo.Bakimlar", new[] { "FirmaId" });
            DropIndex("dbo.Bakimlar", new[] { "CihazId" });
            DropIndex("dbo.Kullanicilar", new[] { "BolumId" });
            DropIndex("dbo.Cihazlar", new[] { "CihazTipiId" });
            DropIndex("dbo.Cihazlar", new[] { "MarkaId" });
            DropIndex("dbo.Cihazlar", new[] { "BolumId" });
            DropIndex("dbo.Arizalar", new[] { "KullaniciId" });
            DropIndex("dbo.Arizalar", new[] { "CihazId" });
            DropTable("dbo.KullaniciTipleri");
            DropTable("dbo.Firmalar");
            DropTable("dbo.Bakimlar");
            DropTable("dbo.Kullanicilar");
            DropTable("dbo.Markalar");
            DropTable("dbo.CihazTipleri");
            DropTable("dbo.Bolumler");
            DropTable("dbo.Cihazlar");
            DropTable("dbo.Arizalar");
        }
    }
}
