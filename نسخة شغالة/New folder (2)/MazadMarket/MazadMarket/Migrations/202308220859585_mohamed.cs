namespace MazadMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mohamed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.paymentConfirmations", "ProductsAuctionId", "dbo.ProductsAuctions");
            DropIndex("dbo.paymentConfirmations", new[] { "ProductsAuctionId" });
            RenameColumn(table: "dbo.paymentConfirmations", name: "ProductsAuctionId", newName: "ProductsAuction_Id");
            AlterColumn("dbo.paymentConfirmations", "ProductsAuction_Id", c => c.Int());
            CreateIndex("dbo.paymentConfirmations", "ProductsAuction_Id");
            AddForeignKey("dbo.paymentConfirmations", "ProductsAuction_Id", "dbo.ProductsAuctions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.paymentConfirmations", "ProductsAuction_Id", "dbo.ProductsAuctions");
            DropIndex("dbo.paymentConfirmations", new[] { "ProductsAuction_Id" });
            AlterColumn("dbo.paymentConfirmations", "ProductsAuction_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.paymentConfirmations", name: "ProductsAuction_Id", newName: "ProductsAuctionId");
            CreateIndex("dbo.paymentConfirmations", "ProductsAuctionId");
            AddForeignKey("dbo.paymentConfirmations", "ProductsAuctionId", "dbo.ProductsAuctions", "Id", cascadeDelete: true);
        }
    }
}
