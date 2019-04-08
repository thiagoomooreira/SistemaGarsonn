using SistemaGarsonWeb.Context;
using SistemaGarsonWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGarsonWeb.ViewModel {
    public class ColaboradorVM {
        ContextModel _db = new ContextModel();

        public Colaborador Colaborador { get; set; }
        public List<Colaborador> Colaboradores { get; set; }
        public string Campo { get; set; }

        public List<Colaborador> ListarColaboradores() {
            if(Colaboradores == null) {
                Colaboradores = _db.Colaboradors.ToList();
            }
            return Colaboradores;
        }
    }
}