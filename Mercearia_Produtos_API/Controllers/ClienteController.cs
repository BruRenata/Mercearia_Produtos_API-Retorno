using Mercearia_Produtos_API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Mercearia_Produtos_API.Controllers
{
    public class ClienteController : ControllerBase
    {
        private ClienteRepository clienteRepository = new ClienteRepository();

        [HttpGet]
        [Route("[controller]")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(clienteRepository.GetAll());
            }
            catch(Exception e)
            {
                return BadRequest(new Resposta(400, e.Message));
            }
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Cliente cliente = clienteRepository.GetById(id);
                if (cliente == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(cliente);
                }
            }
            catch (Exception e)
            {
                return BadRequest(new Resposta(400, e.Message));
            }

        }

        [HttpPost]
        [Route("[controller]")]
        public IActionResult Create([FromBody] Cliente cliente)
        {
            try
            {
                int id = clienteRepository.AddCliente(cliente);
                return Ok(new Resposta(200, $"Cliente Cadastrado com id: {id}"));
            }
            catch (Exception e)
            {
                return BadRequest(new Resposta(400, e.Message));
            }
        }

        [HttpPut]
        [Route("[controller]")]
        public IActionResult Update([FromBody] Cliente cliente)
        {
            try
            {
                if (clienteRepository.UpdateCliente(cliente))
                {
                    return Ok(new Resposta(200, "Produto Atualizado."));
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception e)
            {
                return BadRequest(new Resposta(400, e.Message));
            }
        }

        [HttpDelete]
        [Route("[controller]/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                long qtdDeletados = clienteRepository.DeleteClienteById(id);
                return Ok(new Resposta(200, $"Produtos Deletados: {qtdDeletados}"));
            }
            catch (Exception e)
            {
                return BadRequest(new Resposta(400, e.Message));
            }
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
