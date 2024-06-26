using GerenciadorClientes.Application.Queries;
using GerenciadorClientes.Domain.Dtos;
using GerenciadorClientes.Domain.Enums;
using GerenciadorClientes.Domain.IRepositories;
using NSubstitute;

namespace GerenciadorClientes.Tests.Application.Queries
{
    public class ObterClientePorIdQueryHandlerTests
    {
        private readonly IClienteProjectionRepository _clienteRepository;
        private readonly ObterClientePorIdQueryHandler _handler;

        public ObterClientePorIdQueryHandlerTests()
        {
            _clienteRepository = Substitute.For<IClienteProjectionRepository>();
            _handler = new ObterClientePorIdQueryHandler(_clienteRepository);
        }

        [Fact]
        public async Task Handle_ShouldReturnCliente()
        {
            // Arrange
            var cliente = new ClienteModel { Id = 1, NomeEmpresa = "Empresa A", Porte = "Pequena" };
            var query = new ObterClientePorIdQuery(cliente.Id);
            _clienteRepository.GetByIdAsync(cliente.Id, CancellationToken.None).Returns(cliente);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(cliente, result);
        }
    }
}
