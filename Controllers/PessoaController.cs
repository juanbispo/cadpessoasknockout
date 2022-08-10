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
        [HttpGet]
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

        [HttpPost]
        public IActionResult CreatePessoa(Pessoa pessoa)
        {
            if (pessoa.Nome is null)
            {
                return BadRequest();
            }
            _context.Add(pessoa);
            _context.SaveChanges();
            return Ok(pessoa);
        }
    }
}
