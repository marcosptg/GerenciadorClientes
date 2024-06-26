using GerenciadorClientes.Domain.Entities;
using GerenciadorClientes.Domain.IRepositories;
using GerenciadorClientes.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorClientes.Infrastructure.Repositories
{
    public class ClienteAggregationRepository : IClienteAggregationRepository
    {
        private readonly SqlServerDbContext _context;
        private readonly DbSet<Cliente> _clientes;

        public ClienteAggregationRepository(SqlServerDbContext context)
        {
            _context = context;
            _clientes = context.Clientes;
        }

        public async Task<Cliente?> GetByIdAsync(int id, CancellationToken cancellationToken) 
            => await _context.Clientes.FindAsync(id, cancellationToken).AsTask();

        public async Task AddAsync(Cliente cliente, CancellationToken cancellationToken)
        {
            await _clientes.AddAsync(cliente, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Cliente cliente, CancellationToken cancellationToken)
        {
            _clientes.Update(cliente);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveAsync(Cliente cliente, CancellationToken cancellationToken)
        {
            _clientes.Remove(cliente);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
