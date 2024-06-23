using GerenciadorClientes.Domain.Enums;
using MediatR;

namespace GerenciadorClientes.Application.Commands
{
    public record AtualizarClienteCommand(int Id, string NomeEmpresa, PorteEmpresa Porte) : IRequest<bool>;
}
