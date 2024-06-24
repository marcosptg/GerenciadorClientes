using GerenciadorClientes.Domain.Events;
using GerenciadorClientes.Domain.IRepositories;
using MediatR;

namespace GerenciadorClientes.Application.Commands
{
    public class AtualizarClienteCommandHandler : IRequestHandler<AtualizarClienteCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IClienteAggregationRepository _clienteAggregationRepository;

        public AtualizarClienteCommandHandler(
            IMediator mediator,
            IClienteAggregationRepository clienteAggregationRepository)
        {
            _mediator = mediator;
            _clienteAggregationRepository = clienteAggregationRepository;
        }

        public async Task<bool> Handle(AtualizarClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteAggregationRepository.GetByIdAsync(request.Id);

            if (cliente == null)
                return false;

            cliente.NomeEmpresa = request.NomeEmpresa;
            cliente.Porte = request.Porte;

            await _clienteAggregationRepository.UpdateAsync(cliente);

            await _mediator.Publish(new ClienteAtualizadoEvent(cliente.Id, cliente.NomeEmpresa, cliente.Porte), cancellationToken);

            return true;
        }
    }

}
