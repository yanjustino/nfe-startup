using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ActionMailer.Net.Mvc;
using nfebox.domain.entities;

namespace nfebox.presentation.mvc.Controllers
{
    public class EmailController : MailerBase
    {
        public EmailResult EmailVerificacao(Usuario model)
        {
            To.Add(model.Email);
            From = "validacao@nfe.com";
            Subject = "NFe email de verificação";
            return Email("EmailVerificacao", model);
        }

        public EmailResult EmailTecncico(string mensagem, string excessao, string stackTrace)
        {
            var mensagem_tecnica = mensagem + "<br/><br/>" + excessao + "<br/><br/>" + stackTrace;


            To.Add("suporte@nfe.com");
            From = "aplicacao@nfe.com";
            Subject = "APLICAÇÃO: suporte técnico";
            return Email("EmailTecncico", mensagem_tecnica);
        }
    }
}
