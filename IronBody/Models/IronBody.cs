namespace IronBody.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IronBody : DbContext
    {
        public IronBody()
            : base("name=IronBody")
        {
        }

        public virtual DbSet<Agenda> Agenda { get; set; }
        public virtual DbSet<Alunos> Alunos { get; set; }
        public virtual DbSet<AvaliacaoFisica> AvaliacaoFisica { get; set; }
        public virtual DbSet<ContasPagar> ContasPagar { get; set; }
        public virtual DbSet<ContasReceber> ContasReceber { get; set; }
        public virtual DbSet<Funcionarios> Funcionarios { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Treinos> Treinos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agenda>()
                .Property(e => e.atividade)
                .IsUnicode(false);

            modelBuilder.Entity<Alunos>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Alunos>()
                .Property(e => e.cpf)
                .IsUnicode(false);

            modelBuilder.Entity<Alunos>()
                .Property(e => e.cep)
                .IsUnicode(false);

            modelBuilder.Entity<Alunos>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Alunos>()
                .Property(e => e.cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Alunos>()
                .Property(e => e.bairro)
                .IsUnicode(false);

            modelBuilder.Entity<Alunos>()
                .Property(e => e.rua)
                .IsUnicode(false);

            modelBuilder.Entity<Alunos>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Alunos>()
                .Property(e => e.celular)
                .IsUnicode(false);

            modelBuilder.Entity<Alunos>()
                .HasOptional(e => e.AvaliacaoFisica)
                .WithRequired(e => e.Alunos);

            modelBuilder.Entity<Alunos>()
                .HasMany(e => e.ContasReceber)
                .WithRequired(e => e.Alunos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Alunos>()
                .HasMany(e => e.Treinos)
                .WithRequired(e => e.Alunos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AvaliacaoFisica>()
                .Property(e => e.peso)
                .HasPrecision(4, 4);

            modelBuilder.Entity<AvaliacaoFisica>()
                .Property(e => e.pcentGordura)
                .HasPrecision(5, 4);

            modelBuilder.Entity<AvaliacaoFisica>()
                .Property(e => e.pcentGBiceps)
                .HasPrecision(5, 4);

            modelBuilder.Entity<AvaliacaoFisica>()
                .Property(e => e.pcentGCosta)
                .HasPrecision(5, 4);

            modelBuilder.Entity<AvaliacaoFisica>()
                .Property(e => e.pcentGLado)
                .HasPrecision(5, 4);

            modelBuilder.Entity<AvaliacaoFisica>()
                .Property(e => e.pcentGBarriga)
                .HasPrecision(5, 4);

            modelBuilder.Entity<AvaliacaoFisica>()
                .Property(e => e.pcentMBiceps)
                .HasPrecision(5, 4);

            modelBuilder.Entity<AvaliacaoFisica>()
                .Property(e => e.pcentMTriceps)
                .HasPrecision(5, 4);

            modelBuilder.Entity<AvaliacaoFisica>()
                .Property(e => e.pcentMOmbro)
                .HasPrecision(5, 4);

            modelBuilder.Entity<AvaliacaoFisica>()
                .Property(e => e.pcentMPeito)
                .HasPrecision(5, 4);

            modelBuilder.Entity<AvaliacaoFisica>()
                .Property(e => e.pcentMBarriga)
                .HasPrecision(5, 4);

            modelBuilder.Entity<AvaliacaoFisica>()
                .Property(e => e.pcentMCoxa)
                .HasPrecision(5, 4);

            modelBuilder.Entity<AvaliacaoFisica>()
                .Property(e => e.pcentMPanturrilha)
                .HasPrecision(5, 4);

            modelBuilder.Entity<ContasPagar>()
                .Property(e => e.fornecedor)
                .IsUnicode(false);

            modelBuilder.Entity<ContasPagar>()
                .Property(e => e.valor)
                .HasPrecision(15, 3);

            modelBuilder.Entity<ContasPagar>()
                .Property(e => e.desconto)
                .HasPrecision(5, 5);

            modelBuilder.Entity<ContasPagar>()
                .Property(e => e.juros)
                .HasPrecision(5, 5);

            modelBuilder.Entity<ContasPagar>()
                .Property(e => e.situacao)
                .IsUnicode(false);

            modelBuilder.Entity<ContasReceber>()
                .Property(e => e.valor)
                .HasPrecision(15, 3);

            modelBuilder.Entity<ContasReceber>()
                .Property(e => e.desconto)
                .HasPrecision(5, 5);

            modelBuilder.Entity<ContasReceber>()
                .Property(e => e.juros)
                .HasPrecision(5, 5);

            modelBuilder.Entity<ContasReceber>()
                .Property(e => e.situacao)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.cpf)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.salario)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.cargo)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.cep)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.bairro)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.rua)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.celular)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .HasMany(e => e.Agenda)
                .WithOptional(e => e.Funcionarios)
                .HasForeignKey(e => e.idProfessor);

            modelBuilder.Entity<Funcionarios>()
                .HasMany(e => e.Alunos)
                .WithRequired(e => e.Funcionarios)
                .HasForeignKey(e => e.idProfessor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Funcionarios>()
                .HasMany(e => e.Alunos1)
                .WithRequired(e => e.Funcionarios1)
                .HasForeignKey(e => e.idProfessor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Funcionarios>()
                .HasOptional(e => e.AvaliacaoFisica)
                .WithRequired(e => e.Funcionarios);

            modelBuilder.Entity<Funcionarios>()
                .HasMany(e => e.Treinos)
                .WithRequired(e => e.Funcionarios)
                .HasForeignKey(e => e.idProfessor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.senha)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.tpacesso)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.programa)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.intervalo)
                .HasPrecision(2, 2);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.objetivo)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.esteira)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.ergometrica)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.elipticon)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.agachamento)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.agachamentoRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.agachamentoCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.legPress)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.legPressRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.legPressCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.hackMachine)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.hackMachineRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.hackMachineCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.avanco)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.avancoRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.avancoCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.flexora)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.flexoraRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.flexoraCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.flexao)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.flexaoRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.flexaoCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.panturrilha)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.panturrilhaRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.panturrilhaCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.lvtmentoTerra)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.lvtmentoTerraRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.lvtmentoTerraCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.abducao)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.abducaoRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.abducaoCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.aducao)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.aducaoRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.aducaoCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.gluteos)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.gluteosRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.gluteosCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.reto)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.retoRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.retoCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.obliquo)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.obliquoRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.obliquoCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.extsaoLombar)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.extsaoLombarRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.extsaoLombarCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.prancha)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.pranchaRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.pranchaCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.roldDorsal)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.roldDorsalRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.roldDorsalCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.rmdSentada)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.rmdSentadaRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.rmdSentadaCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.remada)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.remadaRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.remadaCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.puxada)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.puxadaRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.puxadaCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.desenv)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.desenvRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.desenvCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.elevacao)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.elevacaoRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.elevacaoCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.remadaPe)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.remadaPeRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.remadaPeCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.supinoUm)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.supinoUmRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.supinoUmCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.supinoDois)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.supinoDoisRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.supinoDoisCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.crucifixo)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.crucifixorRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.crucifixoCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.crossOver)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.crossOverRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.crossOverCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.voador)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.voadorRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.voadorCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.rosca)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.roscaRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.roscaCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.roscaDireta)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.roscaDiretaRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.roscaDiretaCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.roscaScott)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.roscaScottRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.roscaScottCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.roscaConcentrada)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.roscaConcentradaRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.roscaConcentradaCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.testa)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.testaRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.testaCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.pressFrances)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.pressFrancesRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.pressFrancesCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.roldTriceps)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.roldTricepsRepet)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.roldTricepsCarga)
                .IsUnicode(false);

            modelBuilder.Entity<Treinos>()
                .Property(e => e.observacoes)
                .IsUnicode(false);
        }
    }
}
