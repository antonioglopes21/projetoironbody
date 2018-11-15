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
    public class AlunoController : Controller
    {
        private IronBody.Models.IronBody db = new Models.IronBody();

        // GET: Aluno
        public ActionResult Index(string Alunos,string Instrutor)
        {
            var alunos = db.Alunos.Include(a => a.AvaliacaoFisica).Include(a => a.Funcionarios).Include(a => a.Funcionarios1);
            
            #region Filtro
            if (!string.IsNullOrEmpty(Alunos))
            {
                alunos = alunos.Where(c => c.nome.Contains(Alunos));
            }
            else if (!string.IsNullOrEmpty(Instrutor))
            {
                alunos = alunos.Where(c => c.Funcionarios.nome.Contains(Instrutor));
            }
            #endregion

            return View(alunos.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.idAluno = new SelectList(db.AvaliacaoFisica, "id", "id");
            ViewBag.idProfessor = new SelectList(db.Funcionarios, "idFuncionario", "nome");
            ViewBag.idProfessor = new SelectList(db.Funcionarios, "idFuncionario", "nome");
            return View();
        }

        // POST: Aluno/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAluno,idProfessor,nome,cpf,dtNascimento,cep,estado,cidade,bairro,rua,email,celular")] Alunos alunos)
        {
            if (ModelState.IsValid)
            {
                db.Alunos.Add(alunos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAluno = new SelectList(db.AvaliacaoFisica, "id", "id", alunos.idAluno);
            ViewBag.idProfessor = new SelectList(db.Funcionarios, "idFuncionario", "nome", alunos.idProfessor);
            ViewBag.idProfessor = new SelectList(db.Funcionarios, "idFuncionario", "nome", alunos.idProfessor);
            return View(alunos);
        }

        // GET: Aluno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alunos alunos = db.Alunos.Find(id);
            if (alunos == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAluno = new SelectList(db.AvaliacaoFisica, "id", "id", alunos.idAluno);
            ViewBag.idProfessor = new SelectList(db.Funcionarios, "idFuncionario", "nome", alunos.idProfessor);
            ViewBag.idProfessor = new SelectList(db.Funcionarios, "idFuncionario", "nome", alunos.idProfessor);
            return View(alunos);
        }

        // POST: Aluno/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Alunos alunos, int id)
        {
            if (ModelState.IsValid)
            {
                alunos.idAluno = id;
                
                db.Entry(alunos).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAluno = new SelectList(db.AvaliacaoFisica, "id", "id", alunos.idAluno);
            ViewBag.idProfessor = new SelectList(db.Funcionarios, "idFuncionario", "nome", alunos.idProfessor);
            ViewBag.idProfessor = new SelectList(db.Funcionarios, "idFuncionario", "nome", alunos.idProfessor);
            return View(alunos);
        }

        // GET: Aluno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alunos alunos = db.Alunos.Find(id);
            if (alunos == null)
            {
                return HttpNotFound();
            }
            return View(alunos);
        }

        // POST: Aluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alunos alunos = db.Alunos.Find(id);
            db.Alunos.Remove(alunos);
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
