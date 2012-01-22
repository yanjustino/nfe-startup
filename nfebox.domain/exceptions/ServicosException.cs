using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nfebox.domain.entities;

namespace nfebox.domain.exceptions
{
    public class ServicosException: Exception
    {
        public int Codigo { get; set; }
        public ResponseServicosNotaFiscal Response { get; set; }

        public ServicosException(string message): base(message)
        {
            this.Codigo = 0;
            Response = new ResponseServicosNotaFiscal(this.Codigo, message);
        }

        public ServicosException(string message, int codigo)
            : base(message)
        {
            this.Codigo = codigo;
            Response = new ResponseServicosNotaFiscal(codigo, message);
        }

        public ServicosException(string message, Exception innerException)
            : base(message, innerException)
        {
            this.Codigo = 0;
            Response = new ResponseServicosNotaFiscal(this.Codigo, message);
        }

        public ServicosException(string message, Exception innerException, int codigo): base(message, innerException)
        {
            this.Codigo = codigo;
            Response = new ResponseServicosNotaFiscal(codigo, message);
        }
    }
}
