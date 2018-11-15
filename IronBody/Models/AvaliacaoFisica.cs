namespace IronBody.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AvaliacaoFisica")]
    public partial class AvaliacaoFisica
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int idProfessor { get; set; }

        public int idAluno { get; set; }

        public DateTime data { get; set; }

        public decimal peso { get; set; }

        public decimal pcentGordura { get; set; }

        public decimal pcentGBiceps { get; set; }

        public decimal pcentGCosta { get; set; }

        public decimal pcentGLado { get; set; }

        public decimal pcentGBarriga { get; set; }

        public decimal pcentMBiceps { get; set; }

        public decimal pcentMTriceps { get; set; }

        public decimal pcentMOmbro { get; set; }

        public decimal pcentMPeito { get; set; }

        public decimal pcentMBarriga { get; set; }

        public decimal pcentMCoxa { get; set; }

        public decimal pcentMPanturrilha { get; set; }

        public virtual Alunos Alunos { get; set; }

        public virtual Funcionarios Funcionarios { get; set; }
    }
}
