using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutenticacaoAspnet.ModelsViews
{
    public class LoginViewModel
    {
        public string  UrlRetorno { get; set; }
        [Required(ErrorMessage ="Informe o login")]
        [MaxLength(50,ErrorMessage ="O login deve ter ate 50 caractéres")]
        public string Login { get; set; }
        [Required(ErrorMessage ="Informe a senha")]
        [MaxLength(50,ErrorMessage ="A senha deve ter ate 50 caractéres")]
        [DataType(DataType.Password)]
        public string  Senha { get; set; }
    }
}