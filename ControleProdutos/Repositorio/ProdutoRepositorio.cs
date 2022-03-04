using ControleProdutos.Data;
using ControleProdutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleProdutos.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ProdutoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ProdutoModel ListarPorId(long id)
        {
            return _bancoContext.Produtos.FirstOrDefault(x => x.Id == id);
        }

        public List<ProdutoModel> BuscarTodos()
        {
            return _bancoContext.Produtos.ToList();
        }

        public ProdutoModel Adicionar(ProdutoModel produto)
        {
            _bancoContext.Produtos.Add(produto);
            _bancoContext.SaveChanges();

            return produto;
        } 
        
        public ProdutoModel Atualizar(ProdutoModel produto)
        {
            ProdutoModel produtoDB = ListarPorId(produto.Id);

            if (produtoDB == null) throw new System.Exception("Houve um erro na atualização do produto");

            produtoDB.Descricao = produto.Descricao;
            produtoDB.CodigoDeBarras = produto.CodigoDeBarras;
            produtoDB.DataDeValidade = produto.DataDeValidade;
            produtoDB.DataDeRegistro = produto.DataDeRegistro;
            produtoDB.NomeDaFoto = produto.NomeDaFoto;
            produtoDB.Foto = produto.Foto;
            produtoDB.Ativo = produto.Ativo;

            _bancoContext.Produtos.Update(produtoDB);
            _bancoContext.SaveChanges();

            return produtoDB;
        }

        public bool Apagar(int id)
        {
            ProdutoModel produtoDB = ListarPorId(id);

            if (produtoDB == null) throw new System.Exception("Houve um erro na exclusão do produto");

            _bancoContext.Produtos.Remove(produtoDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
