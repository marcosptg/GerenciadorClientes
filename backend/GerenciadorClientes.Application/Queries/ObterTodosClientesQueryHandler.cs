using GerenciadorClientes.Domain.Dtos;
using GerenciadorClientes.Domain.IRepositories;
using MediatR;

namespace GerenciadorClientes.Application.Queries
{
    public class ObterTodosClientesQueryHandler : IRequestHandler<ObterTodosClientesQuery, List<ClienteModel>>
    {
        private readonly IClienteProjectionRepository _clienteReadRepository;

        public ObterTodosClientesQueryHandler(IClienteProjectionRepository clienteReadRepository) =>
            _clienteReadRepository = clienteReadRepository;

        public Task<List<ClienteModel>> Handle(ObterTodosClientesQuery request, CancellationToken cancellationToken) =>
            _clienteReadRepository.GetAllAsync(cancellationToken);
    }

}
