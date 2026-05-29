using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ex1.Data;
using ex1.Models;
using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Numerics;
using MongoDB.Bson;
using System.Collections.Generic;

namespace ex1.Controllers
{
    public class TrabalhosController : Controller
    {
        private readonly ContextMongoDb _context;

        public TrabalhosController(ContextMongoDb context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Trabalho.Find(_ => true)
                .ToListAsync());
        }

        public IActionResult Insert()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Insert([Bind("Titulo, Resumo, AreaTematica, AutorNome, AutorEmail")] Trabalho trabalho)
        {
            if (ModelState.IsValid)
            {
                trabalho.DataSubmissao = DateTime.Now;
                await _context.Trabalho.InsertOneAsync(trabalho);
                return RedirectToAction("Index", "Trabalhos");
            }

            return View();
        }
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabalho = await _context.Trabalho.Find(m => m.Id == id).FirstOrDefaultAsync();
            var result = await _context.Trabalho.DeleteOneAsync(m => m.Id == id);


            if (trabalho == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Review()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Review([Bind("Nota,Comentario")] Avaliacao avaliacao)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            avaliacao.DataAvaliacao = DateTime.Now;

            await _context.Avaliacao.InsertOneAsync(avaliacao);


            return RedirectToAction(nameof(Index));
        }
    }
}
