namespace MethodologyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_Project : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Experiments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        start_date = c.String(),
                        end_date = c.String(nullable: false, maxLength: 30),
                        name = c.String(nullable: false, maxLength: 30),
                        description = c.String(nullable: false, maxLength: 70),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Volunteers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        national_id = c.Int(nullable: false),
                        name = c.String(nullable: false, maxLength: 30),
                        address = c.String(nullable: false, maxLength: 30),
                        phone_number = c.String(nullable: false, maxLength: 11),
                        age = c.Int(nullable: false),
                        experiment_id = c.Int(),
                        note = c.String(),
                        Status = c.Boolean(nullable: false),
                        UserRole_id = c.Int(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Experiments", t => t.experiment_id)
                .ForeignKey("dbo.UserRoles", t => t.UserRole_id, cascadeDelete: true)
                .Index(t => t.experiment_id)
                .Index(t => t.UserRole_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Volunteers", "UserRole_id", "dbo.UserRoles");
            DropForeignKey("dbo.Volunteers", "experiment_id", "dbo.Experiments");
            DropIndex("dbo.Volunteers", new[] { "UserRole_id" });
            DropIndex("dbo.Volunteers", new[] { "experiment_id" });
            DropTable("dbo.Volunteers");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Experiments");
        }
    }
}
