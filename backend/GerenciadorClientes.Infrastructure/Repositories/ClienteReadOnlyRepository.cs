using GerenciadorClientes.Domain.Dtos;
using GerenciadorClientes.Domain.IRepositories;
using GerenciadorClientes.Infrastructure.Data;
using MongoDB.Driver;

namespace GerenciadorClientes.Infrastructure.Repositories
{
    public class ClienteReadOnlyRepository : IClienteReadOnlyRepository
    {
        private readonly MongoDbContext _context;

        public ClienteReadOnlyRepository(MongoDbContext context) => _context = context;

        public Task<List<ClienteModel>> GetAllAsync() => _context.Clientes.Find(_ => true).ToListAsync();

        public Task<ClienteModel> GetByIdAsync(int id) => _context.Clientes.Find(cliente => cliente.Id == id).FirstOrDefaultAsync();
    }

}
