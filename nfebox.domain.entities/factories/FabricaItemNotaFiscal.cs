using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nfebox.domain.entities.agreggates;
using System.Xml.Linq;

namespace nfebox.domain.entities.factories
{
    public class FabricaItemNotaFiscal : FabricaNotaFiscalBase
    {
        public static List<ItemNotaFiscal> Criar(XElement xml)
        {
            var infNFe = xml.Descendants().Elements(xmlns + "infNFe").First();
            var listaDet = infNFe.Elements(xmlns + "det");

            var itens = new List<ItemNotaFiscal>();

            foreach (var det in listaDet)
            {
                var prod = det.Element(xmlns + "prod");

                var item = new ItemNotaFiscal();
                item.Codigo = ParseToString(prod.Element(xmlns + "cProd"), 0);
                item.EAN = ParseToString(prod.Element(xmlns + "cEAN"), 0);
                item.NomeProduto = ParseToString(prod.Element(xmlns + "xProd"), "");
                item.NCM = ParseToString(prod.Element(xmlns + "NCM"), 0);
                item.CFOP = ParseToString(prod.Element(xmlns + "CFOP"), 0);
                item.Unidade = ParseToString(prod.Element(xmlns + "uCom"), 0);
                item.Quantidade = ParseToDouble(prod.Element(xmlns + "qCom"), 0);
                item.ValorUnitario = ParseToDouble(prod.Element(xmlns + "vUnCom"), 0);
                item.ValorProduto = ParseToDouble(prod.Element(xmlns + "vProd"), 0);
                item.UnidadeTributado = ParseToString(prod.Element(xmlns + "uTrib"), 0);
                item.QuantidadeTributado = ParseToDouble(prod.Element(xmlns + "qTrib"), 0);
                item.ValorUnitarioTributado = ParseToDouble(prod.Element(xmlns + "vUnTrib"), 0);
                item.ValorFrete = ParseToDouble(prod.Element(xmlns + "vFrete"), 0);
                item.ValorSeguro = ParseToDouble(prod.Element(xmlns + "vSeg"), 0);
                item.ValorOutro = ParseToDouble(prod.Element(xmlns + "vOutro"), 0);
                item.IndicadorTotalizador = Convert.ToInt32(ParseToString(prod.Element(xmlns + "indTot"), 0));
                itens.Add(item);
            }
            return itens;
        }
    }
}
