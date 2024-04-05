namespace Contry_State_City.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registers", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.Registers", "IsSubscribe", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Cities", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Registers", "MyProperty");
            DropColumn("dbo.Registers", "Subscribe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Registers", "Subscribe", c => c.Boolean(nullable: false));
            AddColumn("dbo.Registers", "MyProperty", c => c.Int(nullable: false));
            AlterColumn("dbo.Cities", "Name", c => c.String());
            DropColumn("dbo.Registers", "IsSubscribe");
            DropColumn("dbo.Registers", "Gender");
        }
    }
}
