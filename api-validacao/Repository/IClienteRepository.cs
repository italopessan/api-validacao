using api_validacao.Models;
using System.Collections;

namespace api_validacao.Repository
{
    public interface IClienteRepository
    {
        Cliente create(Cliente cliente);
        Task<IEnumerable> ListaClientes();
        Cliente pesquisarCliente(int id);
    }
}
