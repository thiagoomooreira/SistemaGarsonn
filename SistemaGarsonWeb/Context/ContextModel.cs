using SistemaGarsonWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaGarsonWeb.Context {
    public class ContextModel: DbContext {
        public ContextModel() : base("SistemaDB") {}
        public DbSet<Colaborador> Colaboradors { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Prato> Pratos { get; set; }
        public DbSet<PratosPedidos> PratosPedidos { get; set; }
    }
}