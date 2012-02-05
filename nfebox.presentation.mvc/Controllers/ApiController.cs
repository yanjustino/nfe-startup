using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nfebox.domain.contracts;
using System.Xml.Linq;
using nfebox.presentation.mvc.Controllers.Results;
using nfebox.domain.entities;

namespace nfebox.presentation.mvc.Controllers
{
    public class ApiController : Controller
    {
        private IServicoNotaFiscal Servicos;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ApiController));

        public ApiController(IServicoNotaFiscal servicos)
        {
            this.Servicos = servicos;
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult EFDJson()
        {
            var response = new ResponseServicosNotaFiscal();
            try
            {
                var xml = XElement.Parse(Request.Form["xml"].ToString());
                var key = Request.Form["key"].ToString();
                response = Servicos.GravarNotaFiscalNoBancoDeDados(xml, key);
            }
            catch (Exception ex)
            {
                response.Codigo = 501;
                response.Status = "Houve um erro no processamento da nota fiscal";
                log.Error(response.Status, ex);
            }
            return Json(response);
        }
    }
}
