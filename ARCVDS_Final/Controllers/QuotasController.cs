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
    public class QuotasController : Controller
    {
        //private SociosDB db = new SociosDB();

        private ApplicationDbContext db = new ApplicationDbContext ();

        // GET: Quotas
        public ActionResult Index()
        {
            var quotas = db.Quotas.Include(q => q.Pessoa);

            if(!User.IsInRole ("Admin") && !User.IsInRole ("Funcionarios")) {
                return RedirectToAction ("AcessoRestrito", "Erros");
            }
            else {
                return View (db.Quotas.ToList ());
            }

            //return View (db.Quotas.ToList ());
        }
        // GET: Quotas
        public ActionResult QuotasUser() {

            if(!User.IsInRole ("Admin") && !User.IsInRole ("Funcionarios") && !User.IsInRole("Socios")) {
                return RedirectToAction ("AcessoRestrito", "Erros");
            }

            if (User.IsInRole("Admin") && User.IsInRole ("Funcionarios")) {

                var quotas2 = db.Quotas.Include (q => q.Pessoa);
                return View (quotas2.ToList ());
            }

            var batatas = GetLoggedUserId();
            var quotas = db.Quotas.Where(x => x.PessoaFK == batatas);
            return View (quotas.ToList ());
        }
        // GET: Quotas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction ("Index");
            }
            Quotas quotas = db.Quotas.Find(id);
            if (quotas == null)
            {
                return RedirectToAction ("Index");
            }
            if(!User.IsInRole ("Admin") && !User.IsInRole ("Funcionarios") && !User.IsInRole("Socios")) {
                return RedirectToAction ("AcessoRestrito", "Erros");
            }
            else {
                return View (quotas);
            }
        }

        // GET: Quotas/Create
        public ActionResult Create()
        {
            ViewBag.PessoaFK = new SelectList(db.Pessoas, "Id", "Nome");
            if(!User.IsInRole("Admin") && !User.IsInRole("Funcionarios")) {
                return RedirectToAction("AcessoRestrito", "Erros");
            }
            else {
                //return View (db.Beneficios.ToList ());
                return View();
            }
        }

        // POST: Quotas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Quota,ano_Quota,Valor_Quota,Descricao,Paga,PessoaFK")] Quotas quotas, string DataQuota)
        {

            quotas.ano_Quota = DateTime.Today;

            if (ModelState.IsValid)
            {
                db.Quotas.Add(quotas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            return View(quotas);
        }

        // GET: Quotas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction ("Index");
            }
            Quotas quotas = db.Quotas.Find(id);
            if (quotas == null)
            {
                return RedirectToAction ("Index");
            }
            
            if(!User.IsInRole ("Admin") && !User.IsInRole ("Funcionarios")) {
                return RedirectToAction ("AcessoRestrito", "Erros");
            }
            else {
                return View (quotas);
            }
        }

        // POST: Quotas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Quota,ano_Quota,Valor_Quota,Descricao,Paga,PessoaFK")] Quotas quotas, FormCollection formCollection)
        {
            //quotas.Valor_Quota = Convert.ToDecimal(quotas.Valor_Quota);
            /*
            var ValorQuota = db.Quotas.Where(p => p.Valor_Quota == 0);

            if(ValorQuota == null) {
                var Paga = db.Quotas.Where(x => x.Paga == true);
                db.SaveChanges();
            }
            */

            quotas.ano_Quota = DateTime.Parse(formCollection["ano_Quota"]);

            if (ModelState.IsValid)
            {
                db.Entry(quotas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quotas);
        }

        // GET: Quotas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction ("Index");
            }
            Quotas quotas = db.Quotas.Find(id);
            if (quotas == null)
            {
                return RedirectToAction ("Index");
            }
            if(!User.IsInRole ("Admin") && !User.IsInRole ("Funcionarios")) {
                return RedirectToAction ("AcessoRestrito", "Erros");
            }
            else {
                return View (quotas);
            }
        }

        // POST: Quotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Quotas quotas = db.Quotas.Find(id);
            //var PagamentosUser = db.Pagamentos.Where(x => x.QuotaFK == id).ToList();

            db.Pagamentos.RemoveRange(quotas.ListaPagamentos);
            
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

        public int GetLoggedUserId()
        {
            var listaUser = db.Pessoas.Where(x => x.Email.Equals(User.Identity.Name));

            var aux = 0;

            foreach (var item in listaUser)
            {
                aux = item.Id;

            }
            return aux;
        }

    }
}
