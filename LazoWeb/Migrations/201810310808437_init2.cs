namespace LazoWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserClaims", "TaiKhoan_Id", "dbo.TaiKhoans");
            DropForeignKey("dbo.AspNetUserLogins", "TaiKhoan_Id", "dbo.TaiKhoans");
            DropForeignKey("dbo.AspNetUserRoles", "TaiKhoan_Id", "dbo.TaiKhoans");
            DropIndex("dbo.AspNetUserRoles", new[] { "TaiKhoan_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "TaiKhoan_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "TaiKhoan_Id" });
            DropColumn("dbo.AspNetUserRoles", "TaiKhoan_Id");
            DropColumn("dbo.AspNetUserClaims", "TaiKhoan_Id");
            DropColumn("dbo.AspNetUserLogins", "TaiKhoan_Id");
            DropTable("dbo.TaiKhoans");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TaiKhoans",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUserLogins", "TaiKhoan_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserClaims", "TaiKhoan_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserRoles", "TaiKhoan_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUserLogins", "TaiKhoan_Id");
            CreateIndex("dbo.AspNetUserClaims", "TaiKhoan_Id");
            CreateIndex("dbo.AspNetUserRoles", "TaiKhoan_Id");
            AddForeignKey("dbo.AspNetUserRoles", "TaiKhoan_Id", "dbo.TaiKhoans", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "TaiKhoan_Id", "dbo.TaiKhoans", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "TaiKhoan_Id", "dbo.TaiKhoans", "Id");
        }
    }
}
