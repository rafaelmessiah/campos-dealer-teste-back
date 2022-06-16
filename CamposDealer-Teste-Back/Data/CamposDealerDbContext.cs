using CamposDealer_Teste_Back.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CamposDealer_Teste_Back.Data
{
    public class CamposDealerDbContext : DbContext
    {
        public CamposDealerDbContext(): base("CamposDealerTesteConnectionString")
        {
        }

        public static CamposDealerDbContext Create()
        {
            return new CamposDealerDbContext();
        }

        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}