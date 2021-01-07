using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DtiBackend.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DtiBackend.Repositories
{
    public class ClienteCollection : IClienteCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();

        private IMongoCollection<Cliente> Collection;

        public ClienteCollection()
        {
            Collection = _repository.db.GetCollection<Cliente>("Clientes");
        }

        public async Task DeleteCliente(string id)
        {
            var filter = Builders<Cliente>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Cliente>> GetAllClientes()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Cliente> GetClientById(string id)
        {
            return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task InsertCliente(Cliente cliente)
        {
            await Collection.InsertOneAsync(cliente);
        }

        public async Task UpdateCliente(Cliente cliente)
        {
            var filter = Builders<Cliente>
                .Filter
                .Eq(s => s.Id, cliente.Id);
            await Collection.ReplaceOneAsync(filter, cliente);
        }
    }
}
