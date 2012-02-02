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
        public static IConexao Criar(string sqlserverUri = "")
        {
            var conexao = new Conexao();
            if (string.IsNullOrEmpty(sqlserverUri))
                conexao.Context = new nfeboxContext();
            else
                conexao.Context = new nfeboxContext(ConnectionStringAppHarbor.CriarStringConexao(sqlserverUri));
            return conexao;
        }
    }
}
