using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaGarsonWeb.Models {
    [Table("Pedido")]
    public class Pedido {
        [Key]
        public int IdPedido { get; set; }
        public string Cliente { get; set; }
        public string Mesa { get; set; }
        public decimal ValorTotal { get; set; }
        public string Status { get; set; }
        [ForeignKey("Colaborador")]
        public int IdColaborador { get; set; }
        public virtual Colaborador Colaborador { get; set; }
    }
}