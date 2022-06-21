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
    public class CamposDealerController : ApiController
    {
        protected readonly CamposDealerService _camposDealerService;

        public CamposDealerController()
        {
            _camposDealerService = new CamposDealerService();
        }

        [HttpGet]
        public async Task<List<Produto>> ObterProdutos()
        {
            return await _camposDealerService.ObterProdutos();
        }

        [HttpGet]
        public async Task<List<Cliente>> ObterClientes()
        {
            return await _camposDealerService.ObterClientes();
        }

        [HttpGet]
        public async Task<List<Venda>> ObterVendas()
        {
            return await _camposDealerService.ObterVendas();
        }
    }
}
