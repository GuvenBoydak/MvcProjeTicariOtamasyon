namespace Project.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMessage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Subject = c.String(nullable: false, maxLength: 50),
                        Content = c.String(nullable: false, maxLength: 2000),
                        Sender = c.String(nullable: false, maxLength: 50),
                        Receiver = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DeletedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        ModifiedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Messages");
        }
    }
}
