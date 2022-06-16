namespace CamposDealer_Teste_Back.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixdecimalonvalor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vendas", "vlrUnitarioVenda", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Vendas", "vlrTotalVenda", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vendas", "vlrTotalVenda", c => c.Int(nullable: false));
            AlterColumn("dbo.Vendas", "vlrUnitarioVenda", c => c.Int(nullable: false));
        }
    }
}
