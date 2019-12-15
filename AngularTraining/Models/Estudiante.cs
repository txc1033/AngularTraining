namespace AngularTraining.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("colegio.Estudiante")]
    public partial class Estudiante
    {
        [DisplayName("Id Estudiante")]
        [Key]
        public long estu_idEstudiante { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage ="El nombre es obligatorio")]
        [StringLength(60)]
        public string estu_nombre { get; set; }

        [DisplayName("Apellido")]
        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(60)]
        public string estu_apellido { get; set; }

        [DisplayName("Codigo")]
        [StringLength(15)]
        public string estu_cod { get; set; }

        [DisplayName("Curso")]
        [StringLength(30)]
        public string estu_curso { get; set; }

        [DisplayName("Id Profesor")]
        public long? estu_profid { get; set; }

        [DisplayName("Sede")]
        [StringLength(30)]
        public string estu_sede { get; set; }

        [DisplayName("Region")]
        public int? estu_region { get; set; }

        [DisplayName("Id Persona")]
        public long? per_idPersona { get; set; }
    }
}
