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

        public ApiController(IServicoNotaFiscal servicos)
        {
            this.Servicos = servicos;
        }

        [HttpPost]
        public JsonResult NFeJson()
        {
            var xml = XElement.Parse(Request.Form["xml"].ToString());
            var key = Request.Form["key"].ToString();
            var response = ExecutarServicoGravarNotaFiscal(xml, key);

            return Json(response);
        }

        public ActionResult NFeJsonMock()
        {
            return View();
        }

        [HttpPost]
        public JsonResult NFeJsonMock(string teste)
        {
            var xml = XElement.Parse(Properties.Resources.nfe24110604385909000166550010000000521001535245);
            var key = "yanlimaj@gmail.comd875d27a0f2222d245bd3250a838c2bfb5c3012005f55f298ae3c290bd650637fda8a5b56f151b13a8936bf4369dc650b2fde28546cfcfb40da0fc68";
            ExecutarServicoGravarNotaFiscal(xml, key);

            var xml1 = XElement.Parse(Properties.Resources.NFe24110604385909000166550010000000531001542290);
            var key1 = "yanlimaj@gmail.comd875d27a0f2222d245bd3250a838c2bfb5c3012005f55f298ae3c290bd650637fda8a5b56f151b13a8936bf4369dc650b2fde28546cfcfb40da0fc68";
            ExecutarServicoGravarNotaFiscal(xml1, key1);

            var xml2 = XElement.Parse(Properties.Resources.NFe24111208403578000109550010000415051001727279);
            var key2 = "yanlimaj@gmail.comd875d27a0f2222d245bd3250a838c2bfb5c3012005f55f298ae3c290bd650637fda8a5b56f151b13a8936bf4369dc650b2fde28546cfcfb40da0fc68";
            var response = ExecutarServicoGravarNotaFiscal(xml2, key2);


            return Json(response);
        }

        [HttpPost]
        public XmlResult NFeXml()
        {
            var xml = XElement.Parse(Request.Form["xml"].ToString());
            var key = Request.Form["key"].ToString();
            var response = ExecutarServicoGravarNotaFiscal(xml, key);

            return new XmlResult(response.ToXml());
        }

        protected ResponseServicosNotaFiscal ExecutarServicoGravarNotaFiscal(XElement xml, string key)
        {
            var response = Servicos.GravarNotaFiscalNoBancoDeDados(xml, key);
            return response;
        }
    }
}
