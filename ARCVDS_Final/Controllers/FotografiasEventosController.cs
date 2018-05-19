using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ARCVDS_Final.Models;

namespace ARCVDS_Final.Controllers
{
    public class FotografiasEventosController : Controller
    {
        //private SociosDB db = new SociosDB();

        private ApplicationDbContext db = new ApplicationDbContext ();

        // GET: FotografiasEventos
        public ActionResult Index()
        {
            var fotografiasEventos = db.FotografiasEventos.Include(f => f.Evento);
            return View(fotografiasEventos.ToList());
        }

        // GET: FotografiasEventos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FotografiasEventos fotografiasEventos = db.FotografiasEventos.Find(id);
            if (fotografiasEventos == null)
            {
                return HttpNotFound();
            }
            return View(fotografiasEventos);
        }

        // GET: FotografiasEventos/Create
        public ActionResult Create()
        {
            ViewBag.EventoFK = new SelectList(db.Eventos, "id_Evento", "nome_Evento");
            return View();
        }

        // POST: FotografiasEventos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Fotografia,Imagens,EventoFK")] FotografiasEventos fotografiasEventos)
        {
            if (ModelState.IsValid)
            {
                db.FotografiasEventos.Add(fotografiasEventos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventoFK = new SelectList(db.Eventos, "id_Evento", "nome_Evento", fotografiasEventos.EventoFK);
            return View(fotografiasEventos);
        }

        // GET: FotografiasEventos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FotografiasEventos fotografiasEventos = db.FotografiasEventos.Find(id);
            if (fotografiasEventos == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventoFK = new SelectList(db.Eventos, "id_Evento", "nome_Evento", fotografiasEventos.EventoFK);
            return View(fotografiasEventos);
        }

        // POST: FotografiasEventos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Fotografia,Imagens,EventoFK")] FotografiasEventos fotografiasEventos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fotografiasEventos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventoFK = new SelectList(db.Eventos, "id_Evento", "nome_Evento", fotografiasEventos.EventoFK);
            return View(fotografiasEventos);
        }

        // GET: FotografiasEventos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FotografiasEventos fotografiasEventos = db.FotografiasEventos.Find(id);
            if (fotografiasEventos == null)
            {
                return HttpNotFound();
            }
            return View(fotografiasEventos);
        }

        // POST: FotografiasEventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FotografiasEventos fotografiasEventos = db.FotografiasEventos.Find(id);
            db.FotografiasEventos.Remove(fotografiasEventos);
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
