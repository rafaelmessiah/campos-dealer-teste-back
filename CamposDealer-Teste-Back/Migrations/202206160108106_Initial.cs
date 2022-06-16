namespace CamposDealer_Teste_Back.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        idCliente = c.Int(nullable: false, identity: true),
                        nmCliente = c.String(),
                        Cidade = c.String(),
                    })
                .PrimaryKey(t => t.idCliente);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        idProduto = c.Int(nullable: false, identity: true),
                        dscProduto = c.String(),
                        vlrUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.idProduto);
            
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        idVenda = c.Int(nullable: false, identity: true),
                        qtdVenda = c.Int(nullable: false),
                        vlrUnitarioVenda = c.Int(nullable: false),
                        dthVenda = c.DateTime(nullable: false),
                        vlrTotalVenda = c.Int(nullable: false),
                        idCliente = c.Int(nullable: false),
                        idProduto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idVenda)
                .ForeignKey("dbo.Clientes", t => t.idCliente, cascadeDelete: true)
                .ForeignKey("dbo.Produtoes", t => t.idProduto, cascadeDelete: true)
                .Index(t => t.idCliente)
                .Index(t => t.idProduto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendas", "idProduto", "dbo.Produtoes");
            DropForeignKey("dbo.Vendas", "idCliente", "dbo.Clientes");
            DropIndex("dbo.Vendas", new[] { "idProduto" });
            DropIndex("dbo.Vendas", new[] { "idCliente" });
            DropTable("dbo.Vendas");
            DropTable("dbo.Produtoes");
            DropTable("dbo.Clientes");
        }
    }
}
