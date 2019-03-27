using SistemaGarsonWeb.Context;
using SistemaGarsonWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGarsonWeb.ViewModel {
    public class PratoVM {
        ContextModel _db = new ContextModel();
        public PratoVM() {
            Pratos = _db.Pratos.ToList();
        }

        public Prato Prato { get; set; }
        public List<Prato> Pratos { get; set; }
        public string Campo { get; set; }

        public List<Prato> ListarPratos() {
            if(Pratos == null) {
                _db.Pratos.ToList();
            }
            return Pratos;
        }
    }
}