namespace EnvanterWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Arizalar", "bolum_Id", c => c.Int());
            CreateIndex("dbo.Arizalar", "bolum_Id");
            AddForeignKey("dbo.Arizalar", "bolum_Id", "dbo.Bolumler", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Arizalar", "bolum_Id", "dbo.Bolumler");
            DropIndex("dbo.Arizalar", new[] { "bolum_Id" });
            DropColumn("dbo.Arizalar", "bolum_Id");
        }
    }
}
