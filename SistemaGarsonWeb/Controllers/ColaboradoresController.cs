using SistemaGarsonWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaGarsonWeb.Controllers
{
    public class ColaboradoresController : Controller
    {
        // GET: Colaboradores
        public ActionResult Index()
        {
            return View(new ColaboradorVM());
        }



    }
}