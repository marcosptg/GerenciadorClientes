using GerenciadorClientes.Domain.Enums;
using MediatR;

namespace GerenciadorClientes.Domain.Events
{
    public record ClienteAtualizadoEvent(int Id, string NomeEmpresa, PorteEmpresa Porte) : INotification;

}
