using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CamposDealer_Teste_Back.Models
{
    public class Venda
    {
        [Key]
        public int idVenda { get; set; }
        public int qtdVenda { get; set; }
        public int vlrUnitarioVenda { get; set; }
        public DateTime dthVenda { get; set; }
        public int vlrTotalVenda { get; set; }

        //FK - Cliente
        public int idCliente { get; set; }
        [ForeignKey(nameof(idCliente))]
        public Cliente Cliente { get; set; }

        //FK - Produto
        public int idProduto { get; set; }
        [ForeignKey(nameof(idProduto))]
        public Produto Produto { get; set; }
    }
}