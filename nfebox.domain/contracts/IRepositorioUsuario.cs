using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nfebox.domain.entities;

namespace nfebox.domain.contracts
{
    public interface IRepositorioUsuario : IRepositorioBase<Usuario>
    {
        bool EmailExisteNoCadastro(string email);
        Usuario BuscarUsuarioPorChave(string chave);
    }
}
