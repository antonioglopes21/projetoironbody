namespace IronBody.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContasReceber")]
    public partial class ContasReceber
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int idAluno { get; set; }

        public DateTime dtVencimento { get; set; }

        public decimal valor { get; set; }

        public DateTime dtPagamento { get; set; }

        public decimal desconto { get; set; }

        public decimal juros { get; set; }

        [Required]
        [StringLength(10)]
        public string situacao { get; set; }

        public virtual Alunos Alunos { get; set; }
    }
}
