using SistemaGarsonWeb.Context;
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
        ContextModel _db = new ContextModel();
        // GET: Colaboradores
        public ActionResult Index()
        {
            if(!Autenticar()) {
                return RedirectToAction("Index", "Login", new LoginVM());
            }
            return View(new ColaboradorVM());
        }

        [HttpPost]
        public ActionResult Cadastrar([Bind(Include = "Colaborador")]ColaboradorVM colaboradorVM) {
            try {
                _db.Colaboradors.Add(colaboradorVM.Colaborador);
                _db.SaveChanges();
                return View("Index", new ColaboradorVM());
            }
            catch {
                return View("Index", new ColaboradorVM());
            }

        }

        public ActionResult Cadastrar() {
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

        public ActionResult Editar(Colaborador colaborador) {
            colaborador = _db.Colaboradors.Where(l => l.IdColaborador == colaborador.IdColaborador).FirstOrDefault();
            ColaboradorVM colaboradorVM = new ColaboradorVM { Colaborador = colaborador };
            return View(colaboradorVM);
        }

        [HttpPost]
        public ActionResult Editar([Bind(Include = "Colaborador")]ColaboradorVM colaboradorVM) {
            try {
                var consulta = _db.Colaboradors.Where(l => l.IdColaborador == colaboradorVM.Colaborador.IdColaborador).FirstOrDefault();
                if(consulta != null) {
                    consulta.Nome = colaboradorVM.Colaborador.Nome;
                    consulta.Telefone = colaboradorVM.Colaborador.Telefone;
                    consulta.Cpf = colaboradorVM.Colaborador.Cpf;
                    consulta.Funcao = colaboradorVM.Colaborador.Funcao;
                }
                _db.SaveChanges();
                return View("Index", new ColaboradorVM());
            }
            catch {
                return View("Index", new ColaboradorVM());
            }
        }

        public ActionResult Deletar(Colaborador colaborador) {
            colaborador = _db.Colaboradors.Where(l => l.IdColaborador == colaborador.IdColaborador).FirstOrDefault();
            ColaboradorVM colaboradorVM = new ColaboradorVM { Colaborador = colaborador };
            return View(colaboradorVM);
        }

        [HttpPost]
        public ActionResult Deletar([Bind(Include = ("Colaborador"))]ColaboradorVM colaboradorVM) {
            colaboradorVM.Colaborador = _db.Colaboradors.Where(l => l.IdColaborador == colaboradorVM.Colaborador.IdColaborador).FirstOrDefault();
            if(colaboradorVM.Colaborador != null) {
                _db.Colaboradors.Remove(colaboradorVM.Colaborador);
                _db.SaveChanges();
            }
            return View("Index", new ColaboradorVM());
        }

        public bool Autenticar() {
            try {
                if(TempData["logado"] != null) {
                    TempData.Keep("logado");
                    return true;
                }
                return false;
            }
            catch {
                return false;
            }
        }


    }
}