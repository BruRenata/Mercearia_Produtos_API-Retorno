using Mercearia_Produtos_API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Mercearia_Produtos_API.Repository
{
    public class ClienteRepository
    {
        private static List<Cliente> ListaClientes;
        private static int Id;
        public ClienteRepository()
        {
            if (ListaClientes == null)
            {
                Id = 0;
                ListaClientes = new List<Cliente>();
            }
        }

        public List<Cliente> GetAll()
        {
            return ListaClientes;
        }

        public Cliente GetById(int id)
        {
            return ListaClientes.FirstOrDefault(L => L.ID == id);
        }

        public List<Cliente> Get(Func<Cliente, bool> filter)
        {
            return ListaClientes.Where(filter).ToList();
        }

        public int AddCliente(Cliente cliente)
        {
            Id++;
            cliente.ID = Id;
            ListaClientes.Add(cliente);
            return Id;
        }

        public bool UpdateCliente(Cliente cliente)
        {
            if (GetById(cliente.ID) == null)
            {
                return false;
            }

            foreach(Cliente clientUpdate in ListaClientes.Where(L => L.ID == cliente.ID))
            {
                clientUpdate.nome = cliente.nome;
                clientUpdate.dataNascimento = cliente.dataNascimento;
                clientUpdate.enderecoCliente = cliente.enderecoCliente;
            }

            return true;
        }

        public long DeleteClienteById(int id)
        {
            return ListaClientes.RemoveAll(L => L.ID == id);
        }
    }
}
