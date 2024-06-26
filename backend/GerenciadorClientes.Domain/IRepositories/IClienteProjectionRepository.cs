
using GerenciadorClientes.Domain.Dtos;

namespace GerenciadorClientes.Domain.IRepositories
{
    public interface IClienteProjectionRepository
    {
        Task<bool> InsertAsync(ClienteModel cliente, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(ClienteModel cliente, CancellationToken cancellationToken);
        Task<bool> RemoveAsync(int id, CancellationToken cancellationToken);
        Task<List<ClienteModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<ClienteModel> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}
