using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using nfebox.domain.entities;

namespace nfebox.domain.contracts
{
    public interface IServicoNotaFiscal
    {
        ResponseServicosNotaFiscal GravarNotaFiscalNoBancoDeDados(XElement xml, string chaveUsuario);
    }
}
