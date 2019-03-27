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
        //public ActionResult Buscar(string campo) {

        //}
    }
}