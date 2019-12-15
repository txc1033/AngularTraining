namespace AngularTraining.Controllers
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StudentsContext : DbContext
    {
        public StudentsContext()
            : base("name=StudentsContext")
        {
        }

        public virtual DbSet<Estudiante> Estudiante { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>()
                .Property(e => e.estu_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.estu_apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.estu_cod)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.estu_curso)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.estu_sede)
                .IsUnicode(false);
        }
    }
}
