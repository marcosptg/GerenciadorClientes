using GerenciadorClientes.Domain.Enums;
using MediatR;

namespace GerenciadorClientes.Application.Commands
{
    public record CriarClienteCommand(string NomeEmpresa, PorteEmpresa Porte) : IRequest<int>;

}
