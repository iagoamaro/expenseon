using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Crud.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Grupo")]
        public int GrupoId { get; set; }

        [Display(Name = "Grupo")]
        public string GrupoNome { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        [Compare("Senha", ErrorMessage = "Senha não confere.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        public string ConfirmaSenha { get; set; }

        [Display(Name = "Ativado")]
        public bool Status { get; set; }
    }
}