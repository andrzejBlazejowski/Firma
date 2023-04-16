using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc;

namespace Firma.PortalWWW.Controllers
{
    public class aktualnosciController : Controller
    {
        private readonly FirmaContext _context;
        
        public aktualnosciController(FirmaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int id)
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

            var item = await _context.Strona.FindAsync(id);

            return View(item);
        }
    }
}
