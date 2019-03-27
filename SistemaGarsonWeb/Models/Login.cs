using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaGarsonWeb.Models {
    [Table("Login")]
    public class Login {
        [Key]
        public int IdLogin { get; set; }
        public string Senha { get; set; }
        [ForeignKey("Colaborador")]
        public int IdColaborador { get; set; }
        public virtual Colaborador Colaborador { get; set; }
    }
}