using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nfebox.domain.entities;
using nfebox.domain.entities.factories;
using nfebox.domain.contracts;
using nfebox.domain.exceptions;

namespace nfebox.presentation.mvc.Controllers
{
    public class UsuarioController : Controller
    {
        private IServicosUsuario Servicos;
        private EmailController ServicosEmail;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(UsuarioController));
        private IRepositorioNotaFiscal RepositorioNotas;

        public UsuarioController(IServicosUsuario servicos, IRepositorioNotaFiscal repositorioNotas)
        {
            Servicos = servicos;
            ServicosEmail = new EmailController();
            RepositorioNotas = repositorioNotas;
        }

        [Authorize]
        public ActionResult Index()
        {
            var usuario = Servicos.UsuarioDaSessao();
            ViewBag.Notas = RepositorioNotas.Buscar(n => n.UsuarioId == usuario.Id).ToList();
            return View(usuario);
        }

        public ActionResult Create()
        {
            var user = FabricaUsuario.Criar();
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                Servicos.CriarNovoUsuario(usuario);
                ServicosEmail.EmailVerificacao(usuario);
                return View();
            }
            catch (ServicosException ex)
            {
                ViewBag.Erros = ex.Message;
            }
            catch (Exception ex)
            {
                var mensagem = string.Format("Ocorreu um erro inesperado {0} \r\n {1}", ex.Message, ex.InnerException.Message);
                ViewBag.Erros = mensagem;
                log.Error(mensagem, ex);
            }
            return View();
        }

        public ActionResult Activate(string key, string email)
        {
            try
            {
                Servicos.AtivarUsuario(key, email);
                ViewBag.Ativo = true;
            }
            catch (ServicosException ex)
            {
                var mensagem = string.Format("Erro na ativação de conta do usuário {0}", email);
                log.Info(mensagem, ex);

                ViewBag.Ativo = false;
                ViewBag.Email = email;
            }
            catch (Exception ex)
            {
                var mensagem = string.Format("Erro inesperado {0}", ex.Message);
                log.Error(mensagem, ex);
            }
            return View();
        }

        public ActionResult Logout()
        {
            Servicos.Logout();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Login()
        {
            try
            {
                var login = Request.Form["login"].ToString();
                var senha = Request.Form["senha"].ToString();

                if (Servicos.Logon(login, senha))
                    return Json(new { success = true });
                else
                    return Json(new { success = false });
            }
            catch (ServicosException ex)
            {
                ViewBag.Erros = ex.Message;
            }
            catch (Exception ex)
            {
                var mensagem = string.Format("Ocorreu um erro inesperado {0}", ex.Message);
                log.Error(mensagem, ex);
            }
            return Json(new { success = false });
        }
    }
}
