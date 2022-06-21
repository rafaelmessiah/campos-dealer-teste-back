using CamposDealer_Teste_Back.Data;
using CamposDealer_Teste_Back.DTO;
using CamposDealer_Teste_Back.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ModelBinding;

namespace CamposDealer_Teste_Back.Services
{
    public class ProdutoService
    {
        private CamposDealerDbContext _context = new CamposDealerDbContext();

        public async Task<List<Produto>> Listar()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> Obter(int id)
        {
            var produto = await _context.Produtos.Where(p => p.idProduto == id)
                           .FirstOrDefaultAsync();

            if (produto == null)
                throw new Exception("Não foi Possivel Encontrar o Produto");

            return produto;
        }

        public async Task<List<Produto>> Buscar(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                throw new Exception("Pesquisa invalida");

            return await _context.Produtos.Where(p => p.dscProduto.Contains(searchString))
                .ToListAsync();
        }

        public async Task<Produto> Cadastrar(ProdutoDTO dto)
        {
            dto.Validar();

            var produto = new Produto
            {
                dscProduto = dto.Descricao,
                vlrUnitario = dto.ValorUnitario
            };

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task<Produto> Editar(int id, ProdutoDTO dto)
        {
            dto.Validar();

            var produto = await _context.Produtos.Where(p => p.idProduto == id).FirstOrDefaultAsync();

            if (produto == null)
                throw new Exception("Não foi Possivel Encontrar o Produto");

            produto.dscProduto = dto.Descricao;
            produto.vlrUnitario = dto.ValorUnitario;

            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task<bool> Remover(int id)
        {
            var produto = await _context.Produtos.Where(p => p.idProduto == id).FirstOrDefaultAsync();
             
            if (produto == null)
                throw new Exception("Produto Não encontrado");

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task ObterDadosExternos()
        {
            var camposDealerService = new CamposDealerService();

            var produtos = await camposDealerService.ObterProdutos();

            foreach (var produto in produtos)
            {
                if(!_context.Produtos.Any(p => p.idProduto == produto.idProduto))
                {
                    _context.Produtos.Add(produto);
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}