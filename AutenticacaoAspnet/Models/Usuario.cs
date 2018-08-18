using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutenticacaoAspnet.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(50)]
        public string Login { get; set; }
        [Required]
        [MaxLength(50)]
        public string Senha { get; set; }
        [Display()]
        [Required]
        [MaxLength(50)]
        public string ConfirmacaoSenha { get; set; }
    }
}