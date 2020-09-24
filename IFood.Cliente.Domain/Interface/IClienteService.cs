using IFood.Cliente.Domain.Cliente;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IFood.Cliente.Domain.Interface
{
    public interface IClienteService
    {
        Task<ClienteModel> add(ClienteModel cliente);
        Task<ClienteModel> update(ClienteModel cliente);
        Task<ClienteModel> get(string objectId);
        IEnumerable<ClienteModel> getAll();
    }
}
