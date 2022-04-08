namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Astalajes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Text = c.String(),
                        RoztAstlaje = c.Int(nullable: false),
                        Deletestatus = c.Boolean(nullable: false),
                        TarekhtAstlaje = c.DateTime(nullable: false),
                        RegDate = c.DateTime(nullable: false),
                        Persnol_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Persnols", t => t.Persnol_id)
                .Index(t => t.Persnol_id);
            
            CreateTable(
                "dbo.Persnols",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NameFamily = c.String(),
                        Kodmili = c.String(),
                        roz = c.Int(nullable: false),
                        Deletestatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Esthqhaqhes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Text = c.String(),
                        RozAsthqaqe = c.Int(nullable: false),
                        Deletestatus = c.Boolean(nullable: false),
                        TarekhAsthqaqe = c.DateTime(nullable: false),
                        RegDate = c.DateTime(nullable: false),
                        Persnol_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Persnols", t => t.Persnol_id)
                .Index(t => t.Persnol_id);
            
            CreateTable(
                "dbo.Mamorets",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Text = c.String(),
                        Deletestatus = c.Boolean(nullable: false),
                        TarekMamoret = c.DateTime(nullable: false),
                        RegDate = c.DateTime(nullable: false),
                        Persnol_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Persnols", t => t.Persnol_id)
                .Index(t => t.Persnol_id);
            
            CreateTable(
                "dbo.Tashveqhes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Text = c.String(),
                        Roztashveqh = c.Int(nullable: false),
                        Deletestatus = c.Boolean(nullable: false),
                        Tarekhtashveqh = c.DateTime(nullable: false),
                        RegDate = c.DateTime(nullable: false),
                        Persnol_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Persnols", t => t.Persnol_id)
                .Index(t => t.Persnol_id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tashveqhes", "Persnol_id", "dbo.Persnols");
            DropForeignKey("dbo.Mamorets", "Persnol_id", "dbo.Persnols");
            DropForeignKey("dbo.Esthqhaqhes", "Persnol_id", "dbo.Persnols");
            DropForeignKey("dbo.Astalajes", "Persnol_id", "dbo.Persnols");
            DropIndex("dbo.Tashveqhes", new[] { "Persnol_id" });
            DropIndex("dbo.Mamorets", new[] { "Persnol_id" });
            DropIndex("dbo.Esthqhaqhes", new[] { "Persnol_id" });
            DropIndex("dbo.Astalajes", new[] { "Persnol_id" });
            DropTable("dbo.Users");
            DropTable("dbo.Tashveqhes");
            DropTable("dbo.Mamorets");
            DropTable("dbo.Esthqhaqhes");
            DropTable("dbo.Persnols");
            DropTable("dbo.Astalajes");
        }
    }
}
