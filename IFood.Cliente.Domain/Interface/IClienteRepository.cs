using IFood.Cliente.Domain.Cliente;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace IFood.Cliente.Domain.Interface
{
    public interface IClienteRepository
    {
        Task<ClienteModel> add(ClienteModel cliente);
        Task<ClienteModel> update(ClienteModel cliente);
        Task<ClienteModel> get(string objectId);
        IEnumerable<ClienteModel> getAll();

    }
}
