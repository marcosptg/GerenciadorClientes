using GerenciadorClientes.Domain.Dtos;
using GerenciadorClientes.Domain.Events;
using GerenciadorClientes.Infrastructure.Data;
using MediatR;

namespace GerenciadorClientes.Application.EventHandlers
{
    public class ClienteCriadoEventHandler : INotificationHandler<ClienteCriadoEvent>
    {
        private readonly MongoDbContext _context;

        public ClienteCriadoEventHandler(MongoDbContext context) => _context = context;

        public Task Handle(ClienteCriadoEvent notification, CancellationToken cancellationToken) =>
            _context.Clientes.InsertOneAsync(new ClienteModel
            {
                Id = notification.Id,
                NomeEmpresa = notification.NomeEmpresa,
                Porte = notification.Porte.ToString()
            }, cancellationToken: cancellationToken);
    }
}
