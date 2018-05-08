using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ARCVDS_Final.Models;
using System.IO;

namespace ARCVDS_Final.Controllers
{
    public class EventosController : Controller
    {
        private SociosDB db = new SociosDB();

        // GET: Eventos
        public ActionResult Index()
        {
            return View(db.Eventos.ToList());
        }

        // GET: Eventos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eventos eventos = db.Eventos.Find(id);
            if (eventos == null)
            {
                return HttpNotFound();
            }
            return View(eventos);
        }

        // GET: Eventos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Eventos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Evento,nome_Evento,Descricao,Dia_Evento,imagens_Evento,nome_Patrocinador")] Eventos eventos, IEnumerable<HttpPostedFileBase> FotosUpload )
        {

            int novoID = 0;

            if (db.Eventos.Count () == 0) {
                novoID = 1;
            }
            else {
                novoID = db.Eventos.Max (e => e.id_Evento) + 1;
            }

            eventos.id_Evento = novoID;

            string nomeFotografia = "Eventos_" + novoID + ".jpg";

            foreach (var item in FotosUpload) {
                var fileName = Path.GetFileName (item.FileName);
                string caminhoParaFotografia = Path.Combine (Server.MapPath ("~/Imagens/"),fileName);

                if (item.ContentLength > 0) {

                    eventos.imagens_Evento = nomeFotografia;
                }
                else {

                    ModelState.AddModelError ("","Não foi fornecida uma imagem...");

                    return View (eventos);
                }

                if (ModelState.IsValid) {
                    db.Eventos.Add (eventos);
                    db.SaveChanges ();
                    item.SaveAs (caminhoParaFotografia);
                    return RedirectToAction ("Index");
                }
            }

            return View(eventos);
        }

        // GET: Eventos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eventos eventos = db.Eventos.Find(id);
            if (eventos == null)
            {
                return HttpNotFound();
            }
            return View(eventos);
        }

        // POST: Eventos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Evento,nome_Evento,Descricao,Dia_Evento,imagens_Evento,nome_Patrocinador")] Eventos eventos)
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eventos eventos = db.Eventos.Find(id);
            if (eventos == null)
            {
                return HttpNotFound();
            }
            return View(eventos);
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
