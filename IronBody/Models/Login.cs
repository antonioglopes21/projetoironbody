namespace IronBody.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Login")]
    public partial class Login
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int? idFuncionario { get; set; }

        public int? idAluno { get; set; }

        [Required]
        [StringLength(50)]
        public string usuario { get; set; }

        [Required]
        [StringLength(100)]
        public string senha { get; set; }

        [Required]
        [StringLength(10)]
        public string tpacesso { get; set; }

        public virtual Alunos Alunos { get; set; }

        public virtual Funcionarios Funcionarios { get; set; }
    }
}
