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
    public class TreinoController : Controller
    {
        private IronBody.Models.IronBody db = new Models.IronBody();

        // GET: Treino
        public ActionResult Index(string Alunos, string Instrutor)
        {
            var treinos = db.Treinos.Include(t => t.Alunos).Include(t => t.Funcionarios);

            #region Filtro
            if (!string.IsNullOrEmpty(Alunos))
            {
                treinos = treinos.Where(c => c.Alunos.nome.Contains(Alunos));
            }
            else if (!string.IsNullOrEmpty(Instrutor))
            {
                treinos = treinos.Where(c => c.Funcionarios.nome.Contains(Instrutor));
            }
            else if (!string.IsNullOrEmpty(Instrutor) && !string.IsNullOrEmpty(Alunos))
            {
                treinos = treinos.Where(c => c.Funcionarios.nome.Contains(Instrutor)).Where(c => c.Alunos.nome.Contains(Alunos));
            }
            #endregion

            return View(treinos.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.idAluno = new SelectList(db.Alunos, "idAluno", "nome");
            ViewBag.idProfessor = new SelectList(db.Funcionarios, "idFuncionario", "nome");
            return View();
        }

        // POST: Treino/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idProfessor,idAluno,data,duracao,programa,intervalo,freqTreino,objetivo,esteira,esteiraTempo,esteiraVelocidade,ergometrica,ergometricaTempo,ergometricaVelocidade,elipticon,elipticonTempo,elipticonVelocidade,agachamento,agachamentoOrdem,agachamentoSerie,agachamentoRepet,agachamentoCarga,legPressOrdem,legPress,legPressSerie,legPressRepet,legPressCarga,hackMachineOrdem,hackMachine,hackMachineSerie,hackMachineRepet,hackMachineCarga,avancoOrdem,avanco,avancoSerie,avancoRepet,avancoCarga,flexoraOrdem,flexora,flexoraSerie,flexoraRepet,flexoraCarga,flexaoOrdem,flexao,flexaoSerie,flexaoRepet,flexaoCarga,panturrilhaOrdem,panturrilha,panturrilhaSerie,panturrilhaRepet,panturrilhaCarga,lvtmentoTerraOrdem,lvtmentoTerra,lvtmentoTerraSerie,lvtmentoTerraRepet,lvtmentoTerraCarga,abducaoOrdem,abducao,abducaoSerie,abducaoRepet,abducaoCarga,aducaoOrdem,aducao,aducaoSerie,aducaoRepet,aducaoCarga,gluteosOrdem,gluteos,gluteosSerie,gluteosRepet,gluteosCarga,retoOrdem,reto,retoSerie,retoRepet,retoCarga,obliquoOrdem,obliquo,obliquoSerie,obliquoRepet,obliquoCarga,extsaoLombarOrdem,extsaoLombar,extsaoLombarSerie,extsaoLombarRepet,extsaoLombarCarga,pranchaOrdem,prancha,pranchaSerie,pranchaRepet,pranchaCarga,roldDorsalOrdem,roldDorsal,roldDorsalSerie,roldDorsalRepet,roldDorsalCarga,rmdSentadaOrdem,rmdSentada,rmdSentadaSerie,rmdSentadaRepet,rmdSentadaCarga,remadaOrdem,remada,remadaSerie,remadaRepet,remadaCarga,puxadaOrdem,puxada,puxadaSerie,puxadaRepet,puxadaCarga,desenvOrdem,desenv,desenvSerie,desenvRepet,desenvCarga,elevacaoOrdem,elevacao,elevacaoSerie,elevacaoRepet,elevacaoCarga,remadaPeOrdem,remadaPe,remadaPeSerie,remadaPeRepet,remadaPeCarga,supinoUmOrdem,supinoUm,supinoUmSerie,supinoUmRepet,supinoUmCarga,supinoDoisOrdem,supinoDois,supinoDoisSerie,supinoDoisRepet,supinoDoisCarga,crucifixoOrdem,crucifixo,crucifixoSerie,crucifixorRepet,crucifixoCarga,crossOverOrdem,crossOver,crossOverSerie,crossOverRepet,crossOverCarga,voadorOrdem,voador,voadorSerie,voadorRepet,voadorCarga,roscaOrdem,rosca,roscaSerie,roscaRepet,roscaCarga,roscaDiretaOrdem,roscaDireta,roscaDiretaSerie,roscaDiretaRepet,roscaDiretaCarga,roscaScottOrdem,roscaScott,roscaScottSerie,roscaScottRepet,roscaScottCarga,roscaConcentradaOrdem,roscaConcentrada,roscaConcentradaSerie,roscaConcentradaRepet,roscaConcentradaCarga,testaOrdem,testa,testaSerie,testaRepet,testaCarga,pressFrancesOrdem,pressFrances,pressFrancesSerie,pressFrancesRepet,pressFrancesCarga,roldTricepsOrdem,roldTriceps,roldTricepsSerie,roldTricepsRepet,roldTricepsCarga,observações")] Treinos treinos)
        {
            if (ModelState.IsValid)
            {
                db.Treinos.Add(treinos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAluno = new SelectList(db.Alunos, "idAluno", "nome", treinos.idAluno);
            ViewBag.idProfessor = new SelectList(db.Funcionarios, "idFuncionario", "nome", treinos.idProfessor);
            return View(treinos);
        }

        // GET: Treino/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treinos treinos = db.Treinos.Find(id);
            if (treinos == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAluno = new SelectList(db.Alunos, "idAluno", "nome", treinos.idAluno);
            ViewBag.idProfessor = new SelectList(db.Funcionarios, "idFuncionario", "nome", treinos.idProfessor);
            return View(treinos);
        }

        // POST: Treino/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idProfessor,idAluno,data,duracao,programa,intervalo,freqTreino,objetivo,esteira,esteiraTempo,esteiraVelocidade,ergometrica,ergometricaTempo,ergometricaVelocidade,elipticon,elipticonTempo,elipticonVelocidade,agachamento,agachamentoOrdem,agachamentoSerie,agachamentoRepet,agachamentoCarga,legPressOrdem,legPress,legPressSerie,legPressRepet,legPressCarga,hackMachineOrdem,hackMachine,hackMachineSerie,hackMachineRepet,hackMachineCarga,avancoOrdem,avanco,avancoSerie,avancoRepet,avancoCarga,flexoraOrdem,flexora,flexoraSerie,flexoraRepet,flexoraCarga,flexaoOrdem,flexao,flexaoSerie,flexaoRepet,flexaoCarga,panturrilhaOrdem,panturrilha,panturrilhaSerie,panturrilhaRepet,panturrilhaCarga,lvtmentoTerraOrdem,lvtmentoTerra,lvtmentoTerraSerie,lvtmentoTerraRepet,lvtmentoTerraCarga,abducaoOrdem,abducao,abducaoSerie,abducaoRepet,abducaoCarga,aducaoOrdem,aducao,aducaoSerie,aducaoRepet,aducaoCarga,gluteosOrdem,gluteos,gluteosSerie,gluteosRepet,gluteosCarga,retoOrdem,reto,retoSerie,retoRepet,retoCarga,obliquoOrdem,obliquo,obliquoSerie,obliquoRepet,obliquoCarga,extsaoLombarOrdem,extsaoLombar,extsaoLombarSerie,extsaoLombarRepet,extsaoLombarCarga,pranchaOrdem,prancha,pranchaSerie,pranchaRepet,pranchaCarga,roldDorsalOrdem,roldDorsal,roldDorsalSerie,roldDorsalRepet,roldDorsalCarga,rmdSentadaOrdem,rmdSentada,rmdSentadaSerie,rmdSentadaRepet,rmdSentadaCarga,remadaOrdem,remada,remadaSerie,remadaRepet,remadaCarga,puxadaOrdem,puxada,puxadaSerie,puxadaRepet,puxadaCarga,desenvOrdem,desenv,desenvSerie,desenvRepet,desenvCarga,elevacaoOrdem,elevacao,elevacaoSerie,elevacaoRepet,elevacaoCarga,remadaPeOrdem,remadaPe,remadaPeSerie,remadaPeRepet,remadaPeCarga,supinoUmOrdem,supinoUm,supinoUmSerie,supinoUmRepet,supinoUmCarga,supinoDoisOrdem,supinoDois,supinoDoisSerie,supinoDoisRepet,supinoDoisCarga,crucifixoOrdem,crucifixo,crucifixoSerie,crucifixorRepet,crucifixoCarga,crossOverOrdem,crossOver,crossOverSerie,crossOverRepet,crossOverCarga,voadorOrdem,voador,voadorSerie,voadorRepet,voadorCarga,roscaOrdem,rosca,roscaSerie,roscaRepet,roscaCarga,roscaDiretaOrdem,roscaDireta,roscaDiretaSerie,roscaDiretaRepet,roscaDiretaCarga,roscaScottOrdem,roscaScott,roscaScottSerie,roscaScottRepet,roscaScottCarga,roscaConcentradaOrdem,roscaConcentrada,roscaConcentradaSerie,roscaConcentradaRepet,roscaConcentradaCarga,testaOrdem,testa,testaSerie,testaRepet,testaCarga,pressFrancesOrdem,pressFrances,pressFrancesSerie,pressFrancesRepet,pressFrancesCarga,roldTricepsOrdem,roldTriceps,roldTricepsSerie,roldTricepsRepet,roldTricepsCarga,observações")] Treinos treinos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treinos).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAluno = new SelectList(db.Alunos, "idAluno", "nome", treinos.idAluno);
            ViewBag.idProfessor = new SelectList(db.Funcionarios, "idFuncionario", "nome", treinos.idProfessor);
            return View(treinos);
        }

        // GET: Treino/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treinos treinos = db.Treinos.Find(id);
            if (treinos == null)
            {
                return HttpNotFound();
            }
            return View(treinos);
        }

        // POST: Treino/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Treinos treinos = db.Treinos.Find(id);
            db.Treinos.Remove(treinos);
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
