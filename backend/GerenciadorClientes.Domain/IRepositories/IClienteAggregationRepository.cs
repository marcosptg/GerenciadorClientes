using GerenciadorClientes.Domain.Entities;

namespace GerenciadorClientes.Domain.IRepositories
{
    public interface IClienteAggregationRepository
    {
        Task<Cliente?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task AddAsync(Cliente cliente, CancellationToken cancellationToken);
        Task UpdateAsync(Cliente cliente, CancellationToken cancellationToken);
        Task RemoveAsync(Cliente cliente, CancellationToken cancellationToken);
    }

}
