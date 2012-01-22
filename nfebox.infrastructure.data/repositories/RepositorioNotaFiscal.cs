using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nfebox.domain.contracts;
using nfebox.domain.entities;
using nfebox.infrastructure.data.contracts;

namespace nfebox.infrastructure.data.repositories
{
    public class RepositorioNotaFiscal: RepositorioOrmGenerico<NotaFiscal>, IRepositorioNotaFiscal
    {
        public RepositorioNotaFiscal(IConexao conexao) : base(((Conexao)conexao).Context) { }

        public NotaFiscal BuscarPorChaveAcesso(string chave)
        {
            return Buscar(n => n.ChaveAcesso == chave).FirstOrDefault();
        }
    }
}
