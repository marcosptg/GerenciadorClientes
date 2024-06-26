using GerenciadorClientes.Domain.Events;
using GerenciadorClientes.Domain.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GerenciadorClientes.Application.EventHandlers
{
    public class ClienteRemovidoEventHandler : INotificationHandler<ClienteRemovidoEvent>
    {
        private readonly IClienteProjectionRepository _clienteProjectionRepository;
        private readonly ILogger<ClienteRemovidoEventHandler> _logger;

        public ClienteRemovidoEventHandler(
            ILogger<ClienteRemovidoEventHandler> logger,
            IClienteProjectionRepository clienteReadOnlyRepository
        )
        {
            _logger = logger;
            _clienteProjectionRepository = clienteReadOnlyRepository;
        }

        public async Task Handle(ClienteRemovidoEvent notification, CancellationToken cancellationToken)
        {
            try
            {
                var success = await _clienteProjectionRepository.RemoveAsync(notification.Id, cancellationToken);
                if (!success)
                    throw new Exception("Erro ao remover cliente no MongoDB");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao processar ClienteRemovidoEvent");
            }
        }
    }
}
