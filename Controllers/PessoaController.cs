using CadPessoas.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadPessoas.Controllers
{
    public class PessoaController : Controller
    {
        public IActionResult Index()
        {
            List<Pessoa> lista = new List<Pessoa>();


            lista.Add(new Pessoa
            {
                Id = 1,
                Nome = "Juan"
            });

            return View(lista);
        }
    }
}
