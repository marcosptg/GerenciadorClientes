using GerenciadorClientes.Domain.Dtos;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace GerenciadorClientes.Infrastructure.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IMongoClient mongoClient, IConfiguration configuration)
        {
            _database = mongoClient.GetDatabase(configuration["ConnectionStrings:MongoDbDatabase"]);
        }

        public IMongoCollection<ClienteModel> Clientes => _database.GetCollection<ClienteModel>("Clientes");
    }

}
