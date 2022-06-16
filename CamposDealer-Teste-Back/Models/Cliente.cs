using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CamposDealer_Teste_Back.Models
{
    public class Cliente
    {
        [Key]
        public int idCliente { get; set; }
        public string nmCliente { get; set; }
        public string Cidade { get; set; }
    }
}