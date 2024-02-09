namespace OneToMany_Relationship.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "Room", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "Room");
        }
    }
}
