using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nfebox.presentation.mvc.Controllers;
using System.Xml.Linq;
using nfebox.domain.entities;
using nfebox.domain.contracts;

namespace nfebox.presentation.mvc.Tests.Controllers
{
    [TestClass]
    public class ApiControllerTest: ApiController
    {
        public ApiControllerTest(IServicoNotaFiscal servicos):base(servicos)
        {

        }

        [TestMethod]
        public void ChamarMetodoExecutarServicoGravarNotaFiscalPassandoUsuarioEXml()
        {
            var xml = XElement.Parse(Properties.Resources.NFe24111208403578000109550010000415051001727279);
            var key = "yanlimaj@gmail.comd875d27a0f2222d245bd3250a838c2bfb5c3012005f55f298ae3c290bd650637fda8a5b56f151b13a8936bf4369dc650b2fde28546cfcfb40da0fc68";
            var retorno = ExecutarServicoGravarNotaFiscal(xml, key);
            Assert.AreEqual(100, retorno.Codigo);
        }
    }
}
