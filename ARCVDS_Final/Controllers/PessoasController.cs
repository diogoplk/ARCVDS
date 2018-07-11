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
    public class PessoasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pessoas
        public ActionResult Index(string pesquisa)
        {
            //return View(db.Pessoas.ToList());

            if(!User.Identity.IsAuthenticated) {
                return RedirectToAction ("AcessoRestrito", "Erros");
                if(User.IsInRole ("Admnistrador")) {
                    return View(db.Pessoas.Where (x => x.Nome.StartsWith (pesquisa) || pesquisa == null).ToList ());
                }
            }
            else {
                return View (db.Pessoas.Where (x => x.Nome.StartsWith (pesquisa) || pesquisa == null).ToList ());
            }
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction ("Index");
            }
            Pessoas pessoas = db.Pessoas.Find(id);
            if (pessoas == null)
            {
                return RedirectToAction ("Index");
            }
            if(!User.Identity.IsAuthenticated) {
                return RedirectToAction ("AcessoRestrito", "Erros");
                if(User.IsInRole ("Admnistrador")) {
                    return View (pessoas);
                }
            }
            else {
                return View (pessoas);
            }
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            if(!User.Identity.IsAuthenticated) {
                return RedirectToAction ("AcessoRestrito", "Erros");
                if(User.IsInRole ("Admnistrador")) {
                    return View (db.Pagamentos.ToList ());
                }
            }
            else {
                //return View (db.Beneficios.ToList ());
                return View ();
            }
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pessoa_ID,Nome,data_Nascimento,Sexo,Morada,Codigo_Postal,Nacionalidade,Email,numeroTelefone,numeroTelemovel,dataEntradaClube,UserName")] Pessoas pessoas)
        {
            if (ModelState.IsValid)
            {
                db.Pessoas.Add(pessoas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pessoas);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction ("Edit");
            }
            Pessoas pessoas = db.Pessoas.Find(id);

            if (pessoas == null)
            {
                return RedirectToAction ("Index");
            }
            if(!User.Identity.IsAuthenticated) {
                return RedirectToAction ("AcessoRestrito", "Erros");
                if(User.IsInRole ("Admnistrador")) {
                    return View (pessoas);
                }
            }
            else {
                return View (pessoas);
            }
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pessoa_ID,Nome,data_Nascimento,Sexo,Morada,Codigo_Postal,Nacionalidade,Email,numeroTelefone,numeroTelemovel,dataEntradaClube,UserName")] Pessoas pessoas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoas);
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction ("Index");
            }
            Pessoas pessoas = db.Pessoas.Find(id);
            if (pessoas == null)
            {
                return RedirectToAction ("Index");
            }
            if(!User.Identity.IsAuthenticated) {
                return RedirectToAction ("AcessoRestrito", "Erros");
                if(User.IsInRole ("Admnistrador")) {
                    return View (pessoas);
                }
            }
            else {
                return View (pessoas);
            }
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pessoas pessoas = db.Pessoas.Find(id);
            db.Pessoas.Remove(pessoas);
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
