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
            var cliente = await _clienteAggregationRepository.GetByIdAsync(request.Id, cancellationToken);

            if (cliente == null)
                return false;

            cliente.AddNomeEmpresa(request.NomeEmpresa);
            cliente.AddPorteEmpresa(request.Porte);

            await _clienteAggregationRepository.UpdateAsync(cliente, cancellationToken);

            await _mediator.Publish(new ClienteAtualizadoEvent(cliente.Id, cliente.NomeEmpresa, cliente.Porte), cancellationToken);

            return true;
        }
    }

}
