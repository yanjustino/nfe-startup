using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nfebox.domain.contracts;
using nfebox.domain.entities.agreggates;
using nfebox.infrastructure.data.contracts;

namespace nfebox.infrastructure.data.repositories
{
    public class ReposiotorioParticipante : RepositorioOrmGenerico<Participante>, IRepositorioParticipante
    {
        public ReposiotorioParticipante(IConexao conexao) : base(((Conexao)conexao).Context) { }

        public Participante SelecionarPorCnpjCpf(string cnpjCpf)
        {
            return Buscar(p => p.CnpjCpf == cnpjCpf).FirstOrDefault();
        }
    }
}
