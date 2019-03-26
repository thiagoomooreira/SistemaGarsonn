using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaGarsonWeb.Models {
    public class PratosPedidos {
        [ForeignKey("Prato")]
        public int IdPrato { get; set; }
        public virtual Prato Prato { get; set; }
        [ForeignKey("Pedido")]
        public int IdPedido { get; set; }
        public virtual Pedido Pedido { get; set; }
        public int Quantidade { get; set; }
    }
}