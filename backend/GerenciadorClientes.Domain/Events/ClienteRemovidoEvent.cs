using MediatR;

namespace GerenciadorClientes.Domain.Events
{
    public record ClienteRemovidoEvent(int Id) : INotification;

}
