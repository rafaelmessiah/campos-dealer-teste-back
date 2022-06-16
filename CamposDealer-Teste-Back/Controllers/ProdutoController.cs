using CamposDealer_Teste_Back.DTO;
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
    public class ProdutoController : ApiController
    {
        protected readonly ProdutoService _produtoService;
        public ProdutoController()
        {
            _produtoService = new ProdutoService();
        }

        [HttpGet]
        public async Task<List<Produto>> Listar()
        {
            return await _produtoService.Listar();
        }

        [HttpGet]
        public async Task<Produto> Obter(int id)
        {
            return await _produtoService.Obter(id);
        }

        [HttpPost]
        public async Task<Produto> Criar([FromBody] ProdutoDTO dto)
        {
            return await _produtoService.Criar(dto);
        }

        [HttpPut]
        public async Task<Produto> Editar(int id, [FromBody] ProdutoDTO dto)
        {
            return await _produtoService.Editar(id, dto);
        }

        [HttpDelete]
        public async Task<bool> Remover(int id)
        {
            return await _produtoService.Remover(id);
        }
    }
}
