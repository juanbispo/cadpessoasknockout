using CadPessoas.Data;
using CadPessoas.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadPessoas.Controllers
{
    public class PessoaController : Controller
    {
        private readonly AppDbContext _context;

        public PessoaController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPessoas()
        {
            try { 
                var lista = _context.Pessoas;

                return Json(lista);
            }
            catch(Exception e)
            {
                return Json(e.Message);
            }
        }
    }
}
