using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nfebox.domain.entities;

namespace nfebox.domain.contracts
{
    public interface IServicosUsuario
    {
        void Logout();
        void AtivarUsuario(string chave, string email);
        bool Logon(string login, string senha);
        void CriarNovoUsuario(Usuario usuario);
        Usuario UsuarioDaSessao();
    }
}
