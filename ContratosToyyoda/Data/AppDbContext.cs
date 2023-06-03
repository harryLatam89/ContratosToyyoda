using ContratosToyyoda.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ContratosToyyoda.Data

{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
               {
            // para evitar borrar en cascada por borrar apoderado
            modelBuilder.Entity<Apoderado>()
    .HasMany(a => a.paises)
    .WithOne(p => p.apoderado)
    .HasForeignKey(e => e.idApoderado)
    .OnDelete(DeleteBehavior.NoAction);

            //para evitar borrar los contratos con un pais
            modelBuilder.Entity<Pais>()
.HasMany(p => p.contratos)
.WithOne(c => c.pais)
.HasForeignKey(e => e.idPais)
.OnDelete(DeleteBehavior.NoAction);

            //para evitar borrar los contratos con un usuario exitente
            modelBuilder.Entity<Usuario>()
.HasMany(p => p.contratos)
.WithOne(c => c.usuario)
.HasForeignKey(e => e.idUser)
.OnDelete(DeleteBehavior.NoAction);

            //para que el correo sea unico 
            modelBuilder.Entity<Persona>()
       .HasIndex(p => p.email)
       .IsUnique();

            modelBuilder.Entity<Contrato>()
      .Property(c => c.fechaFin)
      .HasColumnType("datetime2");

            base.OnModelCreating(modelBuilder);
        }



        public DbSet<Persona> Personas { get; set; }
        
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Pais> Paises { get; set; }
  
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Apoderado> Apoderados { get; set; }

    
        

    }
}
