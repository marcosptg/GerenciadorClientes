using GerenciadorClientes.Domain.Enums;

namespace GerenciadorClientes.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? NomeEmpresa { get; set; }
        public PorteEmpresa Porte { get; set; }
    }

}
