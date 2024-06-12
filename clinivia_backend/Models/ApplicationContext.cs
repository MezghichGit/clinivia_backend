using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;

namespace clinivia_backend.Models
{
    public class ApplicationContext : DbContext
    {
            public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
            public DbSet<Departement> Departements { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<Docteur> Docteurs { get; set; }
            public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<User>("User")
                .HasValue<Docteur>("Docteur")
                .HasValue<Patient>("Patient");
            base.OnModelCreating(modelBuilder);

            // Configuration des relations
            modelBuilder.Entity<Docteur>()
                .HasOne(d => d.Departement)
                .WithMany(dp => dp.Docteurs)
                .HasForeignKey(d => d.DepartementId);

            modelBuilder.Entity<Docteur>()
                .HasBaseType<User>();

            modelBuilder.Entity<Patient>()
                .HasBaseType<User>();
        }
    }
}
