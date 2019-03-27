using SistemaGarsonWeb.Context;
using SistemaGarsonWeb.Models;
using SistemaGarsonWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaGarsonWeb.Controllers
{
    public class PratosController : Controller
    {
        // GET: Pratos
        public ActionResult Index()
        {
            return View(new PratoVM());
        }
        public ActionResult Buscar(string campo) {
            PratoVM Campo = new PratoVM { Campo = campo };
            if(Campo != null) {
                PratoVM todosPratos = new PratoVM();
                var p = from tp in todosPratos.ListarPratos()
                        where tp.Nome.ToUpper().StartsWith(campo.ToUpper())
                        select tp;
                PratoVM pratos = new PratoVM { Pratos = p.ToList<Prato>()};
                if(p.Count() == 0) {
                    return View("Index", new PratoVM());
                }
                else {
                    return View("Index", pratos);
                }
            }
            else {
                return View("Index", new PratoVM());
            }
        }
    }
}