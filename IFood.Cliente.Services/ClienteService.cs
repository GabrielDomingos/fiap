using IFood.Cliente.Domain.Cliente;
using IFood.Cliente.Domain.Interface;
using IFood.Cliente.Repository;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFood.Cliente.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService()
        {
            _clienteRepository = new ClienteRepository();
        }
        public async Task<ClienteModel> add(ClienteModel cliente) => await _clienteRepository.add(cliente);

        public async Task<ClienteModel> get(string objectId) => await _clienteRepository.get(objectId);

        public IEnumerable<ClienteModel> getAll() => _clienteRepository.getAll();

        public async Task<ClienteModel> update(ClienteModel cliente) => await _clienteRepository.update(cliente);
    }
}
