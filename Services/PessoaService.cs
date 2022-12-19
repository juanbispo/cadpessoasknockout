﻿using CadPessoas.Data;
using CadPessoas.Models;
using Microsoft.EntityFrameworkCore;

namespace CadPessoas.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly AppDbContext _context;

        public PessoaService(AppDbContext context)
        {
            _context = context;
        }

        public void AddPessoa(Pessoa pessoa)
        {
            try
            {
                _context.Add(pessoa);
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception();
            }
        }

        public List<Pessoa> GetPessoas(int pageNumber)
        {
            try
            {
                var pessoas = _context.Pessoas
                    .OrderBy(p=>p.Nome)
                    .Skip((pageNumber-1)*10)
                    .Take(10)
                    .ToList();

                return pessoas;
            }
            catch
            {
                throw new Exception();
            }
        }
        public List<Pessoa> GetPessoasByName(string searchString , string searchStringCpf)
        {
            var pessoas = new List<Pessoa>();

            if (string.IsNullOrEmpty(searchString))
            {
                pessoas = _context.Pessoas
                    .Where(p=>p.Cpf.Contains(searchStringCpf)).ToList();
            }
            if (string.IsNullOrEmpty(searchStringCpf))
            {
                pessoas = _context.Pessoas
                    .Where(p => p.Nome.ToLower().Contains(searchString.ToLower()))
                    .ToList();
            }
            if (!string.IsNullOrEmpty(searchStringCpf) && !string.IsNullOrEmpty(searchString))
            {
                pessoas = _context.Pessoas
                    .Where(p => p.Nome.ToLower().Contains(searchString.ToLower()) && p.Cpf.Contains(searchStringCpf))
                    .ToList();
            }

            return pessoas;
        }


        public Pessoa RemovePessoa(int id)
        {
            try
            {
                var pessoa = _context.Pessoas.SingleOrDefault(p => p.Id == id);
                _context.Pessoas.Remove(pessoa);
                _context.SaveChanges();
                return pessoa;
            }
            catch
            {
                throw new Exception();
            }
        }

        public void EditPessoa(Pessoa pessoa)
        {
            try {
                if (string.IsNullOrEmpty(pessoa.Nome))
                {
                    throw new Exception();
                }
                if (!pessoa.ValidaEmail())
                {
                    throw new Exception();
                }
                _context.Entry(pessoa).State = EntityState.Modified;

                _context.SaveChanges();
            }
            catch
            {
                throw new Exception();
            }
            
        }

    }
}
