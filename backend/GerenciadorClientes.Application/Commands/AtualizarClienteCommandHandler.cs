using GerenciadorClientes.Domain.IRepositories;
using MediatR;

namespace GerenciadorClientes.Application.Commands
{
    public class AtualizarClienteCommandHandler : IRequestHandler<AtualizarClienteCommand, bool>
    {
        private readonly IClienteAggregationRepository _repository;

        public AtualizarClienteCommandHandler(IClienteAggregationRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(AtualizarClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _repository.GetByIdAsync(request.Id);

            if (cliente == null)
                return false;

            cliente.NomeEmpresa = request.NomeEmpresa;
            cliente.Porte = request.Porte;

            await _repository.UpdateAsync(cliente);

            return true;
        }
    }

}
