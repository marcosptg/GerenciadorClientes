using GerenciadorClientes.Domain.Dtos;
using GerenciadorClientes.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace GerenciadorClientes.Infrastructure.Repositories
{
    public class ClienteProjectionRepository : IClienteProjectionRepository
    {
        private readonly IMongoCollection<ClienteModel> _clientes;

        public ClienteProjectionRepository(IMongoDatabase database)
        {
            _clientes = database.GetCollection<ClienteModel>("clientes");
        }

        public async Task<bool> InsertAsync(ClienteModel cliente, CancellationToken cancellationToken)
        {
            await _clientes.InsertOneAsync(cliente, new InsertOneOptions(), cancellationToken);
            return true;
        }

        public async Task<bool> UpdateAsync(ClienteModel cliente, CancellationToken cancellationToken)
        {
            var result = await _clientes.ReplaceOneAsync(c => c.Id == cliente.Id, cliente, new ReplaceOptions(), cancellationToken);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> RemoveAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _clientes.DeleteOneAsync(c => c.Id == id, cancellationToken);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public Task<List<ClienteModel>> GetAllAsync(CancellationToken cancellationToken) => _clientes.Find(_ => true).ToListAsync(cancellationToken);

        public Task<ClienteModel> GetByIdAsync(int id, CancellationToken cancellationToken) => _clientes.Find(cliente => cliente.Id == id).FirstOrDefaultAsync(cancellationToken);
    }

}
