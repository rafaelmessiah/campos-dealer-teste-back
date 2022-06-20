using CamposDealer_Teste_Back.DTO.Cliente;
using CamposDealer_Teste_Back.Models;
using CamposDealer_Teste_Back.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CamposDealer_Teste_Back.Controllers
{
    public class ClienteController : ApiController
    {
        protected readonly ClienteService _clienteService;
        public ClienteController()
        {
            _clienteService = new ClienteService();
        }

        [HttpGet]
        public async Task<List<Cliente>> Listar()
        {
            return await _clienteService.Listar();
        }

        [HttpGet]
        public async Task<Cliente> Obter(int id)
        {
            return await _clienteService.Obter(id);
        }

        [HttpGet]
        public async Task<List<Cliente>> Buscar(string searchString)
        {
            return await _clienteService.Buscar(searchString);
        }

        [HttpPost]
        public async Task<Cliente> Cadastrar([FromBody]ClienteDTO dto)
        {
            return await _clienteService.Cadastrar(dto);
        }

        [HttpPut]
        public async Task<Cliente> Editar(int id, [FromBody]ClienteDTO dto)
        {
            return await _clienteService.Editar(id, dto);
        }

        [HttpDelete]
        public async Task<bool> Remover(int id)
        {
            return await _clienteService.Remover(id);
        }
    }
}
