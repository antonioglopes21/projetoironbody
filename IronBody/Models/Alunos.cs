namespace IronBody.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Alunos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alunos()
        {
            Agenda = new HashSet<Agenda>();
            ContasReceber = new HashSet<ContasReceber>();
            Login = new HashSet<Login>();
            Treinos = new HashSet<Treinos>();
        }

        [Key]
        public int idAluno { get; set; }

        public int idProfessor { get; set; }

        [Required]
        [StringLength(50)]
        public string nome { get; set; }

        [Required]
        [StringLength(11)]
        public string cpf { get; set; }

        public DateTime dtNascimento { get; set; }

        [StringLength(8)]
        public string cep { get; set; }

        [StringLength(2)]
        public string estado { get; set; }

        [StringLength(38)]
        public string cidade { get; set; }

        [Required]
        [StringLength(38)]
        public string bairro { get; set; }

        [Required]
        [StringLength(150)]
        public string rua { get; set; }

        [StringLength(150)]
        public string email { get; set; }

        [Required]
        [StringLength(9)]
        public string celular { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Agenda> Agenda { get; set; }

        public virtual Funcionarios Funcionarios { get; set; }

        public virtual AvaliacaoFisica AvaliacaoFisica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContasReceber> ContasReceber { get; set; }

        public virtual Funcionarios Funcionarios1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Login> Login { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Treinos> Treinos { get; set; }
    }
}
