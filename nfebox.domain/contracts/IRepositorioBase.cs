using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nfebox.domain.entities.contracts;

namespace nfebox.domain.contracts
{
    public interface IRepositorioBase<T> where T : IEntidade
    {
        void Incluir(T model);
        void Atualizar(T model);
        void Atualizar(T model, params object[] attachment);
        void Excluir(T model);

        T Buscar(int Id);
        ICollection<T> Buscar(Func<T, bool> predicate);
        ICollection<T> BuscarTodos();
    }
}
