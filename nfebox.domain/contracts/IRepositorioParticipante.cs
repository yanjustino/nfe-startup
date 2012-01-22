using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nfebox.domain.entities.agreggates;

namespace nfebox.domain.contracts
{
    public interface IRepositorioParticipante : IRepositorioBase<Participante>
    {
        Participante SelecionarPorCnpjCpf(string cnpjCpf);
    }
}
