using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nfebox.infrastructure.data.contracts;
using nfebox.infrastructure.data.Context;

namespace nfebox.infrastructure.data.factories
{
    public class FabricaConexao
    {
        public static IConexao Criar()
        {
            var conexao = new Conexao();
            conexao.Context = new nfeboxContext();
            return conexao;
        }
    }
}
