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
            ContextModel _db = new ContextModel(); 
            Prato prato = new Prato();
            prato.Nome = "Tete";
            prato.Descricao = "Testando conectino no banco iuserf";
            prato.Preco = 748;
            _db.Pratos.Add(prato);
            _db.SaveChanges();
            return View();
        }
    }
}