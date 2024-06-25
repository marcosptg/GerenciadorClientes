using GerenciadorClientes.Application.EventHandlers;
using GerenciadorClientes.Domain.Events;
using GerenciadorClientes.Domain.IRepositories;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace GerenciadorClientes.Tests.Application.EventHandlers
{
    public class ClienteRemovidoEventHandlerTests
    {
        private readonly IClienteProjectionRepository _clienteProjectionRepository;
        private readonly ILogger<ClienteRemovidoEventHandler> _logger;
        private readonly ClienteRemovidoEventHandler _handler;

        public ClienteRemovidoEventHandlerTests()
        {
            _clienteProjectionRepository = Substitute.For<IClienteProjectionRepository>();
            _logger = Substitute.For<ILogger<ClienteRemovidoEventHandler>>();
            _handler = new ClienteRemovidoEventHandler(_logger, _clienteProjectionRepository);
        }

        [Fact]
        public async Task Handle_ShouldRemoveClienteReadModel()
        {
            // Arrange
            var clienteRemovidoEvent = new ClienteRemovidoEvent(1);
            _clienteProjectionRepository.RemoveAsync(1).Returns(true);

            // Act
            await _handler.Handle(clienteRemovidoEvent, CancellationToken.None);

            // Assert
            await _clienteProjectionRepository.Received(1).RemoveAsync(1);
        }

        [Fact]
        public async Task Handle_ShouldLogErrorWhenRemoveFails()
        {
            // Arrange
            var clienteRemovidoEvent = new ClienteRemovidoEvent(1);
            _clienteProjectionRepository.RemoveAsync(1).Returns(false);

            // Act
            await _handler.Handle(clienteRemovidoEvent, CancellationToken.None);

            // Assert
            await _clienteProjectionRepository.Received(1).RemoveAsync(1);
            _logger.Received(1).LogError(Arg.Any<Exception>(), "Erro ao processar ClienteRemovidoEvent");
        }
    }
}
