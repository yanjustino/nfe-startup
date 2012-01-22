using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using nfebox.domain.entities;
using nfebox.infrastructure.data.contracts;
using nfebox.domain.entities.agreggates;

namespace nfebox.infrastructure.data.Context
{
    public class nfeboxContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<NotaFiscal> NotasFiscais { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<ItemNotaFiscal> ItensNotaFiscal { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<nfeboxContext>(new CreateDatabaseIfNotExists<nfeboxContext>());
        }
    }
}
