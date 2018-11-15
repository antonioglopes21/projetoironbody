namespace IronBody.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Funcionarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Funcionarios()
        {
            Agenda = new HashSet<Agenda>();
            Alunos = new HashSet<Alunos>();
            Alunos1 = new HashSet<Alunos>();
            Login = new HashSet<Login>();
            Treinos = new HashSet<Treinos>();
        }

        [Key]
        public int idFuncionario { get; set; }

        [Required]
        [StringLength(50)]
        public string nome { get; set; }

        [Required]
        [StringLength(11)]
        public string cpf { get; set; }

        public DateTime dtNascimento { get; set; }

        public decimal salario { get; set; }

        [Required]
        [StringLength(10)]
        public string cargo { get; set; }

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

        [Required]
        [StringLength(9)]
        public string celular { get; set; }

        [StringLength(150)]
        public string email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Agenda> Agenda { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alunos> Alunos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alunos> Alunos1 { get; set; }

        public virtual AvaliacaoFisica AvaliacaoFisica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Login> Login { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Treinos> Treinos { get; set; }
    }
}
