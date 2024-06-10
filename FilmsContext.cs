using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Filmpoisk;

public partial class FilmsContext : DbContext
{
    public FilmsContext()
    {
    }

    public FilmsContext(DbContextOptions<FilmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using 
#warning     the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=films;User Id=postgres;Password=root;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("idactors");

            entity.ToTable("actors", "filmscheme");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Surname).HasColumnName("surname");
        });

        modelBuilder.Entity<Film>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("idfilm");

            entity.ToTable("films", "filmscheme");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("idreview");

            entity.ToTable("reviews", "filmscheme");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Review1).HasColumnName("review");
            entity.Property(e => e.Stars)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(null, null, 0L, 5L, null, null)
                .HasColumnName("stars");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("idroles");

            entity.ToTable("roles", "filmscheme");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ActorsId).HasColumnName("actors_id");
            entity.Property(e => e.FilmsId).HasColumnName("films_id");

            entity.HasOne(d => d.Actors).WithMany(p => p.Roles)
                .HasForeignKey(d => d.ActorsId)
                .HasConstraintName("actors_fk");

            entity.HasOne(d => d.Films).WithMany(p => p.Roles)
                .HasForeignKey(d => d.FilmsId)
                .HasConstraintName("films_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
