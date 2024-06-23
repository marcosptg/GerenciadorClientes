using GerenciadorClientes.Domain.Entities;
using GerenciadorClientes.Domain.IRepositories;
using GerenciadorClientes.Infrastructure.Data;

namespace GerenciadorClientes.Infrastructure.Repositories
{
    public class ClienteAggregationRepository : IClienteAggregationRepository
    {
        private readonly SqlServerDbContext _context;

        public ClienteAggregationRepository(SqlServerDbContext context) => _context = context;

        public Task<Cliente?> GetByIdAsync(int id) => _context.Clientes.FindAsync(id).AsTask();

        public async Task AddAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }

}
