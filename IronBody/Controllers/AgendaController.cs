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
    public class AgendaController : Controller
    {
        private IronBody.Models.IronBody db = new Models.IronBody();

        // GET: Agenda
        public ActionResult Index(string Data)
        {
            var agenda = db.Agenda.Include(a => a.Alunos).Include(a => a.Funcionarios);
            
            #region Filtro
            if (!string.IsNullOrEmpty(Data))
            {
                agenda = agenda.Where(c => c.dtInicio == Convert.ToDateTime(Data));
            }
            #endregion

            return View(agenda.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.idAluno = new SelectList(db.Alunos, "idAluno", "nome");
            ViewBag.idProfessor = new SelectList(db.Funcionarios, "idFuncionario", "nome");
            return View();
        }

        // POST: Agenda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idProfessor,idAluno,dtInicio,atividade,dtFim")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                db.Agenda.Add(agenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAluno = new SelectList(db.Alunos, "idAluno", "nome", agenda.idAluno);
            ViewBag.idProfessor = new SelectList(db.Funcionarios, "idFuncionario", "nome", agenda.idProfessor);
            return View(agenda);
        }

        // GET: Agenda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda agenda = db.Agenda.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAluno = new SelectList(db.Alunos, "idAluno", "nome", agenda.idAluno);
            ViewBag.idProfessor = new SelectList(db.Funcionarios, "idFuncionario", "nome", agenda.idProfessor);
            return View(agenda);
        }

        // POST: Agenda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idProfessor,idAluno,dtInicio,atividade,dtFim")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agenda).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAluno = new SelectList(db.Alunos, "idAluno", "nome", agenda.idAluno);
            ViewBag.idProfessor = new SelectList(db.Funcionarios, "idFuncionario", "nome", agenda.idProfessor);
            return View(agenda);
        }

        // GET: Agenda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda agenda = db.Agenda.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            return View(agenda);
        }

        // POST: Agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agenda agenda = db.Agenda.Find(id);
            db.Agenda.Remove(agenda);
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
