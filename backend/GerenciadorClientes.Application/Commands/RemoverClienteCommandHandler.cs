using GerenciadorClientes.Domain.Events;
using GerenciadorClientes.Domain.IRepositories;
using MediatR;

namespace GerenciadorClientes.Application.Commands
{
    public class RemoverClienteCommandHandler : IRequestHandler<RemoverClienteCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IClienteAggregationRepository _repository;

        public RemoverClienteCommandHandler(
            IMediator mediator,
            IClienteAggregationRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<bool> Handle(RemoverClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _repository.GetByIdAsync(request.Id);

            if (cliente == null)
                return false;

            await _repository.RemoveAsync(cliente);

            await _mediator.Publish(new ClienteRemovidoEvent(cliente.Id), cancellationToken);

            return true;
        }
    }

}
