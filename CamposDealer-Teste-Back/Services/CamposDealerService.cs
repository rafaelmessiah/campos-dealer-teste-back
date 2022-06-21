using CamposDealer_Teste_Back.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace CamposDealer_Teste_Back.Services
{
    public class CamposDealerService
    {
        private readonly string _baseUrl = "https://camposdealer.dev/Sites/TesteAPI/";

        public async Task<List<Produto>> ObterProdutos()
        {
            var produtos = new List<Produto>();
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Clear();

                var res = await client.GetAsync("produto");

                if (res.IsSuccessStatusCode)
                {
                    var resposta = res.Content.ReadAsStringAsync().Result;

                    var stringResponse = JsonConvert.DeserializeObject<string>(resposta);

                    produtos = JsonConvert.DeserializeObject<List<Produto>>(stringResponse);
                }
            }

            return produtos;
        }

        public async Task<List<Cliente>> ObterClientes()
        {
            var clientes = new List<Cliente>();
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Clear();

                var res = await client.GetAsync("cliente");

                if (res.IsSuccessStatusCode)
                {
                    var resposta = res.Content.ReadAsStringAsync().Result;

                    var stringResponse = JsonConvert.DeserializeObject<string>(resposta);

                    clientes = JsonConvert.DeserializeObject<List<Cliente>>(stringResponse);
                }
            }

            return clientes;
        }
        
        public async Task<List<Venda>> ObterVendas()
        {
            var vendas = new List<Venda>();
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Clear();

                var res = await client.GetAsync("venda");

                if (res.IsSuccessStatusCode)
                {
                    var resposta = res.Content.ReadAsStringAsync().Result;

                    var stringResponse = JsonConvert.DeserializeObject<string>(resposta);

                    vendas = JsonConvert.DeserializeObject<List<Venda>>(stringResponse);
                }
            }

            return vendas;
        }
    }
}