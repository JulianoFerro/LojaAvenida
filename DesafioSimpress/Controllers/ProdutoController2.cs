using DesafioSimpress.Context;
using DesafioSimpress.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Dynamic;

namespace DesafioSimpress.Controllers
{
    public class ProdutoController2 : Controller
    {
        private readonly ILogger<ProdutoController2> _logger;
        private readonly LojaContext _conexao;

        public ProdutoController2(ILogger<ProdutoController2> logger, LojaContext conexao)
        {
            _logger = logger;
            _conexao = conexao;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Message = "Welcome to my demo!";
            ViewBag.Categorias = await ObterCategorias();
            ViewBag.Produtos = await ObterProdutos();
            return View();

        }

        private async Task<List<Categoria>> ObterCategorias()
        {
            return await _conexao.Categorias.ToListAsync();
        }
        private async Task<List<Produto>> ObterProdutos()
        {
            return await _conexao.Produtos.Include(x => x.Categoria).ToListAsync();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create( Produto model)
        {
            if (ModelState.IsValid)
            {
                var categoria = await _conexao.Categorias.FindAsync(model.CategoriaId);
                model.Categoria = categoria;

                _conexao.Produtos.Add(model);
                await _conexao.SaveChangesAsync();
            }
            

            return RedirectToAction("Index");
        }


        
        public IActionResult Edit(int id)
        {
            if (id == 0) return View("Error");

            Produto model = _conexao.Produtos.FirstOrDefault(x => x.Id == id);

            return Json(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return NotFound();

            Produto model = _conexao.Produtos.FirstOrDefault(x => x.Id == id);

            if (model == null) return NotFound();

            _conexao.Produtos.Remove(model);
            _conexao.SaveChanges();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Erro()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}