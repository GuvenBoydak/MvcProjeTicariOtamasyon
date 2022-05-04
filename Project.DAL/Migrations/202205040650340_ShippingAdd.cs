namespace Project.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShippingAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShippingDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 250),
                        TrackingCode = c.String(nullable: false, maxLength: 10),
                        Employee = c.String(nullable: false, maxLength: 40),
                        Receiver = c.String(nullable: false, maxLength: 40),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DeletedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        ModifiedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ShippingTrackings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TrackingCode = c.String(nullable: false, maxLength: 10),
                        Description = c.String(nullable: false, maxLength: 150),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DeletedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        ModifiedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ShippingTrackings");
            DropTable("dbo.ShippingDetails");
        }
    }
}
