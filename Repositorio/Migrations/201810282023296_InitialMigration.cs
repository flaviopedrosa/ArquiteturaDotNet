namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Usuario",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(unicode: false),
                        Email = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
        }
        
        public override void Down()
        {
            DropTable("Usuario");
        }
    }
}
