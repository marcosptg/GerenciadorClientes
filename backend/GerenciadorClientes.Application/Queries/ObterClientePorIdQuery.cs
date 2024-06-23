using GerenciadorClientes.Domain.Dtos;
using MediatR;

namespace GerenciadorClientes.Application.Queries
{
    public class ObterClientePorIdQuery : IRequest<ClienteModel>
    {
        public int Id { get; }

        public ObterClientePorIdQuery(int id)
        {
            Id = id;
        }
    }

}

