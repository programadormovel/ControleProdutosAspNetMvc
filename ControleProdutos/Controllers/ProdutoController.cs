using ControleProdutos.Models;
using ControleProdutos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleProdutos.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IActionResult Index()
        {
            List<ProdutoModel> produtos = _produtoRepositorio.BuscarTodos();
            return View(produtos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ProdutoModel produto = _produtoRepositorio.ListarPorId(id);
            return View(produto);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ProdutoModel produto = _produtoRepositorio.ListarPorId(id);
            return View(produto);
        }

        public IActionResult Apagar(int id)
        {
            _produtoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(ProdutoModel produto)
        {
            _produtoRepositorio.Adicionar(produto);
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public IActionResult Alterar(ProdutoModel produto)
        {
            _produtoRepositorio.Atualizar(produto);
            return RedirectToAction("Index");
        }
    }
}
