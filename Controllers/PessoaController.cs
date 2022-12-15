using CadPessoas.Data;
using CadPessoas.Models;
using CadPessoas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadPessoas.Controllers
{

    public class PessoaController : Controller
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }


        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetPessoas()
        {
            try
            {
                var lista = _pessoaService.GetPessoas();

                return Json(lista);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult GetPessoasByName([FromQuery] string searchString)
        {
            try
            {
                var lista = new List<Pessoa>();
                if (String.IsNullOrEmpty(searchString))
                {
                    lista = _pessoaService.GetPessoas();
                }
                else
                {
                    lista = _pessoaService.GetPessoasByName(searchString);
                }

                return Json(lista);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [HttpPost]
        public JsonResult CreatePessoa([FromBody] Pessoa pessoa)
        {
            try
            {
                    
                _pessoaService.AddPessoa(pessoa);
                return Json(pessoa);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [HttpDelete]
        public JsonResult DeletePessoa([FromBody] int id)
        {
            try
            {
                return Json(_pessoaService.RemovePessoa(id));
            }
            catch (Exception e)
            {
                return Json(e);
            }

        }

        [HttpPut]
        public JsonResult EditPessoa([FromBody] Pessoa pessoa)
        {
            try
            {
                _pessoaService.EditPessoa(pessoa);
                return Json(pessoa);

            }
            catch (Exception e)
            {
                return Json(e);
            }
        }
    }
}
