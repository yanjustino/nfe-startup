using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nfebox.domain.entities;

namespace nfebox.domain.contracts
{
    public interface IRepositorioNotaFiscal : IRepositorioBase<NotaFiscal>
    {
        NotaFiscal BuscarPorChaveAcesso(string chave);
    }
}
