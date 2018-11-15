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
    public class ContasPagarController : Controller
    {
        private IronBody.Models.IronBody db = new Models.IronBody();

        // GET: ContasPagar
        public ActionResult Index(string DataVencimento, string DataPagamento)
        {
            var contasPagar = db.ContasPagar.AsQueryable();
            #region Filtro
            if (!string.IsNullOrEmpty(DataVencimento))
            {
                contasPagar = contasPagar.Where(c => c.dtVencimento == Convert.ToDateTime(DataVencimento));
            }
            else if (!string.IsNullOrEmpty(DataPagamento))
            {
                contasPagar = contasPagar.Where(c => c.dtVencimento == Convert.ToDateTime(DataPagamento));
            }
            else if (!string.IsNullOrEmpty(DataVencimento) && !string.IsNullOrEmpty(DataPagamento))
            {
                contasPagar = contasPagar.Where(c => c.dtVencimento == Convert.ToDateTime(DataVencimento)).Where(c => c.dtPagamento == Convert.ToDateTime(DataPagamento));
            }
            #endregion

            return View(db.ContasPagar.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: ContasPagar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fornecedor,dtVencimento,valor,dtPagamento,desconto,juros,situação")] ContasPagar contasPagar)
        {
            if (ModelState.IsValid)
            {
                db.ContasPagar.Add(contasPagar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contasPagar);
        }

        // GET: ContasPagar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContasPagar contasPagar = db.ContasPagar.Find(id);
            if (contasPagar == null)
            {
                return HttpNotFound();
            }
            return View(contasPagar);
        }

        // POST: ContasPagar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fornecedor,dtVencimento,valor,dtPagamento,desconto,juros,situação")] ContasPagar contasPagar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contasPagar).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contasPagar);
        }

        // GET: ContasPagar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContasPagar contasPagar = db.ContasPagar.Find(id);
            if (contasPagar == null)
            {
                return HttpNotFound();
            }
            return View(contasPagar);
        }

        // POST: ContasPagar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContasPagar contasPagar = db.ContasPagar.Find(id);
            db.ContasPagar.Remove(contasPagar);
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
