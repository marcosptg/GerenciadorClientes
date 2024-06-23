using GerenciadorClientes.Domain.Dtos;

namespace GerenciadorClientes.Domain.IRepositories
{
    public interface IClienteReadOnlyRepository
    {
        Task<List<ClienteModel>> GetAllAsync();
        Task<ClienteModel> GetByIdAsync(int id);
    }

}
