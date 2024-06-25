using GerenciadorClientes.Application.Commands;
using GerenciadorClientes.Domain.Entities;
using GerenciadorClientes.Domain.Enums;
using GerenciadorClientes.Domain.Events;
using GerenciadorClientes.Domain.IRepositories;
using MediatR;
using NSubstitute;

namespace GerenciadorClientes.Tests.Application.Commands
{
    public class CriarClienteCommandHandlerTests
    {
        private readonly IClienteAggregationRepository _clienteRepository;
        private readonly IMediator _mediator;
        private readonly CriarClienteCommandHandler _handler;

        public CriarClienteCommandHandlerTests()
        {
            _clienteRepository = Substitute.For<IClienteAggregationRepository>();
            _mediator = Substitute.For<IMediator>();
            _handler = new CriarClienteCommandHandler(_clienteRepository, _mediator);
        }

        [Fact]
        public async Task Handle_ShouldAddClienteAndPublishEvent()
        {
            // Arrange
            var command = new CriarClienteCommand("Empresa X", PorteEmpresa.Media);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            await _clienteRepository.Received(1).AddAsync(Arg.Any<Cliente>());
            await _mediator.Received(1).Publish(Arg.Any<ClienteCriadoEvent>(), CancellationToken.None);
        }
    }
}
