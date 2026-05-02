using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ProjetoClinica.Data;
using ProjetoClinica.Models;
namespace ProjetoClinica.Controllers
{
    
    public class ClinicasController : Controller
    {
        private readonly ContextMongoDb _context;
        public ClinicasController(ContextMongoDb context)
        {
            _context = context;
        }
        public IActionResult Inserir()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Inserir([Bind("Nome,Alarme")] Clinica clinica)
        {
            if (ModelState.IsValid)
            {
                await _context.Clinica.InsertOneAsync(clinica);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AlterarAlarme(string id, bool alarme){
            if(string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var clinica = await _context.Clinica.Find(c => c.Id == id).FirstOrDefaultAsync();

            if (clinica == null)
            {
                return NotFound();
            }

            
            clinica.Alarme = alarme;

            
            await _context.Clinica.ReplaceOneAsync(c => c.Id == id, clinica);

            
            return RedirectToAction("Index", "Home");
            
        }
    }
}
