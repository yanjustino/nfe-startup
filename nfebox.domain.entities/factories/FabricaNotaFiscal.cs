using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nfebox.domain.entities.agreggates;
using System.Xml.Linq;
using System.Xml;

namespace nfebox.domain.entities.factories
{
    public class FabricaNotaFiscal : FabricaNotaFiscalBase
    {
        public static NotaFiscal Criar(XElement xml, Usuario usuario = null)
        {
            var infNFe = xml.Descendants().Elements(xmlns + "infNFe").First();
            var ide = infNFe.Element(xmlns + "ide");
            var total = infNFe.Element(xmlns + "total");
            var ICMSTot = total.Element(xmlns + "ICMSTot");

            var notaFiscal = new NotaFiscal();
            notaFiscal.ChaveAcesso = infNFe.Attribute("Id").Value;

            notaFiscal.CodigoUF = ParseToString(ide.Element(xmlns + "cUF"), 0);
            notaFiscal.Codigo = ParseToString(ide.Element(xmlns + "cNF"), 0);
            notaFiscal.Numero = ParseToString(ide.Element(xmlns + "nNF"), 0);
            notaFiscal.Modelo = ParseToString(ide.Element(xmlns + "mod"), 55);
            notaFiscal.Serie = ParseToString(ide.Element(xmlns + "serie"), 0);
            notaFiscal.TipoNF = ParseToString(ide.Element(xmlns + "tpNF"), 0);
            notaFiscal.Ambiente = ParseToString(ide.Element(xmlns + "tpAmb"), 0);
            notaFiscal.Operacao = ParseToString(ide.Element(xmlns + "natOp"), 0);
            notaFiscal.Pagamento = ParseToString(ide.Element(xmlns + "indPag"), 0);
            notaFiscal.TipoEmissao = ParseToString(ide.Element(xmlns + "tpEmis"), 0);
            notaFiscal.Finalidade = ParseToString(ide.Element(xmlns + "finNFe"), 0);
            notaFiscal.Processo = ParseToString(ide.Element(xmlns + "procEmi"), 0);
            notaFiscal.VersaoProcesso = ParseToString(ide.Element(xmlns + "verProc"), 0);
            notaFiscal.Digito = ParseToString(ide.Element(xmlns + "cDV"), 0);
            notaFiscal.DataEmissao = Convert.ToDateTime(ParseToString(ide.Element(xmlns + "dEmi"), DateTime.Today));
            notaFiscal.DataEntradaSaida = Convert.ToDateTime(ParseToString(ide.Element(xmlns + "dSaiEnt"), DateTime.Today));
            notaFiscal.HoraEntradaSaida = ParseToString(ide.Element(xmlns + "hSaiEnt"), "00:00:00");
            notaFiscal.CnpjCpfEmitente = FabricaParticipante.CriarEmitente(xml).CnpjCpf;
            notaFiscal.CnpjCpfDestinatario = FabricaParticipante.CriarDestinatario(xml).CnpjCpf;
            notaFiscal.ValorNotaFiscal = ParseToDouble(ICMSTot.Element(xmlns + "vNF"), 0);
            notaFiscal.Itens = FabricaItemNotaFiscal.Criar(xml);

            notaFiscal.Usuario = usuario;

            return notaFiscal;
        }

    }
}
