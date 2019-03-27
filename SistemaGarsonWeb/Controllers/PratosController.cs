using SistemaGarsonWeb.Context;
using SistemaGarsonWeb.Models;
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
            SqlConnection cmd = new SqlConnection("Data Source = den1.mssql8.gear.host;Initial Catalog = sgarsonbd100; Persist Security Info = True;User ID = sgarsonbd100;Password = Vp641Yzr_W0_");
            cmd.Open();
            ContextModel _db = new ContextModel(); 
            Prato prato = new Prato();
            prato.Nome = "Teste";
            prato.Descricao = "Testando conectino no banco iuserf";
            prato.Preco = 78;
            _db.Pratos.Add(prato);
            return View();
        }
    }
}