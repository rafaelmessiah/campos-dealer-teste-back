﻿using CamposDealer_Teste_Back.Data;
using CamposDealer_Teste_Back.DTO.Venda;
using CamposDealer_Teste_Back.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CamposDealer_Teste_Back.Services
{
    public class VendaService
    {
        private CamposDealerDbContext _context = new CamposDealerDbContext();
        
        public async Task<List<Venda>> Listar()
        {
            return await _context.Vendas.ToListAsync();
        }

        public async Task<Venda> Cadastrar(CadastrarVendaDTO dto)
        {
            dto.Validar();

            //Encontra o Produto
            var produto = await _context.Produtos.Where(p => p.idProduto == dto.idProduto)
                         .FirstOrDefaultAsync();

            if (produto == null)
                throw new Exception("Não foi possível encontrar o Produto");

            //Encontra o Cliente
            var cliente = await _context.Clientes.Where(c => c.idCliente == dto.idCliente)
                         .FirstOrDefaultAsync();

            if (cliente == null)
                throw new Exception("Não foi possível encontrar o Cliente");

            //Cria o Objeto Venda
            var venda = new Venda
            {
                idCliente = cliente.idCliente,
                idProduto = produto.idProduto,
                qtdVenda = dto.qtdVenda,
                vlrUnitarioVenda = produto.vlrUnitario,
                dthVenda = DateTime.Now,
                vlrTotalVenda = produto.vlrUnitario * dto.qtdVenda
            };

            _context.Vendas.Add(venda);
            await _context.SaveChangesAsync();

            return venda;
        }

        public async Task<Venda> Obter(int id)
        {
            var venda = await _context.Vendas.Where(v => v.idVenda == id)
                .Include(v => v.Produto)
                .Include(v => v.Cliente)
                .FirstOrDefaultAsync();

            if (venda == null)
                throw new Exception("Não vou possível encontrar a Venda");

            return venda;
        }

        public async Task<Venda> Editar(int id, EditarVendaDTO dto)
        {
            //Encontra a Venda
            var venda = await _context.Vendas.Where(v => v.idVenda == id).FirstOrDefaultAsync();

            if (venda == null)
                throw new Exception("Não foi possivel encontrar a Venda");

            //Encontra o Produto
            var produto = await _context.Produtos.Where(p => p.idProduto == dto.idProduto)
                         .FirstOrDefaultAsync();

            if (produto == null)
                throw new Exception("Não foi possível encontrar o Produto");

            //Encontra o Cliente
            var cliente = await _context.Clientes.Where(c => c.idCliente == dto.idCliente)
                         .FirstOrDefaultAsync();

            if (cliente == null)
                throw new Exception("Não foi possível encontrar o Cliente");

            //Valida a data
            if (DateTime.Compare(dto.dthVenda, DateTime.Now) > 0)
                throw new Exception("Nova data de venda inválida");

            //Atualiza os dados da venda
            venda.idCliente = cliente.idCliente;
            venda.idProduto = produto.idProduto;
            venda.qtdVenda = dto.qtdVenda;
            venda.vlrUnitarioVenda = produto.vlrUnitario;
            venda.dthVenda = dto.dthVenda;
            venda.vlrTotalVenda = produto.vlrUnitario * dto.qtdVenda;

            await _context.SaveChangesAsync();

            return venda;
        }

        public async Task<bool> Remover(int id)
        {
            var venda = await _context.Vendas.Where(v => v.idVenda == id).FirstOrDefaultAsync();

            if (venda == null)
                throw new Exception("Não foi possível encontrar a venda");

            _context.Vendas.Remove(venda);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}