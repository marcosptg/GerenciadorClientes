using GerenciadorClientes.Application.EventHandlers;
using GerenciadorClientes.Domain.Dtos;
using GerenciadorClientes.Domain.Enums;
using GerenciadorClientes.Domain.Events;
using GerenciadorClientes.Domain.IRepositories;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace GerenciadorClientes.Tests.Application.EventHandlers
{
    public class ClienteAtualizadoEventHandlerTests
    {
        private readonly IClienteProjectionRepository _clienteProjectionRepository;
        private readonly ILogger<ClienteAtualizadoEventHandler> _logger;
        private readonly ClienteAtualizadoEventHandler _handler;

        public ClienteAtualizadoEventHandlerTests()
        {
            _clienteProjectionRepository = Substitute.For<IClienteProjectionRepository>();
            _logger = Substitute.For<ILogger<ClienteAtualizadoEventHandler>>();
            _handler = new ClienteAtualizadoEventHandler(_logger, _clienteProjectionRepository);
        }

        [Fact]
        public async Task Handle_ShouldUpdateClienteReadModel()
        {
            // Arrange
            var clienteAtualizadoEvent = new ClienteAtualizadoEvent(1, "Empresa B", PorteEmpresa.Media);
            _clienteProjectionRepository.UpdateAsync(Arg.Any<ClienteModel>(), CancellationToken.None).Returns(true);

            // Act
            await _handler.Handle(clienteAtualizadoEvent, CancellationToken.None);

            // Assert
            await _clienteProjectionRepository.Received(1).UpdateAsync(Arg.Any<ClienteModel>(), CancellationToken.None);
        }

        [Fact]
        public async Task Handle_ShouldLogErrorWhenUpdateFails()
        {
            // Arrange
            var clienteAtualizadoEvent = new ClienteAtualizadoEvent(1, "Empresa B", PorteEmpresa.Media);
            _clienteProjectionRepository.UpdateAsync(Arg.Any<ClienteModel>(), CancellationToken.None).Returns(false);

            // Act
            await _handler.Handle(clienteAtualizadoEvent, CancellationToken.None);

            // Assert
            await _clienteProjectionRepository.Received(1).UpdateAsync(Arg.Any<ClienteModel>(), CancellationToken.None);
            _logger.Received(1).LogError(Arg.Any<Exception>(), "Erro ao processar ClienteAtualizadoEvent");
        }
    }
}
