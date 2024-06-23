using GerenciadorClientes.Domain.IRepositories;
using MediatR;

namespace GerenciadorClientes.Application.Commands
{
    public class RemoverClienteCommandHandler : IRequestHandler<RemoverClienteCommand, bool>
    {
        private readonly IClienteAggregationRepository _repository;

        public RemoverClienteCommandHandler(IClienteAggregationRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RemoverClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _repository.GetByIdAsync(request.Id);

            if (cliente == null)
                return false;

            await _repository.RemoveAsync(cliente);

            return true;
        }
    }

}
