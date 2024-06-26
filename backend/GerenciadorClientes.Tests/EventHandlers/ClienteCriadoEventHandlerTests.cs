using GerenciadorClientes.Application.EventHandlers;
using GerenciadorClientes.Domain.Dtos;
using GerenciadorClientes.Domain.Enums;
using GerenciadorClientes.Domain.Events;
using GerenciadorClientes.Domain.IRepositories;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace GerenciadorClientes.Tests.Application.EventHandlers
{
    public class ClienteCriadoEventHandlerTests
    {
        private readonly IClienteProjectionRepository _clienteProjectionRepository;
        private readonly ILogger<ClienteCriadoEventHandler> _logger;
        private readonly ClienteCriadoEventHandler _handler;

        public ClienteCriadoEventHandlerTests()
        {
            _clienteProjectionRepository = Substitute.For<IClienteProjectionRepository>();
            _logger = Substitute.For<ILogger<ClienteCriadoEventHandler>>();
            _handler = new ClienteCriadoEventHandler(_logger, _clienteProjectionRepository);
        }

        [Fact]
        public async Task Handle_ShouldInsertClienteClienteModel()
        {
            // Arrange
            var clienteCriadoEvent = new ClienteCriadoEvent(1, "Empresa A", PorteEmpresa.Pequena);
            _clienteProjectionRepository.InsertAsync(Arg.Any<ClienteModel>(), CancellationToken.None).Returns(true);

            // Act
            await _handler.Handle(clienteCriadoEvent, CancellationToken.None);

            // Assert
            await _clienteProjectionRepository.Received(1).InsertAsync(Arg.Any<ClienteModel>(), CancellationToken.None);
        }

        [Fact]
        public async Task Handle_ShouldLogErrorWhenInsertFails()
        {
            // Arrange
            var clienteCriadoEvent = new ClienteCriadoEvent(1, "Empresa A", PorteEmpresa.Pequena);
            _clienteProjectionRepository.InsertAsync(Arg.Any<ClienteModel>(), CancellationToken.None).Returns(false);

            // Act
            await _handler.Handle(clienteCriadoEvent, CancellationToken.None);

            // Assert
            await _clienteProjectionRepository.Received(1).InsertAsync(Arg.Any<ClienteModel>(), CancellationToken.None);
            _logger.Received(1).LogError(Arg.Any<Exception>(), "Erro ao processar ClienteCriadoEvent");
        }
    }
}
