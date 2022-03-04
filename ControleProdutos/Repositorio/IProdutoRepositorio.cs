using ControleProdutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleProdutos.Repositorio
{
    public interface IProdutoRepositorio
    {
        ProdutoModel ListarPorId(long id);
        List<ProdutoModel> BuscarTodos();
        ProdutoModel Adicionar(ProdutoModel produto);
        ProdutoModel Atualizar(ProdutoModel produto);
        bool Apagar(int id);
    }
}
