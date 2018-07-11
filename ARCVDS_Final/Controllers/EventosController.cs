using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ARCVDS_Final.Models;

namespace ARCVDS_Final.Controllers { 

    
    public class EventosController : Controller
    {
        //private SociosDB db = new SociosDB();
        private ApplicationDbContext db = new ApplicationDbContext ();
        // GET: Eventos
        public ActionResult Index(string pesquisa2)
        {
            if(!User.IsInRole ("Admin") && !User.IsInRole ("Funcionarios")) {
                return RedirectToAction ("AcessoRestrito", "Erros");
            }
            else { 
                return View (db.Eventos.Where (x => x.nome_Evento.Contains (pesquisa2) || pesquisa2 == null).ToList ());
            }
                //return View (db.Eventos.Where (x => x.nome_Evento.Contains (pesquisa2) || pesquisa2 == null).ToList ());
        }

        // GET: Eventos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction ("Index");
            }
            Eventos eventos = db.Eventos.Find(id);
            if (eventos == null)
            {
                return RedirectToAction ("Index");
            }
            if(!User.IsInRole ("Admin") && !User.IsInRole ("Funcionarios")) {
                return RedirectToAction ("AcessoRestrito", "Erros");
            }
            else {
                return View (eventos);
            }
        }

        // GET: Eventos/Create
        public ActionResult Create()
        {
            if(!User.IsInRole ("Admin") && !User.IsInRole ("Funcionarios")) {
                return RedirectToAction ("AcessoRestrito", "Erros");
            }
            else {
                //return View (db.Beneficios.ToList ());
                return View ();
            }
        }

        // POST: Eventos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Evento,nome_Evento,Descricao,Dia_Evento,nome_Patrocinador")] Eventos eventos)
        {
            if (ModelState.IsValid)
            {
                db.Eventos.Add(eventos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventos);
        }

        // GET: Eventos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction ("Index");
            }
            Eventos eventos = db.Eventos.Find(id);
            if (eventos == null)
            {
                return RedirectToAction ("Index");
            }
            if(!User.IsInRole ("Admin") && !User.IsInRole ("Funcionarios")) {
                return RedirectToAction ("AcessoRestrito", "Erros");
            }
            else {
                return View (eventos);
            }
        }

        // POST: Eventos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Evento,nome_Evento,Descricao,Dia_Evento,nome_Patrocinador")] Eventos eventos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventos);
        }

        // GET: Eventos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction ("Index");
            }
            Eventos eventos = db.Eventos.Find(id);
            if (eventos == null)
            {
                return RedirectToAction ("Index");
            }
            if(!User.IsInRole ("Admin") && !User.IsInRole ("Funcionarios")) {
                return RedirectToAction ("AcessoRestrito", "Erros");
            }
            else {
                return View (eventos);
            }
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Eventos eventos = db.Eventos.Find(id);
            db.Eventos.Remove(eventos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
