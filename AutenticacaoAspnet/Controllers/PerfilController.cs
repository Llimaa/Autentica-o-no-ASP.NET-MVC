using AutenticacaoAspnet._1_Infra;
using AutenticacaoAspnet._2_Repositorio.Models;
using AutenticacaoAspnet.Models;
using AutenticacaoAspnet.ModelsViews;
using AutenticacaoAspnet.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AutenticacaoAspnet.Controllers
{
    public class PerfilController : Controller
    {
        // GET: Perfil
        public ActionResult AlterarSenha()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult AlterarSenha(AlterarSenhaViewModel ViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var identity = User.Identity as ClaimsIdentity;
            var login = identity.Claims.FirstOrDefault(c => c.Type == "Login").Value;
            

            UsuarioRepositorio _USREP = new UsuarioRepositorio(new MSSQLDB());

            Usuario usuario = new Usuario
            {
                Senha = Hash.GerarHash(ViewModel.SenhaAtual),
                Login = login
            };
            var user= _USREP.BuscarPorLogin(usuario);

            if (user == null)
            {
                View();
            }

            if (Hash.GerarHash(usuario.Senha) != Hash.GerarHash(user.Senha))
            {
                ModelState.AddModelError("SenhaAtual", "Senha Incorreta");
                return View();
            }
            else
            {
                usuario.Senha = Hash.GerarHash(ViewModel.NovaSenha);
                _USREP.AlterarSenha(usuario);
                return RedirectToAction("Index", "Painel");
            }TempData["usuario"] = "Senha alterada com sucesso";
        }
    }
}