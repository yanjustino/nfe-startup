using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nfebox.communication
{
    public class EFDResponse
    {
        public string Codigo { get; private set; }
        public string Status { get; private set; }

        public EFDResponse(string codigo, string status)
        {
            this.Codigo = codigo;
            this.Status = status;
        }
    }
}
