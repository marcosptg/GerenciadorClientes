using GerenciadorClientes.Domain.Dtos;
using GerenciadorClientes.Domain.IRepositories;
using MediatR;

namespace GerenciadorClientes.Application.Queries
{
    public class ObterClientePorIdQueryHandler : IRequestHandler<ObterClientePorIdQuery, ClienteModel>
    {
        private readonly IClienteProjectionRepository _repository;

        public ObterClientePorIdQueryHandler(IClienteProjectionRepository repository)
        {
            _repository = repository;
        }

        public async Task<ClienteModel> Handle(ObterClientePorIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }

}

