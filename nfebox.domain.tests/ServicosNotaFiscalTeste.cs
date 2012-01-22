using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

namespace nfebox.domain.tests
{
    [TestClass]
    public class ServicosNotaFiscalTeste
    {
        [TestMethod]
        public void GravarNotaFiscalApartirDoXml()
        {
            var xml = XElement.Parse(Properties.Resources.NFe24110604385909000166550010000000521001535245);

        }
    }
}
