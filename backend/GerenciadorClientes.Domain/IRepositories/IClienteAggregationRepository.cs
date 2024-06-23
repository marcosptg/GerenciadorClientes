using GerenciadorClientes.Domain.Entities;

namespace GerenciadorClientes.Domain.IRepositories
{
    public interface IClienteAggregationRepository
    {
        Task<Cliente?> GetByIdAsync(int id);
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task RemoveAsync(Cliente cliente);
    }

}
