﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CadPessoas.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Informe o Nome")]
        [StringLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string? Nome { get; set; }

        [DataType(DataType.EmailAddress,ErrorMessage="Informe um E-mail Válido")]
        [StringLength(60,ErrorMessage ="Máximo de 60 caracteres")]
        public string? Email { get; set; }


        public bool ValidaEmail()
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(Email);
            if (match.Success)
                return true;
            else
                return false;
        }
    }
}
