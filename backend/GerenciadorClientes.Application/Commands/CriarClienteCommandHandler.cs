using GerenciadorClientes.Domain.Entities;
using GerenciadorClientes.Domain.Events;
using GerenciadorClientes.Domain.IRepositories;
using MediatR;

namespace GerenciadorClientes.Application.Commands
{
    public class CriarClienteCommandHandler : IRequestHandler<CriarClienteCommand, int>
    {
        private readonly IClienteAggregationRepository _clienteRepositorio;
        private readonly IMediator _mediator;

        public CriarClienteCommandHandler(IClienteAggregationRepository clienteRepositorio, IMediator mediator)
            => (_clienteRepositorio, _mediator) = (clienteRepositorio, mediator);

        public async Task<int> Handle(CriarClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = new Cliente(request.NomeEmpresa, request.Porte);
            await _clienteRepositorio.AddAsync(cliente, cancellationToken);

            await _mediator.Publish(new ClienteCriadoEvent(cliente.Id, cliente.NomeEmpresa, cliente.Porte), cancellationToken);

            return cliente.Id;
        }
    }

}
