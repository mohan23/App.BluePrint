namespace App.BluePrint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Admin_Navigation_Update : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Administration.MenuConfiguration", newName: "Navigation");
            RenameTable(name: "Administration.MenuRoles", newName: "NavigationRoles");
            AddColumn("Administration.Navigation", "RelativeUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Administration.Navigation", "RelativeUrl");
            RenameTable(name: "Administration.NavigationRoles", newName: "MenuRoles");
            RenameTable(name: "Administration.Navigation", newName: "MenuConfiguration");
        }
    }
}
