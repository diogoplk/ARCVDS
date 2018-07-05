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

    [Authorize (Roles = "Admin, Funcionarios,Socios")]
    public class PagamentosController : Controller
    {
        //private SociosDB db = new SociosDB();

        private ApplicationDbContext db = new ApplicationDbContext ();

        // GET: Pagamentos
        public ActionResult Index()
        {
            var pagamentos = db.Pagamentos.Include(p => p.Quota);
            return View(pagamentos.ToList());
        }
        
        public ActionResult PagamentosUser() {

            if(User.IsInRole ("Admin")) {

                var pagamentos = db.Pagamentos.Include (p => p.Quota);
                return View (pagamentos.ToList ());
            }

            var ListaPagamentos = db.Pagamentos.Where (x => x.Email.Equals (User.Identity.Name));
            
            return View (ListaPagamentos.ToList ());

        }
        
        // GET: Pagamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagamentos pagamentos = db.Pagamentos.Find(id);
            if (pagamentos == null)
            {
                return HttpNotFound();
            }
            return View(pagamentos);
        }

        // GET: Pagamentos/Create
        public ActionResult Create()
        {
            ViewBag.QuotaFK = new SelectList(db.Quotas, "id_Quota", "Descricao");
            return View();
        }

        // POST: Pagamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Pagamento,Valor_Pagamento,data_Pagamento,ultima_Ano_Pago,QuotaFK")] Pagamentos pagamentos)
        {
            if (ModelState.IsValid)
            {
                db.Pagamentos.Add(pagamentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuotaFK = new SelectList(db.Quotas, "id_Quota", "Descricao", pagamentos.QuotaFK);
            return View(pagamentos);
        }

        // GET: Pagamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagamentos pagamentos = db.Pagamentos.Find(id);
            if (pagamentos == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuotaFK = new SelectList(db.Quotas, "id_Quota", "Descricao", pagamentos.QuotaFK);
            return View(pagamentos);
        }

        // POST: Pagamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Pagamento,Valor_Pagamento,data_Pagamento,ultima_Ano_Pago,QuotaFK")] Pagamentos pagamentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pagamentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuotaFK = new SelectList(db.Quotas, "id_Quota", "Descricao", pagamentos.QuotaFK);
            return View(pagamentos);
        }

        // GET: Pagamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagamentos pagamentos = db.Pagamentos.Find(id);
            if (pagamentos == null)
            {
                return HttpNotFound();
            }
            return View(pagamentos);
        }

        // POST: Pagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pagamentos pagamentos = db.Pagamentos.Find(id);
            db.Pagamentos.Remove(pagamentos);
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
        
        //public int novaFuncao() {

        //    var ListaQuotas = db.Pagamentos.Where (x => x.Email.Equals (User.Identity.Name));
        //    var aux = 0;

        //    foreach(var item in ListaQuotas) {
                
        //        aux = item.id_Quota;
        //    }
        //    return aux;
        //}
    }
}
