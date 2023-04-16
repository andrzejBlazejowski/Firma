using Firma.Data.Data;
using Firma.Data.Data.CMS;
using Firma.PortalWWW.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Firma.PortalWWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FirmaContext _context;

        public HomeController(FirmaContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            ViewBag.ModelStrony = 
                (
                    from Strona in _context.Strona
                    orderby Strona.Pozycja
                    select Strona
                ).ToList();

            ViewBag.ModelAktualnosci =
                (
                    from Aktualnosci in _context.Aktualnosc
                    orderby Aktualnosci.Pozycja
                    select Aktualnosci
                ).ToList();

            if (id == null)
            {
                id = _context.Strona.First().IdStrony;
            }

            var item  = _context.Strona.Find(id);

            return View(item);
        }

    public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Kontakt()
        {
            return View();//widok będzienazywał się tak samo jak funkcja czyli kontakt
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}