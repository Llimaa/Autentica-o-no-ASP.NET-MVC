using AutenticacaoAspnet._1_Infra;
using AutenticacaoAspnet._2_Repositorio.Models;
using AutenticacaoAspnet.Models;
using AutenticacaoAspnet.ModelsViews;
using AutenticacaoAspnet.Utils;
using System;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AutenticacaoAspnet.Controllers
{
    public class AutenticacaoController : Controller
    {
        UsuarioRepositorio _USREP = new UsuarioRepositorio(new MSSQLDB());
        // GET: Autenticacao
        public ActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(UsuarioModelsViews usuarioViewModels)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View(usuarioViewModels);
                }

                Usuario _user = new Usuario
                {
                    Nome = usuarioViewModels.Nome,
                    Login = usuarioViewModels.Login,
                    Senha = Hash.GerarHash(usuarioViewModels.Senha)
                };
                if (_USREP.VerificarSeExiteNoBanco(_user))
                {
                    ModelState.AddModelError("Login", "Ja possue uma conta de email cadastrado");
                    return View(usuarioViewModels);
                }
                else
                {
                    _USREP.inserir(_user);
                    TempData["resposta"] = "O usuario foi cadastrado com sucesso!";
                }
                return RedirectToAction("Login");


            }
            catch (Exception err)
            {
                return View(usuarioViewModels);
            }

        }
        public ActionResult Login(string ReturnUrl)//ReturnUrle o nome que o Owin utiliza como padrao na query string, para identificar a Url de retorno
        {
            var viewModel = new LoginViewModel
            {
                UrlRetorno = ReturnUrl
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel ViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(ViewModel);
            }
            Usuario _user = new Usuario
            { 
                Login = ViewModel.Login,
                Senha = Hash.GerarHash(ViewModel.Senha)
            };
            var usuario = _USREP.BuscarPorLogin(_user);
            if (usuario == null)
            {
                if (_user.Login == ViewModel.Login)
                {
                    ModelState.AddModelError("Login", "Login Incorreto");
                    return View(ViewModel);
                }
            }
            if (Hash.GerarHash(_user.Senha) != Hash.GerarHash(usuario.Senha))
            {
                ModelState.AddModelError("Senha", "Senha Incorreto");
                return View(ViewModel);
            }
            // logar
            //ClaimsIdentity utilizamos esta classe para definir caracteristicas, ou seja definir 
            var identity = new ClaimsIdentity(new[]
            {
                //aqui e onde dou vida ao cookie de autenticacao.
               new Claim(ClaimTypes.Name,usuario.Nome),
               new Claim("Login",usuario.Login)
           }, "ApplicationCookie");

            Request.GetOwinContext().Authentication.SignIn(identity);

            if (!String.IsNullOrWhiteSpace(ViewModel.UrlRetorno) || Url.IsLocalUrl(ViewModel.UrlRetorno))
            {
                return Redirect(ViewModel.UrlRetorno);
            }
            else
            {
                return RedirectToAction("Index", "Painel");
            }

        }
        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }

    }
}
