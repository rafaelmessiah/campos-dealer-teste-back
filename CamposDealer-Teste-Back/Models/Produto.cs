using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CamposDealer_Teste_Back.Models
{
    public class Produto
    {
        [Key]
        public int idProduto { get; set; }
        public string dscProduto { get; set; }
        public decimal vlrUnitario { get; set; }
    }
}