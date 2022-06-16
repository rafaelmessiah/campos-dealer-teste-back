using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CamposDealer_Teste_Back.DTO
{
    public class ProdutoDTO
    {
        public string Descricao { get; set; }
        public decimal ValorUnitario { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Descricao))
                throw new Exception("Campo Descrição é obrigatório");

            if (ValorUnitario <= 0)
                throw new Exception("Valor unitário não pode ser menor que zero");

        }
    }
}