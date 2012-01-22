using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nfebox.domain.contracts;
using System.Xml.Linq;
using nfebox.presentation.mvc.Controllers.Results;

namespace nfebox.presentation.mvc.Controllers
{
    public class ApiController : Controller
    {
        private IServicoNotaFiscal Servicos;

        public ApiController(IServicoNotaFiscal servicos)
        {
            this.Servicos = servicos;
        }

        [HttpPost]
        public JsonResult NFeJson()
        {
            var response = CapturarParametrosDoRequestExecutarServicoGravarNotaFiscal();
            return Json(response);
        }

        [HttpPost]
        public XmlResult NFeXml()
        {
            var response = CapturarParametrosDoRequestExecutarServicoGravarNotaFiscal();
            return new XmlResult(response.ToXml());
        }

        private domain.entities.ResponseServicosNotaFiscal CapturarParametrosDoRequestExecutarServicoGravarNotaFiscal()
        {
            var xml = Request.Form["xml"].ToString();
            var key = Request.Form["key"].ToString();
            var xml_nfe = XElement.Parse(xml);

            var response = Servicos.GravarNotaFiscalNoBancoDeDados(xml_nfe, key);
            return response;
        }
    }
}
