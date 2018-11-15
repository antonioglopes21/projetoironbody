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
    public class ContasReceberController : Controller
    {
        private IronBody.Models.IronBody db = new Models.IronBody();

        // GET: ContasReceber
        public ActionResult Index(string DataVencimento, string DataPagamento)
        {
            var contasReceber = db.ContasReceber.Include(c => c.Alunos);
            #region Filtro
            if (!string.IsNullOrEmpty(DataVencimento))
            {
                contasReceber = contasReceber.Where(c => c.dtVencimento == Convert.ToDateTime(DataVencimento));
            }
            else if (!string.IsNullOrEmpty(DataPagamento))
            {
                contasReceber = contasReceber.Where(c => c.dtVencimento == Convert.ToDateTime(DataPagamento));
            }
            else if (!string.IsNullOrEmpty(DataVencimento) && !string.IsNullOrEmpty(DataPagamento))
            {
                contasReceber = contasReceber.Where(c => c.dtVencimento == Convert.ToDateTime(DataVencimento)).Where(c=>c.dtPagamento == Convert.ToDateTime(DataPagamento));
            }
            #endregion

            if(Request.IsAjaxRequest())
                return PartialView("_ContasReceber", contasReceber.ToList());

            return View(contasReceber.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.idAluno = new SelectList(db.Alunos, "idAluno", "nome");
            return View();
        }

        // POST: ContasReceber/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idAluno,dtVencimento,valor,dtPagamento,desconto,juros,situação")] ContasReceber contasReceber)
        {
            if (ModelState.IsValid)
            {
                db.ContasReceber.Add(contasReceber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAluno = new SelectList(db.Alunos, "idAluno", "nome", contasReceber.idAluno);
            return View(contasReceber);
        }

        // GET: ContasReceber/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContasReceber contasReceber = db.ContasReceber.Find(id);
            if (contasReceber == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAluno = new SelectList(db.Alunos, "idAluno", "nome", contasReceber.idAluno);
            return View(contasReceber);
        }

        // POST: ContasReceber/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idAluno,dtVencimento,valor,dtPagamento,desconto,juros,situação")] ContasReceber contasReceber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contasReceber).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAluno = new SelectList(db.Alunos, "idAluno", "nome", contasReceber.idAluno);
            return View(contasReceber);
        }

        // GET: ContasReceber/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContasReceber contasReceber = db.ContasReceber.Find(id);
            if (contasReceber == null)
            {
                return HttpNotFound();
            }
            return View(contasReceber);
        }

        // POST: ContasReceber/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContasReceber contasReceber = db.ContasReceber.Find(id);
            db.ContasReceber.Remove(contasReceber);
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
