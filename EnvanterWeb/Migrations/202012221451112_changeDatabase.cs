namespace EnvanterWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bolumler", "BolumAdi", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bolumler", "BolumAdi", c => c.String(maxLength: 50));
        }
    }
}
