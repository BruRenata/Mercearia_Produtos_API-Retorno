using Mercearia_Produtos_API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercearia_Produtos_API.Controllers
{
    public class ClienteController
    {
        private ClienteRepository clienteRepository = new ClienteRepository();

        [HttpGet]
        [Route("[controller]")]
        public IEnumerable<Cliente> GetAll()
        {
            return clienteRepository.GetAll();
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public Cliente Get(int id)
        {
            return clienteRepository.GetById(id);
        }

        [HttpPost]
        [Route("[controller]")]
        public void Create([FromBody] Cliente cliente)
        {
            clienteRepository.AddCliente(cliente);
        }

        [HttpPut]
        [Route("[controller]")]
        public void Update([FromBody] Cliente cliente)
        {
            clienteRepository.UpdateCliente(cliente);   
        }

        [HttpDelete]
        [Route("[controller]/{id}")]
        public void Delete(int id)
        {
            clienteRepository.DeleteClienteById(id);
        }
    }

    public class Cliente
    {
        public int ID { get; set; }
        public string nome { get; set; }
        public DateTime dataNascimento { get; set; }
        public Endereco enderecoCliente { get; set; }

        public struct Endereco
        {
            public string rua { get; set; }
            public int numero { get; set; }
            public string bairro { get; set; }
            public string cidade { get; set; }
            public string UF { get; set; }
        }
    }

}
