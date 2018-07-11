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
    
    public class BeneficiosController : Controller
    {
        //private SociosDB db = new SociosDB();

        private ApplicationDbContext db = new ApplicationDbContext ();

        // GET: Beneficios
        //[Authorize (Roles = "Administrador")]
        public ActionResult Index() { 
            if(!User.Identity.IsAuthenticated) {
               return RedirectToAction ("AcessoRestrito","Erros");
                if(User.IsInRole ("Admin")) {
                    return View (db.Beneficios.ToList ());
                }
            }
            else {
                return View (db.Beneficios.ToList ());
            }
           
        }

        // GET: Beneficios/Details/5
        public ActionResult Details(int? id) { 
            if (id == null)
            {
                return RedirectToAction ("Index");
            }
            Beneficios beneficios = db.Beneficios.Find(id);
            if (beneficios == null)
            {
                return RedirectToAction ("Index");
            }
            if(!User.Identity.IsAuthenticated) {
                return RedirectToAction ("AcessoRestrito", "Erros");
                if(User.IsInRole ("Admin")) {
                    return View (beneficios);
                }
            }
            else {
                return View (beneficios);
            }
        }

        // GET: Beneficios/Create
        public ActionResult Create()
        {
            if(!User.Identity.IsAuthenticated) {
                return RedirectToAction ("AcessoRestrito", "Erros");
                if(User.IsInRole ("Admin")) {
                    return View (db.Beneficios.ToList ());
                }
            }
            else {
                //return View (db.Beneficios.ToList ());
                return View ();
            }
            
        }

        // POST: Beneficios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Beneficio,Categoria,Descricao")] Beneficios beneficios)
        {
            if (ModelState.IsValid)
            {
                db.Beneficios.Add(beneficios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(beneficios);
        }

        // GET: Beneficios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction ("Index");
            }
            Beneficios beneficios = db.Beneficios.Find(id);
            if (beneficios == null)
            {
                return RedirectToAction ("Index");
            }
            if(!User.Identity.IsAuthenticated) {
                return RedirectToAction ("AcessoRestrito", "Erros");
                if(User.IsInRole ("Admin")) {
                    return View (beneficios);
                }
            }
            else {
                return View (beneficios);
            }

        }

        // POST: Beneficios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Beneficio,Categoria,Descricao")] Beneficios beneficios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beneficios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(beneficios);
        }

        // GET: Beneficios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction ("Index");
            }
            Beneficios beneficios = db.Beneficios.Find(id);
            if (beneficios == null)
            {
                return RedirectToAction ("Index");
            }
            if(!User.Identity.IsAuthenticated) {
                return RedirectToAction ("AcessoRestrito", "Erros");
                if(User.IsInRole ("Admin")) {
                    return View (beneficios);
                }
            }
            else {
                return View (beneficios);
            }
        }

        // POST: Beneficios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Beneficios beneficios = db.Beneficios.Find(id);
            db.Beneficios.Remove(beneficios);
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
