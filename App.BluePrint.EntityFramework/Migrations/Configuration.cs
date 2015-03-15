namespace App.BluePrint.Migrations
{
    using App.BluePrint.EntityFramework;
    using App.BluePrint.Migrations.Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "App.BluePrint";
        }

        protected override void Seed(AppDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
            new InitialDataBuilder().Build(context);
            new AdministrationDataBuilder().Build(context);
        }
    }

    //internal sealed class AdminConfiguration : DbMigrationsConfiguration<AdministrationDbContext>
    //{
    //    public AdminConfiguration()
    //    {
    //        AutomaticMigrationsEnabled = false;
    //        ContextKey = "App.BluePrint.Config";
    //    }

    //    protected override void Seed(AdministrationDbContext context)
    //    {
    //        new AdministrationDataBuilder().Build(context);
    //    }
    //}
}
