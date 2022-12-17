using Mercearia_Produtos_API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Mercearia_Produtos_API.Controllers
{
    public class ProdutoController : ControllerBase
    {

        private ProdutoRepository produtoRepository = new ProdutoRepository();

        [HttpGet]
        [Route("[controller]")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(produtoRepository.GetAll());
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
                Produto produto = produtoRepository.GetById(id);
                if (produto == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(produto);
                }
            }
            catch(Exception e)
            {
                return BadRequest(new Resposta(400, e.Message));
            }
        }

        [HttpPost]
        [Route("[controller]")]
        public IActionResult Create([FromBody] Produto produto)
        {
            try
            {
                int id = produtoRepository.AddProduto(produto);
                return Ok(new Resposta(200, $"Produto Cadastrado com id: {id}"));
            }
            catch(Exception e)
            {
                return BadRequest(new Resposta(400, e.Message));
            }
        }

        [HttpPut]
        [Route("[controller]")]
        public IActionResult Update([FromBody] Produto produto)
        {
            try
            {
                if (produtoRepository.UpdateProduto(produto))
                {
                    return Ok(new Resposta(200, "Produto Atualizado."));
                }
                else
                {
                    return NoContent();
                }
            }
            catch(Exception e)
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
                long qtdDeletados = produtoRepository.DeleteProdutoById(id);
                return Ok(new Resposta(200, $"Produtos Deletados: {qtdDeletados}"));
            }
            catch(Exception e)
            {
                return BadRequest(new Resposta(400, e.Message));
            }
        }
    }

    public class Produto
    {
        public int ID { get; set; }
        public string nome { get; set; }
        public string marca { get; set; }
        public DateTime dataVencimento { get; set; }
        public double preco { get; set; }
        public string unid { get; set; }
        public int quantEstoque { get; set; }
    }
}
