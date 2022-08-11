﻿using CadPessoas.Data;
using CadPessoas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public JsonResult CreatePessoa([FromBody]Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();

            return Json(pessoa);
        }

        [HttpDelete]
        public JsonResult DeletePessoa([FromBody]int id)
        {
            var rmvPessoa = _context.Pessoas.SingleOrDefault(p=>p.Id == id);
            _context.Pessoas.Remove(rmvPessoa);
            _context.SaveChanges();

            return Json(rmvPessoa);
        }

        [HttpPut]
        public JsonResult EditPessoa([FromBody] Pessoa pessoa)
        {
            _context.Entry(pessoa).State = EntityState.Modified;

            _context.SaveChanges();

            return Json(pessoa);
        }
    }
}
