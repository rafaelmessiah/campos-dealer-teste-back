using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamposDealer_Teste_Back.DTO.Venda
{
    public class EditarVendaDTO
    {
        public int idProduto { get; set; }
        public int idCliente { get; set; }
        public int qtdVenda { get; set; }
        public DateTime dthVenda { get; set; }

        public void Validar()
        {
            if (idCliente <= 0)
                throw new Exception("É necessário informar um Id de Cliente Válido");

            if (idProduto <= 0)
                throw new Exception("É necessário informar um Id de Produto Válido");

            if (qtdVenda <= 0)
                throw new Exception("É ncessario informar uma quantiade de Produto Válida");
        }
    }
}