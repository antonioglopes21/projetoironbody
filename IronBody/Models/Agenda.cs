namespace IronBody.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Agenda
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int? idProfessor { get; set; }

        public int? idAluno { get; set; }

        public DateTime dtInicio { get; set; }

        [Required]
        [StringLength(100)]
        public string atividade { get; set; }

        public DateTime? dtFim { get; set; }

        public virtual Alunos Alunos { get; set; }

        public virtual Funcionarios Funcionarios { get; set; }
    }
}
