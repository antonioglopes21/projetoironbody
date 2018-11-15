namespace IronBody.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Treinos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int idProfessor { get; set; }

        public int idAluno { get; set; }

        public DateTime data { get; set; }

        public int duracao { get; set; }

        [Required]
        [StringLength(25)]
        public string programa { get; set; }

        public decimal intervalo { get; set; }

        public int freqTreino { get; set; }

        [StringLength(2)]
        public string objetivo { get; set; }

        [StringLength(25)]
        public string esteira { get; set; }

        public int? esteiraTempo { get; set; }

        public int? esteiraVelocidade { get; set; }

        [StringLength(25)]
        public string ergometrica { get; set; }

        public int? ergometricaTempo { get; set; }

        public int? ergometricaVelocidade { get; set; }

        [StringLength(25)]
        public string elipticon { get; set; }

        public int? elipticonTempo { get; set; }

        public int? elipticonVelocidade { get; set; }

        [StringLength(25)]
        public string agachamento { get; set; }

        public int? agachamentoOrdem { get; set; }

        public int? agachamentoSerie { get; set; }

        [StringLength(25)]
        public string agachamentoRepet { get; set; }

        [StringLength(25)]
        public string agachamentoCarga { get; set; }

        public int? legPressOrdem { get; set; }

        [StringLength(25)]
        public string legPress { get; set; }

        public int? legPressSerie { get; set; }

        [StringLength(25)]
        public string legPressRepet { get; set; }

        [StringLength(25)]
        public string legPressCarga { get; set; }

        public int? hackMachineOrdem { get; set; }

        [StringLength(25)]
        public string hackMachine { get; set; }

        public int? hackMachineSerie { get; set; }

        [StringLength(25)]
        public string hackMachineRepet { get; set; }

        [StringLength(25)]
        public string hackMachineCarga { get; set; }

        public int? avancoOrdem { get; set; }

        [StringLength(25)]
        public string avanco { get; set; }

        public int? avancoSerie { get; set; }

        [StringLength(25)]
        public string avancoRepet { get; set; }

        [StringLength(25)]
        public string avancoCarga { get; set; }

        public int? flexoraOrdem { get; set; }

        [StringLength(25)]
        public string flexora { get; set; }

        public int? flexoraSerie { get; set; }

        [StringLength(25)]
        public string flexoraRepet { get; set; }

        [StringLength(25)]
        public string flexoraCarga { get; set; }

        public int? flexaoOrdem { get; set; }

        [StringLength(25)]
        public string flexao { get; set; }

        public int? flexaoSerie { get; set; }

        [StringLength(25)]
        public string flexaoRepet { get; set; }

        [StringLength(25)]
        public string flexaoCarga { get; set; }

        public int? panturrilhaOrdem { get; set; }

        [StringLength(25)]
        public string panturrilha { get; set; }

        public int? panturrilhaSerie { get; set; }

        [StringLength(25)]
        public string panturrilhaRepet { get; set; }

        [StringLength(25)]
        public string panturrilhaCarga { get; set; }

        public int? lvtmentoTerraOrdem { get; set; }

        [StringLength(25)]
        public string lvtmentoTerra { get; set; }

        public int? lvtmentoTerraSerie { get; set; }

        [StringLength(25)]
        public string lvtmentoTerraRepet { get; set; }

        [StringLength(25)]
        public string lvtmentoTerraCarga { get; set; }

        public int? abducaoOrdem { get; set; }

        [StringLength(25)]
        public string abducao { get; set; }

        public int? abducaoSerie { get; set; }

        [StringLength(25)]
        public string abducaoRepet { get; set; }

        [StringLength(25)]
        public string abducaoCarga { get; set; }

        public int? aducaoOrdem { get; set; }

        [StringLength(25)]
        public string aducao { get; set; }

        public int? aducaoSerie { get; set; }

        [StringLength(25)]
        public string aducaoRepet { get; set; }

        [StringLength(25)]
        public string aducaoCarga { get; set; }

        public int? gluteosOrdem { get; set; }

        [StringLength(25)]
        public string gluteos { get; set; }

        public int? gluteosSerie { get; set; }

        [StringLength(25)]
        public string gluteosRepet { get; set; }

        [StringLength(25)]
        public string gluteosCarga { get; set; }

        public int? retoOrdem { get; set; }

        [StringLength(25)]
        public string reto { get; set; }

        public int? retoSerie { get; set; }

        [StringLength(25)]
        public string retoRepet { get; set; }

        [StringLength(25)]
        public string retoCarga { get; set; }

        public int? obliquoOrdem { get; set; }

        [StringLength(25)]
        public string obliquo { get; set; }

        public int? obliquoSerie { get; set; }

        [StringLength(25)]
        public string obliquoRepet { get; set; }

        [StringLength(25)]
        public string obliquoCarga { get; set; }

        public int? extsaoLombarOrdem { get; set; }

        [StringLength(25)]
        public string extsaoLombar { get; set; }

        public int? extsaoLombarSerie { get; set; }

        [StringLength(25)]
        public string extsaoLombarRepet { get; set; }

        [StringLength(25)]
        public string extsaoLombarCarga { get; set; }

        public int? pranchaOrdem { get; set; }

        [StringLength(25)]
        public string prancha { get; set; }

        public int? pranchaSerie { get; set; }

        [StringLength(25)]
        public string pranchaRepet { get; set; }

        [StringLength(25)]
        public string pranchaCarga { get; set; }

        public int? roldDorsalOrdem { get; set; }

        [StringLength(25)]
        public string roldDorsal { get; set; }

        public int? roldDorsalSerie { get; set; }

        [StringLength(25)]
        public string roldDorsalRepet { get; set; }

        [StringLength(25)]
        public string roldDorsalCarga { get; set; }

        public int? rmdSentadaOrdem { get; set; }

        [StringLength(25)]
        public string rmdSentada { get; set; }

        public int? rmdSentadaSerie { get; set; }

        [StringLength(25)]
        public string rmdSentadaRepet { get; set; }

        [StringLength(25)]
        public string rmdSentadaCarga { get; set; }

        public int? remadaOrdem { get; set; }

        [StringLength(25)]
        public string remada { get; set; }

        public int? remadaSerie { get; set; }

        [StringLength(25)]
        public string remadaRepet { get; set; }

        [StringLength(25)]
        public string remadaCarga { get; set; }

        public int? puxadaOrdem { get; set; }

        [StringLength(25)]
        public string puxada { get; set; }

        public int? puxadaSerie { get; set; }

        [StringLength(25)]
        public string puxadaRepet { get; set; }

        [StringLength(25)]
        public string puxadaCarga { get; set; }

        public int? desenvOrdem { get; set; }

        [StringLength(25)]
        public string desenv { get; set; }

        public int? desenvSerie { get; set; }

        [StringLength(25)]
        public string desenvRepet { get; set; }

        [StringLength(25)]
        public string desenvCarga { get; set; }

        public int? elevacaoOrdem { get; set; }

        [StringLength(25)]
        public string elevacao { get; set; }

        public int? elevacaoSerie { get; set; }

        [StringLength(25)]
        public string elevacaoRepet { get; set; }

        [StringLength(25)]
        public string elevacaoCarga { get; set; }

        public int? remadaPeOrdem { get; set; }

        [StringLength(25)]
        public string remadaPe { get; set; }

        public int? remadaPeSerie { get; set; }

        [StringLength(25)]
        public string remadaPeRepet { get; set; }

        [StringLength(25)]
        public string remadaPeCarga { get; set; }

        public int? supinoUmOrdem { get; set; }

        [StringLength(25)]
        public string supinoUm { get; set; }

        public int? supinoUmSerie { get; set; }

        [StringLength(25)]
        public string supinoUmRepet { get; set; }

        [StringLength(25)]
        public string supinoUmCarga { get; set; }

        public int? supinoDoisOrdem { get; set; }

        [StringLength(25)]
        public string supinoDois { get; set; }

        public int? supinoDoisSerie { get; set; }

        [StringLength(25)]
        public string supinoDoisRepet { get; set; }

        [StringLength(25)]
        public string supinoDoisCarga { get; set; }

        public int? crucifixoOrdem { get; set; }

        [StringLength(25)]
        public string crucifixo { get; set; }

        public int? crucifixoSerie { get; set; }

        [StringLength(25)]
        public string crucifixorRepet { get; set; }

        [StringLength(25)]
        public string crucifixoCarga { get; set; }

        public int? crossOverOrdem { get; set; }

        [StringLength(25)]
        public string crossOver { get; set; }

        public int? crossOverSerie { get; set; }

        [StringLength(25)]
        public string crossOverRepet { get; set; }

        [StringLength(25)]
        public string crossOverCarga { get; set; }

        public int? voadorOrdem { get; set; }

        [StringLength(25)]
        public string voador { get; set; }

        public int? voadorSerie { get; set; }

        [StringLength(25)]
        public string voadorRepet { get; set; }

        [StringLength(25)]
        public string voadorCarga { get; set; }

        public int? roscaOrdem { get; set; }

        [StringLength(25)]
        public string rosca { get; set; }

        public int? roscaSerie { get; set; }

        [StringLength(25)]
        public string roscaRepet { get; set; }

        [StringLength(25)]
        public string roscaCarga { get; set; }

        public int? roscaDiretaOrdem { get; set; }

        [StringLength(25)]
        public string roscaDireta { get; set; }

        public int? roscaDiretaSerie { get; set; }

        [StringLength(25)]
        public string roscaDiretaRepet { get; set; }

        [StringLength(25)]
        public string roscaDiretaCarga { get; set; }

        public int? roscaScottOrdem { get; set; }

        [StringLength(25)]
        public string roscaScott { get; set; }

        public int? roscaScottSerie { get; set; }

        [StringLength(25)]
        public string roscaScottRepet { get; set; }

        [StringLength(25)]
        public string roscaScottCarga { get; set; }

        public int? roscaConcentradaOrdem { get; set; }

        [StringLength(25)]
        public string roscaConcentrada { get; set; }

        public int? roscaConcentradaSerie { get; set; }

        [StringLength(25)]
        public string roscaConcentradaRepet { get; set; }

        [StringLength(25)]
        public string roscaConcentradaCarga { get; set; }

        public int? testaOrdem { get; set; }

        [StringLength(25)]
        public string testa { get; set; }

        public int? testaSerie { get; set; }

        [StringLength(25)]
        public string testaRepet { get; set; }

        [StringLength(25)]
        public string testaCarga { get; set; }

        public int? pressFrancesOrdem { get; set; }

        [StringLength(25)]
        public string pressFrances { get; set; }

        public int? pressFrancesSerie { get; set; }

        [StringLength(25)]
        public string pressFrancesRepet { get; set; }

        [StringLength(25)]
        public string pressFrancesCarga { get; set; }

        public int? roldTricepsOrdem { get; set; }

        [StringLength(25)]
        public string roldTriceps { get; set; }

        public int? roldTricepsSerie { get; set; }

        [StringLength(25)]
        public string roldTricepsRepet { get; set; }

        [StringLength(25)]
        public string roldTricepsCarga { get; set; }

        [StringLength(5000)]
        public string observacoes { get; set; }

        public virtual Alunos Alunos { get; set; }

        public virtual Funcionarios Funcionarios { get; set; }
    }
}
