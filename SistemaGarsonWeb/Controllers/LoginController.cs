using SistemaGarsonWeb.Context;
using SistemaGarsonWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaGarsonWeb.Controllers
{
    public class LoginController : Controller
    {
        ContextModel _db = new ContextModel();
        public ActionResult Index()
        {
            return View(new LoginVM());
        }
        public ActionResult Logar([Bind(Include ="Usuario")]LoginVM login) {
            try {
                var colaborador = _db.Colaboradors.Where(l => l.Cpf == login.Usuario.Colaborador.Cpf).FirstOrDefault();
                if(colaborador != null) {

                    var loginConsulta = _db.Logins.Where(l => l.IdColaborador == colaborador.IdColaborador).FirstOrDefault();
                    if(login.Usuario.Senha == loginConsulta.Senha) {
                        TempData["logado"] = true;
                        return RedirectToAction("Index", "Pratos");
                    }
                }
                TempData["logado"] = null;
                return View("Index", new LoginVM());
            }
            catch {
                TempData["logado"] = null;
                return View("Index", new LoginVM());
            }
            
        }
    }
}