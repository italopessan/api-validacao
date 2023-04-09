using api_validacao.Models;
using api_validacao.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api_validacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpPost]
        public IActionResult post(Cliente cliente)
        {
            var clientes =  _clienteRepository.create(cliente);
            return Ok(clientes);
        }
        [HttpGet]
        public async Task<IActionResult> list()
        {
            var clientes = await _clienteRepository.ListaClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public  IActionResult pesquisarCliente(int id)
        {
            var clientes =  _clienteRepository.pesquisarCliente(id);

            if (clientes == null) return NotFound("Cliente não encontrado");
            return Ok(clientes);
        }
    }
}
