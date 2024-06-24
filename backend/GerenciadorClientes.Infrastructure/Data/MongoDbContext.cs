using GerenciadorClientes.Domain.Dtos;
using MongoDB.Driver;

namespace GerenciadorClientes.Infrastructure.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IMongoDatabase database)
        {
            _database = database;
        }

        public IMongoCollection<ClienteModel> Clientes => _database.GetCollection<ClienteModel>("Clientes");
    }

}
