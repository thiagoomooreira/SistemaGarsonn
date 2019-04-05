using SistemaGarsonWeb.Models;
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

        public ActionResult Buscar(string campo) {
            ColaboradorVM Campo = new ColaboradorVM { Campo = campo };
            if(Campo != null) {
                ColaboradorVM todosColaboradores = new ColaboradorVM();
                var c = from tc in todosColaboradores.ListarColaboradores()
                        where tc.Nome.ToUpper().StartsWith(campo.ToUpper()) ||
                        tc.Cpf == campo
                        select tc;
                ColaboradorVM colaboradores = new ColaboradorVM { Colaboradores = c.ToList<Colaborador>() };
                if(c.Count() == 0) {
                    return View("Index", new ColaboradorVM());
                }
                else {
                    return View("Index", colaboradores);
                }
            }
            else {
                return View("Index", new ColaboradorVM());
            }
        }



    }
}