namespace OneToOne_Relationship.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeAdresses", "EmployeeID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeAdresses", "EmployeeID");
        }
    }
}
