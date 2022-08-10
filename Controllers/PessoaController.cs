using CadPessoas.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadPessoas.Controllers
{
    public class PessoaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPessoas()
        {
            List<Pessoa> lista = new List<Pessoa>();


            lista.Add(new Pessoa
            {
                Id = 1,
                Nome = "Juan"
            });

            return Json(lista);
        }
    }
}
