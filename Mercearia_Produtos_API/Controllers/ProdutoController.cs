using Mercearia_Produtos_API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercearia_Produtos_API.Controllers
{
    public class ProdutoController
    {

        private ProdutoRepository produtoRepository = new ProdutoRepository();

        [HttpGet]
        [Route("[controller]")]
        public IEnumerable<Produto> GetAll()
        {
            return produtoRepository.GetAll();
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public Produto Get(int id)
        {
            return produtoRepository.GetById(id);
        }

        [HttpPost]
        [Route("[controller]")]
        public void Create([FromBody] Produto produto)
        {
            produtoRepository.AddProduto(produto);
        }

        [HttpPut]
        [Route("[controller]")]
        public void Update([FromBody] Produto produto)
        {
            produtoRepository.UpdateProduto(produto);
        }

        [HttpDelete]
        [Route("[controller]/{id}")]
        public void Delete(int id)
        {
            produtoRepository.DeleteProdutoById(id);
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
