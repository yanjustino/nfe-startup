using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nfebox.domain.contracts;
using nfebox.domain.entities;
using System.Web;
using System.Web.Security;

namespace nfebox.domain.services
{
    internal static class ServicosSessao
    {
        public static Usuario UsuarioSessao
        {
            get
            {
                return (Usuario)HttpContext.Current.Session["usuaro_sessao"];
            }
            set
            {
                HttpContext.Current.Session["usuaro_sessao"] = value;
            }

        }

        public static void Encerrar()
        {
            HttpContext.Current.Session.Clear();
            FormsAuthentication.SignOut();
        }

        public static void Iniciar(Usuario usuario)
        {
            FormsAuthentication.SetAuthCookie(usuario.Email, false);
            FormsAuthentication.Authenticate(usuario.Email, usuario.Senha);
            UsuarioSessao = usuario;
        }
    }
}
