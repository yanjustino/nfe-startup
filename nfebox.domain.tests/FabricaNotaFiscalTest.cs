using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nfebox.domain.entities.factories;
using System.Xml.Linq;

namespace nfebox.domain.tests
{
    [TestClass]
    public class FabricaNotaFiscalTest
    {
        [TestMethod]
        public void CriarNotaApartirDoXml()
        {
            var xml = XElement.Parse(Properties.Resources.NFe24111208403578000109550010000415051001727279);
            var nota = FabricaNotaFiscal.Criar(xml);
            Assert.AreEqual("NFe24110604385909000166550010000000521001535245", nota.ChaveAcesso);
        }

        [TestMethod]
        public void CriarNotaApartirDoXmlSemDataSaidaHoraSaida()
        {
            var xml = XElement.Parse(Properties.Resources.NFe24110604385909000166550010000000531001542290);
            var nota = FabricaNotaFiscal.Criar(xml);
            Assert.AreEqual("NFe24110604385909000166550010000000531001542290", nota.ChaveAcesso);
        }
    }
}
