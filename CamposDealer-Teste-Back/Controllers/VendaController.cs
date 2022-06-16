using CamposDealer_Teste_Back.DTO.Venda;
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
    public class VendaController : ApiController
    {
        protected readonly VendaService _vendaService;
        public VendaController()
        {
            _vendaService = new VendaService();
        }

        [HttpGet]
        public async Task<List<Venda>> Listar()
        {
            return await _vendaService.Listar();
        }

        [HttpPost]
        public async Task<Venda> Cadastrar([FromBody]CadastrarVendaDTO dto)
        {
            return await _vendaService.Cadastrar(dto);
        }

        [HttpGet]
        public async Task<Venda> Obter(int id)
        {
            return await _vendaService.Obter(id);
        }

        [HttpPut]
        public async Task<Venda> Editar(int id, [FromBody]EditarVendaDTO dto)
        {
            return await _vendaService.Editar(id, dto);
        }

        [HttpDelete]
        public async Task<bool> Remover(int id)
        {
            return await _vendaService.Remover(id);
        }
    }
}
