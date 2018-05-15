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
    public class PessoasController : Controller
    {
        private SociosDB db = new SociosDB();

        // GET: Pessoas
        public ActionResult Index(string pesquisa)
        {
            //SociosDB db = new SociosDB();
            
            return View(db.Pessoas.Where(x=>x.Nome.StartsWith(pesquisa)|| pesquisa==null).ToList());
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoas pessoas = db.Pessoas.Find(id);
            if (pessoas == null)
            {
                return HttpNotFound();
            }
            return View(pessoas);
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pessoa_ID,Nome,data_Nascimento,Sexo,Morada,Codigo_Postal,Nacionalidade,Email,Foto,numeroTelefone,numeroTelemovel,dataEntradaClube")]
        HttpPostedFileBase UploadFoto,Pessoas pessoas)
        {
            int novoID = 0;

            if(db.Pessoas.Count () == 0) {
                novoID = 1;
            }
            else {

                novoID = db.Pessoas.Max (p => p.Pessoa_ID) + 1;
            }
            pessoas.Pessoa_ID = novoID;

            string nomeFotografia = "Pessoas_" + novoID + ".jpg";

            string caminhoParaFotografia = Path.Combine (Server.MapPath ("~/Imagens/"),nomeFotografia);

            if(UploadFoto != null) {

                pessoas.Foto = nomeFotografia;

            }
            else {
                ModelState.AddModelError ("","Não foi fornecida uma imagem..."); // gera MSG de erro
                return View (pessoas);
            }
            if(ModelState.IsValid) {
                db.Pessoas.Add (pessoas);
                db.SaveChanges ();
                UploadFoto.SaveAs (caminhoParaFotografia);
                return RedirectToAction ("Index");
            }

            return View (pessoas);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoas pessoas = db.Pessoas.Find(id);
            if (pessoas == null)
            {
                return HttpNotFound();
            }
            return View(pessoas);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pessoa_ID,Nome,data_Nascimento,Sexo,Morada,Codigo_Postal,Nacionalidade,Email,Foto,numeroTelefone,numeroTelemovel,dataEntradaClube")] Pessoas pessoas)
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoas pessoas = db.Pessoas.Find(id);
            if (pessoas == null)
            {
                return HttpNotFound();
            }
            return View(pessoas);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pessoas pessoas = db.Pessoas.Find(id);

            try {
                db.Pessoas.Remove (pessoas);
                db.SaveChanges ();
                return RedirectToAction ("Index");
            }
            catch(Exception) {
                ModelState.AddModelError ("",String.Format ("nao foi possivel"));
            }
            return View (pessoas);
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
