using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaGarsonWeb.Models {
    [Table("Colaborador")]
    public class Colaborador {
        [Key]
        public int IdColaborador { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Funcao { get; set; }
        public string Telefone { get; set; }
    }
}