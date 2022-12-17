using Mercearia_Produtos_API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercearia_Produtos_API.Repository
{
    public class ProdutoRepository
    {
        private static List<Produto> ListaProdutos;
        private static int Id;
        public ProdutoRepository()
        {
            if (ListaProdutos == null)
            {
                Id = 0;
                ListaProdutos = new List<Produto>();
            }
        }

        public List<Produto> GetAll()
        {
            return ListaProdutos;
        }

        public Produto GetById(int id)
        {
            return ListaProdutos.FirstOrDefault(L => L.ID == id);
        }

        public List<Produto> Get(Func<Produto, bool> filter)
        {
            return ListaProdutos.Where(filter).ToList();
        }

        public int AddProduto(Produto produto)
        {
            Id++;
            produto.ID = Id;
            ListaProdutos.Add(produto);
            return Id;
        }

        public bool UpdateProduto(Produto produto)
        {
            if (GetById(produto.ID) == null)
            {
                return false;
            }

            foreach (Produto produtoUpdate in ListaProdutos.Where(L => L.ID == produto.ID))
            {
                produtoUpdate.nome = produto.nome;
                produtoUpdate.marca = produto.marca;
                produtoUpdate.dataVencimento = produto.dataVencimento;
                produtoUpdate.preco = produto.preco;
                produtoUpdate.unid = produto.unid;
                produtoUpdate.quantEstoque = produto.quantEstoque;

            }

            return true;
        }

        public long DeleteProdutoById(int id)
        {
            return ListaProdutos.RemoveAll(L => L.ID == id);
        }
    }
}
