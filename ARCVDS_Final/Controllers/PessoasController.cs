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
    public class PessoasController : Controller {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pessoas
        public ActionResult Index(string pesquisa) {
            //return View(db.Pessoas.ToList());

            if(!User.IsInRole("Admin") && !User.IsInRole("Funcionarios") && !User.IsInRole("Socios")) {
                return RedirectToAction("AcessoRestrito", "Erros");
            }
            if(User.IsInRole("Socios")) {
                return View(db.Pessoas.Where(s => s.Email.Equals(User.Identity.Name)).ToList());
            }
            else {
                if(!string.IsNullOrEmpty(pesquisa)) {
                    return View(db.Pessoas.Where(x => x.Nome.StartsWith(pesquisa.ToLower())).ToList());
                }
                else {
                    var pessoas = db.Pessoas.Select(p => p).ToList();
                    return View(pessoas);
                }
            }
        }
        //[Authorize(Roles ="Socios")]
        public ActionResult EditDados() {

            if(User.IsInRole("Socios")) {
                return View(db.Pessoas.Where(s => s.Email.Equals(User.Identity.Name)).ToList());
            }
            else if(User.IsInRole("Admin") || User.IsInRole("Funcionarios")) {
                return View(db.Pessoas.ToList());
            }
            else {
                return RedirectToAction("AcessoRestrito", "Erros");
            }
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(int? id) {
            if(id == null) {
                return RedirectToAction("Index");
            }
            Pessoas pessoas = db.Pessoas.Find(id);
            if(pessoas == null) {
                return RedirectToAction("Index");
            }
            if(!User.IsInRole("Admin") && !User.IsInRole("Funcionarios") && !User.IsInRole("Socios")) {
                return RedirectToAction("AcessoRestrito", "Erros");
            }
            else {
                return View(pessoas);
            }
        }

        // GET: Pessoas/Create
        public ActionResult Create() {
            if(!User.IsInRole("Admin") && !User.IsInRole("Funcionarios")) {
                return RedirectToAction("AcessoRestrito", "Erros");
            }
            else {
                //return View (db.Beneficios.ToList ());
                return View();
            }
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,data_Nascimento,Sexo,Morada,Codigo_Postal,Nacionalidade,Email,numeroTelefone,numeroTelemovel,dataEntradaClube,UserName")] Pessoas pessoas, string data_Nascimento) {

            //try and cactch



            pessoas.dataEntradaClube = DateTime.Today;

            DateTime datal = DateTime.Parse(data_Nascimento);
            pessoas.data_Nascimento = datal;

            pessoas.UserName = pessoas.Email;

            int novaPessoa = 0;
            try {
                novaPessoa = db.Pessoas.Max(p => p.Id) + 1;
            }
            catch(Exception) {
                novaPessoa = 1;
            }
            pessoas.Id = novaPessoa;

            if(ModelState.IsValid) {
                db.Pessoas.Add(pessoas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoas);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int? id) {
            if(id == null) {
                return RedirectToAction("Edit");
            }

            var userId = db.Pessoas.Where(x => x.Email.Equals(User.Identity.Name)).FirstOrDefault().Id;

            if(id != Convert.ToInt32(userId) && !User.IsInRole("Admin")) {
                return RedirectToAction("AcessoRestrito", "Erros");
            }

            Pessoas pessoas = db.Pessoas.Find(id);

            if(pessoas == null) {
                return RedirectToAction("Index");
            }
            if(!User.IsInRole("Admin") && !User.IsInRole("Funcionarios") && !User.IsInRole("Socios")) {
                return RedirectToAction("AcessoRestrito", "Erros");
                //return RedirectToAction ("Index","Home");
            }
            else {
                return View(pessoas);
            }
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles =("Socios, Funcionarios,Admin"))]
        public ActionResult Edit([Bind(Include = "Id,Nome,data_Nascimento,Sexo,Morada,Codigo_Postal,Nacionalidade,Email,numeroTelefone,numeroTelemovel,dataEntradaClube,UserName")] Pessoas pessoas, FormCollection formCollection) {

            ////User currentUser = (User)Session["CurrentUser"];
            //string endEmail = TempData["socioUsername"].ToString();
            //ApplicationUser app = db.Users.Where(x => x.UserName.Equals(endEmail)).SingleOrDefault();

            //if(app != null) {
            //    // atualiza o novo username de um sócio na tabela dos dados da conta
            //    app.UserName = pessoas.Email;
            //}

            pessoas.data_Nascimento = DateTime.Parse(formCollection["data_Nascimento"]);
            pessoas.dataEntradaClube = DateTime.Parse(formCollection["dataEntradaClube"]);

            if(ModelState.IsValid) {
                db.Entry(pessoas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoas);
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(int? id) {
            if(id == null) {
                return RedirectToAction("Index");
            }
            Pessoas pessoas = db.Pessoas.Find(id);
            if(pessoas == null) {
                return RedirectToAction("Index");
            }
            if(!User.IsInRole("Admin") && !User.IsInRole("Funcionarios")) {
                return RedirectToAction("AcessoRestrito", "Erros");
            }
            else {
                return View(pessoas);
            }
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Pessoas pessoas = db.Pessoas.Find(id);

            Quotas quotas = new Quotas();

            //var quotasPessoa = db.Quotas.Where(q => q.PessoaFK == id).ToList();

            //List<Pagamentos> pagPessoa = new List<Pagamentos>();

            //foreach(var q in quotasPessoa) {
            //    pagPessoa.Add(db.Pagamentos.FirstOrDefault(qp => qp.QuotaFK == q.id_Quota));
            //}

            //db.Pagamentos.RemoveRange(pagPessoa);

            //db.Quotas.RemoveRange(quotasPessoa);
            //db.Pessoas.RemoveRange(pessoas.ListaBeneficios);
            db.Pessoas.Remove(pessoas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if(disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
