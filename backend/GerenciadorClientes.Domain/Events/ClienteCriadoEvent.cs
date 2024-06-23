using GerenciadorClientes.Domain.Enums;
using MediatR;

namespace GerenciadorClientes.Domain.Events
{
    public class ClienteCriadoEvent : INotification
    {
        public int Id { get; set; }
        public string NomeEmpresa { get; set; }
        public PorteEmpresa Porte { get; set; }

        public ClienteCriadoEvent(int id, string nomeEmpresa, PorteEmpresa porte)
        {
            Id = id;
            NomeEmpresa = nomeEmpresa;
            Porte = porte;
        }
    }
}
