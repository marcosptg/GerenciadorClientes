using GerenciadorClientes.Domain.Dtos;
using GerenciadorClientes.Domain.Events;
using GerenciadorClientes.Domain.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GerenciadorClientes.Application.EventHandlers
{

    public class ClienteCriadoEventHandler : INotificationHandler<ClienteCriadoEvent>
    {
        private readonly IClienteProjectionRepository _clienteProjectionRepository;
        private readonly ILogger<ClienteCriadoEventHandler> _logger;

        public ClienteCriadoEventHandler(
            ILogger<ClienteCriadoEventHandler> logger,
            IClienteProjectionRepository clienteProjectionRepository
            )
        {
            _logger = logger;
            _clienteProjectionRepository = clienteProjectionRepository;
        }

        public async Task Handle(ClienteCriadoEvent notification, CancellationToken cancellationToken)
        {
            try
            {
                var clienteReadModel = new ClienteModel
                {
                    Id = notification.Id,
                    NomeEmpresa = notification.NomeEmpresa,
                    Porte = notification.Porte.ToString()
                };

                var success = await _clienteProjectionRepository.InsertAsync(clienteReadModel, cancellationToken);
                if (!success)
                    throw new Exception("Erro ao inserir cliente no MongoDB");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao processar ClienteCriadoEvent");
            }
        }
    }
}

