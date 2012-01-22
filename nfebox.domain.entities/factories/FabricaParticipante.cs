using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nfebox.domain.entities.agreggates;
using System.Xml.Linq;

namespace nfebox.domain.entities.factories
{
    public class FabricaParticipante: FabricaNotaFiscalBase
    {
        public static Participante CriarEmitente(XElement xml)
        {
            var infNFe = xml.Descendants().Elements(xmlns + "infNFe").First();
            var emit = infNFe.Element(xmlns + "emit");

            var emitente = new Participante();
            emitente.CnpjCpf = ParseToString(emit.Element(xmlns + "CNPJ"), "");
            if (emitente.CnpjCpf == "")
                emitente.CnpjCpf = ParseToString(emit.Element(xmlns + "CPF"), "");

            emitente.InscricaoEstadual = ParseToString(emit.Element(xmlns + "IE"), "");
            emitente.RazaoSocial = ParseToString(emit.Element(xmlns + "xNome"), "");
            emitente.Email = ParseToString(emit.Element(xmlns + "email"), "");

            if (emit.Element(xmlns + "enderEmit") != null)
            {
                var enderEmit = emit.Element(xmlns + "enderEmit");
                emitente.Endereco = ParseToString(enderEmit.Element(xmlns + "xLgr"), "");
                emitente.Numero = ParseToString(enderEmit.Element(xmlns + "nro"), "");
                emitente.Bairro = ParseToString(enderEmit.Element(xmlns + "xBairro"), "");
                emitente.CodigoMunicipio = ParseToString(enderEmit.Element(xmlns + "cMun"), "");
                emitente.Cidade = ParseToString(enderEmit.Element(xmlns + "xMun"), "");
                emitente.UF = ParseToString(enderEmit.Element(xmlns + "UF"), "");
                emitente.CEP = ParseToString(enderEmit.Element(xmlns + "CEP"), "");
                emitente.CodigoPais = ParseToString(enderEmit.Element(xmlns + "cPais"), "");
                emitente.Pais = ParseToString(enderEmit.Element(xmlns + "xPais"), "");
                emitente.Telefone = ParseToString(enderEmit.Element(xmlns + "fone"), "");
            }

            return emitente;
        }

        public static Participante CriarDestinatario(XElement xml)
        {
            var infNFe = xml.Descendants().Elements(xmlns + "infNFe").First();
            var dest = infNFe.Element(xmlns + "dest");

            var destinatario = new Participante();
            destinatario.CnpjCpf = ParseToString(dest.Element(xmlns + "CNPJ"), "");
            if (destinatario.CnpjCpf == "")
                destinatario.CnpjCpf = ParseToString(dest.Element(xmlns + "CPF"), "");

            destinatario.InscricaoEstadual = ParseToString(dest.Element(xmlns + "IE"), "");
            destinatario.RazaoSocial = ParseToString(dest.Element(xmlns + "xNome"), "");
            destinatario.Email = ParseToString(dest.Element(xmlns + "email"), "");

            if (dest.Element(xmlns + "enderDest") != null)
            {
                var enderDest = dest.Element(xmlns + "enderDest");
                destinatario.Endereco = ParseToString(enderDest.Element(xmlns + "xLgr"), "");
                destinatario.Numero = ParseToString(enderDest.Element(xmlns + "nro"), "");
                destinatario.Bairro = ParseToString(enderDest.Element(xmlns + "xBairro"), "");
                destinatario.CodigoMunicipio = ParseToString(enderDest.Element(xmlns + "cMun"), "");
                destinatario.Cidade = ParseToString(enderDest.Element(xmlns + "xMun"), "");
                destinatario.UF = ParseToString(enderDest.Element(xmlns + "UF"), "");
                destinatario.CEP = ParseToString(enderDest.Element(xmlns + "CEP"), "");
                destinatario.CodigoPais = ParseToString(enderDest.Element(xmlns + "cPais"), "");
                destinatario.Pais = ParseToString(enderDest.Element(xmlns + "xPais"), "");
                destinatario.Telefone = ParseToString(enderDest.Element(xmlns + "fone"), "");
            }
            return destinatario;
        }

    }
}
