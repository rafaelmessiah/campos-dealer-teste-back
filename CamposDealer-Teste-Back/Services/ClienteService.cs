using CamposDealer_Teste_Back.Data;
using CamposDealer_Teste_Back.DTO.Cliente;
using CamposDealer_Teste_Back.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CamposDealer_Teste_Back.Services
{
    public class ClienteService
    {
        private CamposDealerDbContext _context = new CamposDealerDbContext();

        public async Task<List<Cliente>> Listar()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> Obter(int id)
        {
            var cliente = await _context.Clientes.Where(p => p.idCliente == id)
                           .FirstOrDefaultAsync();

            if (cliente == null)
                throw new Exception("Não foi Possivel Encontrar o cliente");

            return cliente;

        }

        public async Task<List<Cliente>> Buscar(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                throw new Exception("Pesquisa invalida");

            return await _context.Clientes.Where(c => c.nmCliente.Contains(searchString))
                .ToListAsync();
        }

        public async Task<Cliente> Cadastrar(ClienteDTO dto)
        {
            dto.Validar();

            var cliente = new Cliente
            {
                nmCliente = dto.Nome,
                Cidade = dto.Cidade
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

        public async Task<Cliente> Editar(int id, ClienteDTO dto)
        {
            dto.Validar();

            var cliente = await _context.Clientes.Where(c => c.idCliente == id).FirstOrDefaultAsync();

            if (cliente == null)
                throw new Exception("Não foi Possivel Encontrar o Cliente");

            cliente.nmCliente = dto.Nome;
            cliente.Cidade = dto.Cidade;

            await _context.SaveChangesAsync();

            return cliente;
        }

        public async Task<bool> Remover(int id)
        {
            var cliente = await _context.Clientes.Where(p => p.idCliente == id).FirstOrDefaultAsync();

            if (cliente == null)
                throw new Exception("Cliente Não encontrado");

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task ObterDadosExternos()
        {
            var camposDealerService = new CamposDealerService();

            var clientes = await camposDealerService.ObterClientes();

            foreach (var cliente in clientes)
            {
                if (!_context.Clientes.Any(c => c.idCliente == cliente.idCliente))
                {
                    _context.Clientes.Add(cliente);
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}