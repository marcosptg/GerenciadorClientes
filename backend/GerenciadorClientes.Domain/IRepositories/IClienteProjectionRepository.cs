
using GerenciadorClientes.Domain.Dtos;

namespace GerenciadorClientes.Domain.IRepositories
{
    public interface IClienteProjectionRepository
    {
        Task<bool> InsertAsync(ClienteModel cliente);
        Task<bool> UpdateAsync(ClienteModel cliente);
        Task<bool> RemoveAsync(int id);
        Task<List<ClienteModel>> GetAllAsync();
        Task<ClienteModel> GetByIdAsync(int id);
    }
}
