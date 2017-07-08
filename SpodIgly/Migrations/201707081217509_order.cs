namespace SpodIgly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "FirstName", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Orders", "LastName", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Orders", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "PhoneNumber", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Orders", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Email", c => c.String());
            AlterColumn("dbo.Orders", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Orders", "Address", c => c.String());
            AlterColumn("dbo.Orders", "LastName", c => c.String(maxLength: 150));
            AlterColumn("dbo.Orders", "FirstName", c => c.String(maxLength: 150));
        }
    }
}
