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
    }
}
