using System.Collections.Generic;
using System.Threading.Tasks;
using DtiBackend.Models;

namespace DtiBackend.Repositories
{
    public interface IClienteCollection
    {
        Task InsertCliente(Cliente cliente);
        Task UpdateCliente(Cliente cliente);
        Task DeleteCliente(string id);
        Task<List<Cliente>> GetAllClientes();
        Task<Cliente> GetClientById(string id);
    }
}

