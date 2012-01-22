using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nfebox.domain.contracts;
using nfebox.infrastructure.data.contracts;
using nfebox.domain.entities;
using System.Data;
using nfebox.domain.entities.factories;
using nfebox.domain.entities.values;
using nfebox.infrastructure.data.Context;

namespace nfebox.infrastructure.data.repositories
{
    public class RepositorioUsuario : RepositorioOrmGenerico<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuario(IConexao conexao) : base(((Conexao)conexao).Context) { }

        public bool EmailExisteNoCadastro(string email)
        {
            var usuario = Buscar(u => u.Email == email);
            return usuario.Count > 0;
        }

        public Usuario BuscarUsuarioPorChave(string chave)
        {
            var usuario = Buscar(u => u.Chave == chave).First();
            return usuario;
        }
    }
}
