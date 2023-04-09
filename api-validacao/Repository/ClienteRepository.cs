using api_validacao.Context;
using api_validacao.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace api_validacao.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext _context;

        public ClienteRepository(DataContext context)
        {
            _context = context;
        }

        public Cliente create(Cliente cliente)
        {
            var retPaciente = _context.Clientes.First(X => X.Nome == cliente.Nome);
            if (retPaciente != null) throw new Exception("já existe uma pessoa");

                _context.Add(cliente);
                _context.SaveChanges();
                return cliente;
        }

        public async Task<IEnumerable> ListaClientes()
        {
            var clientes = await _context.Clientes.ToArrayAsync();
            return clientes;
        }

        public Cliente pesquisarCliente(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(x => x.Id == id);
            return cliente;
        }
    }
}
