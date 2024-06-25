using GerenciadorClientes.Application.Queries;
using GerenciadorClientes.Domain.Dtos;
using GerenciadorClientes.Domain.IRepositories;
using NSubstitute;

namespace GerenciadorClientes.Tests.Application.Queries
{
    public class ObterTodosClientesQueryHandlerTests
    {
        private readonly IClienteProjectionRepository _clienteRepository;
        private readonly ObterTodosClientesQueryHandler _handler;

        public ObterTodosClientesQueryHandlerTests()
        {
            _clienteRepository = Substitute.For<IClienteProjectionRepository>();
            _handler = new ObterTodosClientesQueryHandler(_clienteRepository);
        }

        [Fact]
        public async Task Handle_ShouldReturnAllClientes()
        {
            // Arrange
            var clientes = new List<ClienteModel>
            {
                new ClienteModel { Id = 1, NomeEmpresa = "Empresa A", Porte = "Pequena" },
                new ClienteModel { Id = 2, NomeEmpresa = "Empresa B", Porte = "Media" }
            };
            var query = new ObterTodosClientesQuery();
            _clienteRepository.GetAllAsync().Returns(clientes);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(clientes, result);
        }
    }
}
