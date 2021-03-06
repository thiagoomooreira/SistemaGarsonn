﻿using SistemaGarsonWeb.Context;
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
        ContextModel _db = new ContextModel();
        // GET: Pratos
        public ActionResult Index()
        {
            if(!Autenticar()) {
                return RedirectToAction("Index", "Login", new LoginVM());
            }
            return View(new PratoVM());
        }
        public ActionResult Cadastrar() {
            return View(new PratoVM());
        }
        [HttpPost]
        public ActionResult Cadastrar([Bind(Include = "Prato")]PratoVM pratoVM) {
            try {
                _db.Pratos.Add(pratoVM.Prato);
                _db.SaveChanges();
                return View("Index", new PratoVM());
            }
            catch {
                return View("Index", new PratoVM());
            }
        }
        public ActionResult Editar(Prato prato) {
            prato = _db.Pratos.Where(l => l.IdPrato == prato.IdPrato).FirstOrDefault();
            PratoVM pratoVM = new PratoVM { Prato = prato };
            return View(pratoVM);
        }
        [HttpPost]
        public ActionResult Editar([Bind(Include = "Prato")]PratoVM pratoVM) {
            try {
                var consulta = _db.Pratos.Where(l => l.IdPrato == pratoVM.Prato.IdPrato).FirstOrDefault();
                if(consulta != null) {
                    consulta.Nome = pratoVM.Prato.Nome;
                    consulta.Descricao = pratoVM.Prato.Descricao;
                    consulta.Preco = pratoVM.Prato.Preco;
                }
                _db.SaveChanges();
                return View("Index", new PratoVM());
            }
            catch {
                return View("Index", new PratoVM());

            }

        }
        public ActionResult Deletar(Prato prato) {
            prato = _db.Pratos.Where(l => l.IdPrato == prato.IdPrato).FirstOrDefault();
            PratoVM pratoVM = new PratoVM { Prato = prato };
            return View(pratoVM);
        }
        [HttpPost]
        public ActionResult Deletar([Bind(Include ="Prato")]PratoVM pratoVM) {
            pratoVM.Prato = _db.Pratos.Where(l => l.IdPrato == pratoVM.Prato.IdPrato).FirstOrDefault();
            if(pratoVM.Prato != null) {
                _db.Pratos.Remove(pratoVM.Prato);
                _db.SaveChanges();
            }
            return View("Index",new PratoVM());
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
        private bool Autenticar() {
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