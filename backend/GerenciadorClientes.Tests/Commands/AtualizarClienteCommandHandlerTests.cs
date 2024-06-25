using GerenciadorClientes.Application.Commands;
using GerenciadorClientes.Domain.Entities;
using GerenciadorClientes.Domain.Enums;
using GerenciadorClientes.Domain.Events;
using GerenciadorClientes.Domain.IRepositories;
using MediatR;
using NSubstitute;

namespace GerenciadorClientes.Tests.Application.Commands
{
    public class AtualizarClienteCommandHandlerTests
    {
        private readonly IClienteAggregationRepository _clienteRepository;
        private readonly IMediator _mediator;
        private readonly AtualizarClienteCommandHandler _handler;

        public AtualizarClienteCommandHandlerTests()
        {
            _clienteRepository = Substitute.For<IClienteAggregationRepository>();
            _mediator = Substitute.For<IMediator>();
            _handler = new AtualizarClienteCommandHandler(_mediator, _clienteRepository);
        }

        [Fact]
        public async Task Handle_ShouldUpdateClienteAndPublishEvent()
        {
            // Arrange
            var cliente = new Cliente { Id = 1, NomeEmpresa = "Empresa Y", Porte = PorteEmpresa.Grande };
            var command = new AtualizarClienteCommand(cliente.Id, "Empresa Y Atualizada", PorteEmpresa.Media);
            _clienteRepository.GetByIdAsync(cliente.Id).Returns(cliente);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            await _clienteRepository.Received(1).UpdateAsync(Arg.Any<Cliente>());
            await _mediator.Received(1).Publish(Arg.Any<ClienteAtualizadoEvent>(), CancellationToken.None);
            Assert.True(result);
        }
    }
}
