using GerenciadorClientes.Application.Commands;
using GerenciadorClientes.Application.Queries;
using GerenciadorClientes.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorClientes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientesController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<List<ClienteModel>>> GetClientes()
            => Ok(await _mediator.Send(new ObterTodosClientesQuery()));

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteModel>> GetCliente(int id)
        {
            var cliente = await _mediator.Send(new ObterClientePorIdQuery(id));

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateCliente(CriarClienteCommand command)
        {
            var clienteId = await _mediator.Send(command);

            if (clienteId == 0)
                return BadRequest($"N�o foi poss�vel criar o cliente");

            return CreatedAtAction(nameof(GetCliente), new { id = clienteId }, clienteId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(AtualizarClienteCommand command)
        {
            var atualizado = await _mediator.Send(command);

            if (!atualizado)
                return BadRequest($"N�o foi poss�vel atualizar o cliente de id: {command.Id}");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var removido = await _mediator.Send(new RemoverClienteCommand(id));

            if (!removido)
                return BadRequest($"N�o foi poss�vel remover o cliente de id: {id}");

            return NoContent();
        }
    }

}
