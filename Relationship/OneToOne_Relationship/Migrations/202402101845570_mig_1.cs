namespace OneToOne_Relationship.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeAdresses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Adress = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeAdresses", "Id", "dbo.Employees");
            DropIndex("dbo.EmployeeAdresses", new[] { "Id" });
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeAdresses");
        }
    }
}
