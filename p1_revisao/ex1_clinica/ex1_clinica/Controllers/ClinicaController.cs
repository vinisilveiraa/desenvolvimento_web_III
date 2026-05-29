using ex1_clinica.Data;
using ex1_clinica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver; // <---- IMPORTANTE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;


// LEMBRAR: trocar int Id para string. mongo nao usa id.
// se tiver dando erro, checa se no model ta como int ou string

namespace ex1_clinica.Controllers
{
    public class ClinicaController : Controller
    {
        // mudar para pegar do contextmongodb
        private readonly ContextMongoDb _context;

        public ClinicaController(ContextMongoDb context)
        {
            _context = context;
        }

        // GET: Clinica
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clinica.Find(_ => true).ToListAsync());
        }

        // GET: Clinica/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinica = await _context.Clinica.Find(m => m.Id == id)
                .FirstOrDefaultAsync();

            if (clinica == null)
            {
                return NotFound();
            }

            return View(clinica);
        }

        // GET: Clinica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clinica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Alarme")] Clinica clinica)
        {
            if (ModelState.IsValid)
            {

                await _context.Clinica.InsertOneAsync(clinica);
                return RedirectToAction(nameof(Index));
            }

            return View(clinica);
        }

        // GET: Clinica/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinica = await _context.Clinica.Find(m => m.Id == id).FirstOrDefaultAsync();

            if (clinica == null)
            {
                return NotFound();
            }
            return View(clinica);
        }

        // POST: Clinica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nome,Alarme")] Clinica clinica)
        {
            if (id != clinica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Clinica.ReplaceOneAsync(c => c.Id == id, clinica);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ClinicaExists(clinica.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(clinica);
        }

        // GET: Clinica/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinica = await _context.Clinica.Find(m => m.Id == id).FirstOrDefaultAsync();

            if (clinica == null)
            {
                return NotFound();
            }

            return View(clinica);
        }

        // POST: Clinica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var result = await _context.Clinica.DeleteOneAsync(m => m.Id == id);

            if (result != null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        // definir aqui como async, task<bool>
        private async Task<bool> ClinicaExists(string id)
        {
            return await _context.Clinica.Find(e => e.Id == id).AnyAsync();
        }

        public async Task<IActionResult> TurnAlarme(string id)
        {
            // pega a clinica pelo id
            var clinica = await _context.Clinica.Find(m => m.Id == id)
                .FirstOrDefaultAsync();

            // checa se existe
            if (clinica == null)
            {
                return NotFound();
            }

            // inverte aqui 
            clinica.Alarme = !clinica.Alarme;

            // atualiza no banco
            await _context.Clinica.ReplaceOneAsync(c => c.Id == id, clinica);

            return RedirectToAction(nameof(Index));
        }
    }
}
