using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IronBody.Models;

namespace IronBody.Controllers
{
    public class AvaliacaoFisicaController : Controller
    {
        private IronBody.Models.IronBody db = new Models.IronBody();

        // GET: AvaliacaoFisica
        public ActionResult Index(string Data, string Alunos, string Instrutor)
        {
            var avaliacaoFisica = db.AvaliacaoFisica.Include(a => a.Alunos).Include(a => a.Funcionarios);
            #region Filtro
            if (!string.IsNullOrEmpty(Data))
            {
                avaliacaoFisica = avaliacaoFisica.Where(c => c.data == Convert.ToDateTime(Data));
            }
            else if (!string.IsNullOrEmpty(Alunos))
            {
                avaliacaoFisica = avaliacaoFisica.Where(c => c.Alunos.nome.Contains(Alunos));
            }
            else if (!string.IsNullOrEmpty(Instrutor))
            {
                avaliacaoFisica = avaliacaoFisica.Where(c => c.Funcionarios.nome.Contains(Instrutor));
            }
            else if (!string.IsNullOrEmpty(Data) && !string.IsNullOrEmpty(Alunos))
            {
                avaliacaoFisica = avaliacaoFisica.Where(c => c.data == Convert.ToDateTime(Data)).Where(c => c.Alunos.nome.Contains(Alunos));
            }
            else if (!string.IsNullOrEmpty(Data) && !string.IsNullOrEmpty(Instrutor))
            {
                avaliacaoFisica = avaliacaoFisica.Where(c => c.data == Convert.ToDateTime(Data)).Where(c => c.Funcionarios.nome.Contains(Instrutor));
            }
            else if (!string.IsNullOrEmpty(Instrutor) && !string.IsNullOrEmpty(Alunos))
            {
                avaliacaoFisica = avaliacaoFisica.Where(c => c.Funcionarios.nome.Contains(Instrutor)).Where(c => c.Alunos.nome.Contains(Alunos)); 
            }
            else if (!string.IsNullOrEmpty(Data) && !string.IsNullOrEmpty(Instrutor) && !string.IsNullOrEmpty(Alunos))
            {
                avaliacaoFisica = avaliacaoFisica.Where(c => c.data == Convert.ToDateTime(Data)).Where(c => c.Funcionarios.nome.Contains(Instrutor)).Where(c => c.Alunos.nome.Contains(Alunos));
            }
            #endregion

            return View(avaliacaoFisica.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.idAluno = new SelectList(db.Alunos, "idAluno", "nome");
            ViewBag.idFuncionario = new SelectList(db.Funcionarios, "idFuncionario", "nome");
            return View();
        }

        // POST: AvaliacaoFisica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProfessor,idAluno,data,peso,pcentGordura,pcentGBiceps,pcentGCosta,pcentGLado,pcentGBarriga,pcentMBiceps,pcentMTriceps,pcentMOmbro,pcentMPeito,pcentMBarriga,pcentMCoxa,pcentMPanturrilha")] AvaliacaoFisica avaliacaoFisica)
        {
            if (ModelState.IsValid)
            {
                db.AvaliacaoFisica.Add(avaliacaoFisica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAluno = new SelectList(db.Alunos, "idAluno", "nome", avaliacaoFisica.idAluno);
            ViewBag.idFuncionario = new SelectList(db.Funcionarios, "idFuncionario", "nome", avaliacaoFisica.idProfessor);
            return View(avaliacaoFisica);
        }

        // GET: AvaliacaoFisica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvaliacaoFisica avaliacaoFisica = db.AvaliacaoFisica.Find(id);
            if (avaliacaoFisica == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAluno = new SelectList(db.Alunos, "idAluno", "nome", avaliacaoFisica.idAluno);
            ViewBag.idFuncionario = new SelectList(db.Funcionarios, "idFuncionario", "nome", avaliacaoFisica.idProfessor);
            return View(avaliacaoFisica);
        }

        // POST: AvaliacaoFisica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idProfessor,idAluno,data,peso,pcentGordura,pcentGBiceps,pcentGCosta,pcentGLado,pcentGBarriga,pcentMBiceps,pcentMTriceps,pcentMOmbro,pcentMPeito,pcentMBarriga,pcentMCoxa,pcentMPanturrilha")] AvaliacaoFisica avaliacaoFisica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(avaliacaoFisica).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAluno = new SelectList(db.Alunos, "idAluno", "nome", avaliacaoFisica.idAluno);
            ViewBag.idFuncionario = new SelectList(db.Funcionarios, "idFuncionario", "nome", avaliacaoFisica.idProfessor);
            return View(avaliacaoFisica);
        }

        // GET: AvaliacaoFisica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvaliacaoFisica avaliacaoFisica = db.AvaliacaoFisica.Find(id);
            if (avaliacaoFisica == null)
            {
                return HttpNotFound();
            }
            return View(avaliacaoFisica);
        }

        // POST: AvaliacaoFisica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AvaliacaoFisica avaliacaoFisica = db.AvaliacaoFisica.Find(id);
            db.AvaliacaoFisica.Remove(avaliacaoFisica);
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
