using IFood.Cliente.Domain.Cliente;
using IFood.Cliente.Domain.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IFood.Cliente.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly MongoContext _mongoContext;
        public ClienteRepository()
        {
            _mongoContext = new MongoContext();
        }
        public async Task<ClienteModel> add(ClienteModel cliente)
        {
            await _mongoContext
                              .Cliente
                              .InsertOneAsync(cliente);
            return cliente;
        }

        public async Task<ClienteModel> get(string objectId)
        {
            return _mongoContext
                            .Cliente
                            .Find(x => x.id.Equals(objectId))
                            .FirstOrDefault();
        }

        public IEnumerable<ClienteModel> getAll()
        {
            return _mongoContext
                    .Cliente
                    .Find(x => true)
                    .ToList();
        }

        public async Task<ClienteModel> update(ClienteModel cliente)
        {
            await _mongoContext
                    .Cliente
                    .ReplaceOneAsync(x => x.id.Equals(cliente.id), cliente);

            return cliente;
        }
    }
}
