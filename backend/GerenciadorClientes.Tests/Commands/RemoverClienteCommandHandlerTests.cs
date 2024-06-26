using GerenciadorClientes.Application.Commands;
using GerenciadorClientes.Domain.Entities;
using GerenciadorClientes.Domain.Enums;
using GerenciadorClientes.Domain.Events;
using GerenciadorClientes.Domain.IRepositories;
using MediatR;
using NSubstitute;

namespace GerenciadorClientes.Tests.Application.Commands
{
    public class RemoverClienteCommandHandlerTests
    {
        private readonly IClienteAggregationRepository _clienteRepository;
        private readonly IMediator _mediator;
        private readonly RemoverClienteCommandHandler _handler;

        public RemoverClienteCommandHandlerTests()
        {
            _clienteRepository = Substitute.For<IClienteAggregationRepository>();
            _mediator = Substitute.For<IMediator>();
            _handler = new RemoverClienteCommandHandler(_mediator, _clienteRepository);
        }

        [Fact]
        public async Task Handle_ShouldRemoveClienteAndPublishEvent()
        {
            // Arrange
            var cliente = new Cliente(1, "Empresa Z", PorteEmpresa.Pequena);
            var command = new RemoverClienteCommand(cliente.Id);
            _clienteRepository.GetByIdAsync(cliente.Id, CancellationToken.None).Returns(cliente);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            await _clienteRepository.Received(1).RemoveAsync(cliente, CancellationToken.None);
            await _mediator.Received(1).Publish(Arg.Any<ClienteRemovidoEvent>(), CancellationToken.None);
            Assert.True(result);
        }
    }
}
