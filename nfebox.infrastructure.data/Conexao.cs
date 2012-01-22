using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nfebox.infrastructure.data.contracts;
using nfebox.infrastructure.data.Context;

namespace nfebox.infrastructure.data
{
    internal class Conexao : IConexao
    {
        public nfeboxContext Context { get; set; }
    }

}
