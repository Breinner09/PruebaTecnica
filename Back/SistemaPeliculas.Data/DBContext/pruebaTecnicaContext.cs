using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SistemaPeliculas.Modelos;

namespace SistemaPeliculas.Data.DBContext
{
    public partial class pruebaTecnicaContext : DbContext
    {
        public pruebaTecnicaContext()
        {
        }

        public pruebaTecnicaContext(DbContextOptions<pruebaTecnicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pelicula> Peliculas { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.ToTable("peliculas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Calificacion).HasColumnName("calificacion");

                entity.Property(e => e.NombrePelicula)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombrePelicula");

                entity.Property(e => e.PeliculaId).HasColumnName("peliculaId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Peliculas)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__peliculas__userI__49C3F6B7");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
