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
                ViewBag.ListaObjetosDeB = db.Beneficios.OrderBy(b => b.Categoria).ToList();
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
                ViewBag.ListaObjetosDeB = db.Beneficios.OrderBy(b => b.Categoria).ToList();
                return View();
            }
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,data_Nascimento,Sexo,Morada,Codigo_Postal,Nacionalidade,Email,numeroTelefone,numeroTelemovel,dataEntradaClube,UserName")] Pessoas pessoas, string data_Nascimento, string[] opcoesEscolhidasDeB) {

            pessoas.dataEntradaClube = DateTime.Today;

            DateTime datal = DateTime.Parse(data_Nascimento);
            pessoas.data_Nascimento = datal;

            pessoas.UserName = pessoas.Email;

            if(opcoesEscolhidasDeB == null) {
                ModelState.AddModelError("", "Necessita escolher pelo menos um valor de B para associar ao seu objeto de A.");
                // gerar a lista de objetos de B que podem ser associados a A
                ViewBag.ListaObjetosDeB = db.Beneficios.OrderBy(b => b.Categoria).ToList();
                // devolver controlo à View
                return View(pessoas);
            }

            int novaPessoa = 0;
            try {
                novaPessoa = db.Pessoas.Max(p => p.Id) + 1;
            }
            catch(Exception) {
                novaPessoa = 1;
            }
            pessoas.Id = novaPessoa;

            List<Beneficios> listaDeObjetosDeBEscolhidos = new List<Beneficios>();
            foreach(string item in opcoesEscolhidasDeB) {
                //procurar o objeto de B
                Beneficios b = db.Beneficios.Find(Convert.ToInt32(item));
                // adicioná-lo à lista
                listaDeObjetosDeBEscolhidos.Add(b);
            }

            pessoas.ListaBeneficios = listaDeObjetosDeBEscolhidos;

            if(ModelState.IsValid) {
                db.Pessoas.Add(pessoas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoas);

        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int? id) {

            //ViewBag.ListaObjetosDeB = db.Beneficios.OrderBy(b => b.Categoria).ToList();
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

                ViewBag.ListaObjetosDeB = db.Beneficios.OrderBy(b => b.Categoria).ToList();
                return View(pessoas);
            }
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles =("Socios, Funcionarios,Admin"))]
        public ActionResult Edit([Bind(Include = "Id,Nome,data_Nascimento,Sexo,Morada,Codigo_Postal,Nacionalidade,Email,numeroTelefone,numeroTelemovel,dataEntradaClube,UserName")] Pessoas pessoas, FormCollection formCollection, string[] opcoesEscolhidasDeB) {

            ////User currentUser = (User)Session["CurrentUser"];
            //string endEmail = TempData["socioUsername"].ToString();
            //ApplicationUser app = db.Users.Where(x => x.UserName.Equals(endEmail)).SingleOrDefault();

            //if(app != null) {
            //    // atualiza o novo username de um sócio na tabela dos dados da conta
            //    app.UserName = pessoas.Email;
            //}

            pessoas.data_Nascimento = DateTime.Parse(formCollection["data_Nascimento"]);
            pessoas.dataEntradaClube = DateTime.Parse(formCollection["dataEntradaClube"]);

            var aa = db.Pessoas.Include(b => b.ListaBeneficios).Where(b => b.Id == pessoas.Id).SingleOrDefault();


            if(ModelState.IsValid) {

                aa.Codigo_Postal = pessoas.Codigo_Postal;
                aa.data_Nascimento = pessoas.data_Nascimento;
                aa.Email = pessoas.Email;
                aa.Morada = pessoas.Morada;
                aa.Nacionalidade = pessoas.Nacionalidade;
                aa.Nome = pessoas.Nome;
                aa.numeroTelefone = pessoas.numeroTelefone;
                aa.numeroTelemovel = pessoas.numeroTelemovel;


                //db.Entry(pessoas).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
            else {
                ViewBag.ListaObjetosDeB = db.Beneficios.OrderBy(b => b.Categoria).ToList();
                return View(pessoas);
            }
            if(TryUpdateModel(aa, "", new string[] { nameof(aa.Codigo_Postal), nameof(aa.data_Nascimento), nameof(aa.ListaBeneficios), nameof(aa.Email), nameof(aa.Morada), nameof(aa.Nacionalidade), nameof(aa.Nome), nameof(aa.numeroTelefone), nameof(aa.numeroTelemovel) })) {

                // obter a lista de elementos de B
                var elementosDeB = db.Beneficios.ToList();

                if(opcoesEscolhidasDeB != null) {
                    // se existirem opções escolhidas, vamos associá-las
                    foreach(var bb in elementosDeB) {
                        if(opcoesEscolhidasDeB.Contains(bb.id_Beneficio.ToString())) {
                            // se uma opção escolhida ainda não está associada, cria-se a associação
                            if(!aa.ListaBeneficios.Contains(bb)) {
                                aa.ListaBeneficios.Add(bb);
                            }
                        }
                        else {
                            // caso exista associação para uma opção que não foi escolhida, 
                            // remove-se essa associação
                            aa.ListaBeneficios.Remove(bb);
                        }
                    }
                }
                else {
                    // não existem opções escolhidas!
                    // vamos eliminar todas as associações
                    foreach(var bb in elementosDeB) {
                        if(aa.ListaBeneficios.Contains(bb)) {
                            aa.ListaBeneficios.Remove(bb);
                        }
                    }
                }
                db.SaveChanges();
                //return View(pessoas);
            }

            ViewBag.ListaObjetosDeB = db.Beneficios.OrderBy(b => b.Categoria).ToList();
            return RedirectToAction("Index");
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
