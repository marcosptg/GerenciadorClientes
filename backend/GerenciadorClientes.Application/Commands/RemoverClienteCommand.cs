using MediatR;

namespace GerenciadorClientes.Application.Commands
{
    public class RemoverClienteCommand : IRequest<bool>
    {
        public int Id { get; init; }

        public RemoverClienteCommand(int id)
        {
            Id = id;
        }
    }

}
