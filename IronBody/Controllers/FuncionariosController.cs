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
    public class FuncionariosController : Controller
    {
        private IronBody.Models.IronBody db = new Models.IronBody();

        // GET: Funcionarios
        public ActionResult Index(string Funcionario)
        {
            var funcionarios = db.Funcionarios.AsQueryable();
            if (!string.IsNullOrEmpty(Funcionario))
                funcionarios = funcionarios.Where(f => f.nome.Contains(Funcionario));
            funcionarios = funcionarios.OrderBy(f => f.nome);

            return View(funcionarios.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.idFuncionario = new SelectList(db.AvaliacaoFisica, "id", "id");
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFuncionario,nome,cpf,dtNascimento,salario,cargo,cep,estado,cidade,bairro,rua,celular,email")] Funcionarios funcionarios)
        {
            if (ModelState.IsValid)
            {
                db.Funcionarios.Add(funcionarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idFuncionario = new SelectList(db.AvaliacaoFisica, "id", "id", funcionarios.idFuncionario);
            return View(funcionarios);
        }

        // GET: Funcionarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionarios funcionarios = db.Funcionarios.Find(id);
            if (funcionarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFuncionario = new SelectList(db.AvaliacaoFisica, "id", "id", funcionarios.idFuncionario);
            return View(funcionarios);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFuncionario,nome,cpf,dtNascimento,salario,cargo,cep,estado,cidade,bairro,rua,celular,email")] Funcionarios funcionarios, int id)
        {
            if (ModelState.IsValid)
            {
                funcionarios.idFuncionario = id;
                db.Entry(funcionarios).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFuncionario = new SelectList(db.AvaliacaoFisica, "id", "id", funcionarios.idFuncionario);
            return View(funcionarios);
        }

        // GET: Funcionarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionarios funcionarios = db.Funcionarios.Find(id);
            if (funcionarios == null)
            {
                return HttpNotFound();
            }
            return View(funcionarios);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Funcionarios funcionarios = db.Funcionarios.Find(id);
            db.Funcionarios.Remove(funcionarios);
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
