using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutenticacaoAspnet.ModelsViews
{
    public class AlterarSenhaViewModel
    {
        [Required(ErrorMessage ="Informe sua senha atual")]
        [DataType(DataType.Password)]
        [Display(Name ="Senha atual")]
        [MinLength(6,ErrorMessage ="A senha deve ter pelo menos 6 caracteres")]
        public string  SenhaAtual { get; set; }
        [Required(ErrorMessage ="Informe a senha atual")]
        [DataType(DataType.Password)]
        [Display(Name ="Nova senha")]
        [MinLength(6,ErrorMessage ="A senha deve ter pelo menos 6 caracteres")]
        public string  NovaSenha { get; set; }
        [Required(ErrorMessage ="Informe a sua nova senha")]
        [DataType(DataType.Password)]
        [Display(Name ="Confirme a senha")]
        [MinLength(6,ErrorMessage ="A senha deve ter pelo menos 6 caracteres")]
        [Compare(nameof(NovaSenha), ErrorMessage ="A senha e a confirmacao nao estao iguais")]
        public string  ConfirmeSenha { get; set; }
    }
}