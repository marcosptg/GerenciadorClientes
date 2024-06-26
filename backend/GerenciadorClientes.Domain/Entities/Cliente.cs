using GerenciadorClientes.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorClientes.Domain.Entities
{
    public class Cliente
    {
        protected Cliente()
        {
        }

        public Cliente(string nomeEmpresa, PorteEmpresa porteEmpresa)
        {
            AddNomeEmpresa(nomeEmpresa);
            AddPorteEmpresa(porteEmpresa);
        }

        public Cliente(int id, string nomeEmpresa, PorteEmpresa porteEmpresa)
        {
            Id = id;
            AddNomeEmpresa(nomeEmpresa);
            AddPorteEmpresa(porteEmpresa);
        }

        public void AddNomeEmpresa(string nomeEmpresa)
        {
            NomeEmpresa = nomeEmpresa;
        }

        public void AddPorteEmpresa(PorteEmpresa porte)
        {
            Porte = porte;
        }

        public int Id { get; private set; }

        [MaxLength(250)]
        public string NomeEmpresa { get; private set; } = string.Empty;
        public PorteEmpresa Porte { get; private set; }
    }

}
