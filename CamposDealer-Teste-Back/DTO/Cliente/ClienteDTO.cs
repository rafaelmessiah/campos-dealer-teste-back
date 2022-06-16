using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamposDealer_Teste_Back.DTO.Cliente
{
    public class ClienteDTO
    {
        public string Nome { get; set; }
        public string Cidade { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new Exception("O Nome do Cliente é Obrigatório");

            if (string.IsNullOrEmpty(Nome))
                throw new Exception("A Cidade do Cliente é Obrigatória");
        }
    }
}