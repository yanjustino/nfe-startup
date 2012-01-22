using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data.Objects;
using System.Data.Entity;
using nfebox.domain.contracts;
using nfebox.domain.entities.contracts;

namespace nfebox.infrastructure.data.repositories
{
    public class RepositorioOrmGenerico<T> : IRepositorioBase<T> where T : IEntidade
    {
        DbContext Context;

        public RepositorioOrmGenerico(DbContext context)
        {
            this.Context = context;
        }

        public void Incluir(T model)
        {
            try
            {
                this.Context.Set(typeof(T)).Add(model);
                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Atualizar(T model)
        {
            object TEntity = model;
            this.Context.Entry(TEntity).State = System.Data.EntityState.Modified;
            this.Context.SaveChanges();
        }

        public void Atualizar(T model, params object[] attachment)
        {
            object TEntity = model;
            this.Context.Entry(TEntity).State = System.Data.EntityState.Modified;

            foreach (var attach in attachment)
                this.Context.Entry(attach).State = System.Data.EntityState.Modified;

            this.Context.SaveChanges();
        }

        public void Excluir(T model)
        {
            model = (T)this.Context.Set(typeof(T)).Find(model.Id);
            this.Context.Set(typeof(T)).Remove(model);
            this.Context.SaveChanges();
        }

        public T Buscar(int Id)
        {
            return (T)this.Context.Set(typeof(T)).Find(Id);
        }

        public ICollection<T> Buscar(Func<T, bool> predicate)
        {
            return (this.Context.Set(typeof(T)) as IEnumerable<T>).Where(predicate).ToList();
        }

        public ICollection<T> BuscarTodos()
        {
            return (this.Context.Set(typeof(T)) as IEnumerable<T>).ToList();
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}