using GerenciadorClientes.Domain.Dtos;
using GerenciadorClientes.Domain.Events;
using GerenciadorClientes.Domain.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GerenciadorClientes.Application.EventHandlers
{
    public class ClienteAtualizadoEventHandler : INotificationHandler<ClienteAtualizadoEvent>
    {
        private readonly IClienteProjectionRepository _clienteProjectionRepository;
        private readonly ILogger<ClienteAtualizadoEventHandler> _logger;

        public ClienteAtualizadoEventHandler(
            ILogger<ClienteAtualizadoEventHandler> logger,
            IClienteProjectionRepository clienteReadOnlyRepository
        )
        {
            _logger = logger;
            _clienteProjectionRepository = clienteReadOnlyRepository;
        }

        public async Task Handle(ClienteAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            try
            {
                var clienteReadModel = new ClienteModel
                {
                    Id = notification.Id,
                    NomeEmpresa = notification.NomeEmpresa,
                    Porte = notification.Porte.ToString()
                };

                var success = await _clienteProjectionRepository.UpdateAsync(clienteReadModel);
                if (!success)
                    throw new Exception("Erro ao atualizar cliente no MongoDB");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao processar ClienteAtualizadoEvent");
            }
        }
    }
}
