using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaGarsonWeb.Models {
    [Table("PratosPedidos")]
    public class PratosPedidos {
        [ForeignKey("Prato"),Key]
        public int IdPrato { get; set; }
        public Prato Prato { get; set; }
        [ForeignKey("Pedido")]
        public int IdPedido { get; set; }
        public Pedido Pedido { get; set; }
        public int Quantidade { get; set; }
    }
}