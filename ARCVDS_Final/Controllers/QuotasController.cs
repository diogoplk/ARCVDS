﻿using System;
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
    public class QuotasController : Controller
    {
        private SociosDB db = new SociosDB();

        // GET: Quotas
        public ActionResult Index()
        {
            var quotas = db.Quotas.Include(q => q.Pessoa);
            return View(quotas.ToList());
        }

        // GET: Quotas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quotas quotas = db.Quotas.Find(id);
            if (quotas == null)
            {
                return HttpNotFound();
            }
            return View(quotas);
        }

        // GET: Quotas/Create
        public ActionResult Create()
        {
            ViewBag.PessoaFK = new SelectList(db.Pessoas, "Pessoa_ID", "Nome");
            return View();
        }

        // POST: Quotas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Quota,ano_Quota,Descricao,Paga,PessoaFK")] Quotas quotas)
        {
            if (ModelState.IsValid)
            {
                db.Quotas.Add(quotas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PessoaFK = new SelectList(db.Pessoas, "Pessoa_ID", "Nome", quotas.PessoaFK);
            return View(quotas);
        }

        // GET: Quotas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quotas quotas = db.Quotas.Find(id);
            if (quotas == null)
            {
                return HttpNotFound();
            }
            ViewBag.PessoaFK = new SelectList(db.Pessoas, "Pessoa_ID", "Nome", quotas.PessoaFK);
            return View(quotas);
        }

        // POST: Quotas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Quota,ano_Quota,Descricao,Paga,PessoaFK")] Quotas quotas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quotas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PessoaFK = new SelectList(db.Pessoas, "Pessoa_ID", "Nome", quotas.PessoaFK);
            return View(quotas);
        }

        // GET: Quotas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quotas quotas = db.Quotas.Find(id);
            if (quotas == null)
            {
                return HttpNotFound();
            }
            return View(quotas);
        }

        // POST: Quotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quotas quotas = db.Quotas.Find(id);
            db.Quotas.Remove(quotas);
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
