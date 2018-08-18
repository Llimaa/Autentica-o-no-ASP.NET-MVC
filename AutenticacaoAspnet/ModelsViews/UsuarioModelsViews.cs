using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutenticacaoAspnet.ModelsViews
{
    public class UsuarioModelsViews
    {
        [Required(ErrorMessage = "Informe seu nome")]
        [MaxLength(50, ErrorMessage = "O nome deve ter ate 50 Caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe seu login")]
        [MaxLength(50, ErrorMessage = "O nome deve ter ate 50 Caracteres")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Informe sua senha")]
        [MaxLength(50, ErrorMessage = "A senha deve ter ate 50 caracters")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Display(Name = "Confirme sua Senha ")]
        [Required(ErrorMessage = "Informe sua senha")]
        [MaxLength(50, ErrorMessage = "A senha deve ter ate 50 caracters")]
        [Compare(nameof(Senha), ErrorMessage = "A senha e a confimação nao estao iguais")]
        [DataType(DataType.Password)]
        public string ConfirmacaoSenha { get; set; }
    }
}