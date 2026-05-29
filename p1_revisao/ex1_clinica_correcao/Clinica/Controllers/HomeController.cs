using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjetoClinica.Models;
using ProjetoClinica.Data;
using MongoDB.Driver;

namespace ProjetoClinica.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ContextMongoDb _context;
    public HomeController(ILogger<HomeController> logger, ContextMongoDb context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Clinica.Find(_ => true).ToListAsync());
    }
       

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
