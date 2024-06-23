using GerenciadorClientes.Domain.Dtos;
using MediatR;

namespace GerenciadorClientes.Application.Queries
{
    public record ObterTodosClientesQuery : IRequest<List<ClienteModel>>;
}

