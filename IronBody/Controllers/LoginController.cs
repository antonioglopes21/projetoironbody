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
    public class LoginController : Controller
    {
        private IronBody.Models.IronBody db = new Models.IronBody();

        // GET: Login
        public ActionResult Index(string Alunos, string Instrutor)
        {
            var login = db.Login.Include(l => l.Alunos).Include(l => l.Funcionarios);

            #region Filtro
            if (!string.IsNullOrEmpty(Alunos))
            {
                login = login.Where(c => c.Alunos.nome.Contains(Alunos));
            }
            else if (!string.IsNullOrEmpty(Instrutor))
            {
                login = login.Where(c => c.Funcionarios.nome.Contains(Instrutor));
            }
            #endregion

            return View(login.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.idAluno = new SelectList(db.Alunos, "idAluno", "nome");
            ViewBag.idFuncionario = new SelectList(db.Funcionarios, "idFuncionario", "nome");
            return View();
        }

        // POST: Login/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idFuncionario,idAluno,usuario,senha,tpacesso")] Login login)
        {
            if (ModelState.IsValid)
            {
                db.Login.Add(login);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAluno = new SelectList(db.Alunos, "idAluno", "nome", login.idAluno);
            ViewBag.idFuncionario = new SelectList(db.Funcionarios, "idFuncionario", "nome", login.idFuncionario);
            return View(login);
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Login.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAluno = new SelectList(db.Alunos, "idAluno", "nome", login.idAluno);
            ViewBag.idFuncionario = new SelectList(db.Funcionarios, "idFuncionario", "nome", login.idFuncionario);
            return View(login);
        }

        // POST: Login/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idFuncionario,idAluno,usuario,senha,tpacesso")] Login login)
        {
            if (ModelState.IsValid)
            {
                db.Entry(login).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAluno = new SelectList(db.Alunos, "idAluno", "nome", login.idAluno);
            ViewBag.idFuncionario = new SelectList(db.Funcionarios, "idFuncionario", "nome", login.idFuncionario);
            return View(login);
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Login.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // POST: Login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Login login = db.Login.Find(id);
            db.Login.Remove(login);
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
