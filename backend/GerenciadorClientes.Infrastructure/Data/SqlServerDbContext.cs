using GerenciadorClientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorClientes.Infrastructure.Data
{
    public class SqlServerDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options)
            : base(options) { }
    }
}
