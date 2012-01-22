using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace nfebox.domain.entities
{
    public class ResponseServicosNotaFiscal
    {
        public int Codigo { get; set; }
        public string Status { get; set; }

        public ResponseServicosNotaFiscal()
        {

        }

        public ResponseServicosNotaFiscal(int codigo, string status)
        {
            this.Codigo = codigo;
            this.Status = status;
        }

        public XElement ToXml()
        {
            XElement root = new XElement("response");
            root.Add(new XElement("codigo", this.Codigo));
            root.Add(new XElement("status", this.Status));
            return root;
        }
    }
}
