using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityCoreTutorial.Models;

public partial class AlwebieeContext : DbContext
{
    public AlwebieeContext()
    {
    }

    public AlwebieeContext(DbContextOptions<AlwebieeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Userinfo> Userinfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=alwebiee;User Id=postgres;Password=pgadmin;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("accounts_pkey");

            entity.ToTable("accounts");

            entity.HasIndex(e => e.Emailid, "idx_emailid");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnName("createddate");
            entity.Property(e => e.Emailid)
                .HasMaxLength(500)
                .HasColumnName("emailid");
            entity.Property(e => e.Isactive)
                .HasDefaultValueSql("false")
                .HasColumnName("isactive");
            entity.Property(e => e.Isadmin).HasColumnName("isadmin");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(30)
                .HasColumnName("phonenumber");
            entity.Property(e => e.Updatedate)
                .HasDefaultValueSql("now()")
                .HasColumnName("updatedate");
        });

        modelBuilder.Entity<Userinfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("userinfo_pkey");

            entity.ToTable("userinfo");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Connection)
                .HasMaxLength(1000)
                .HasColumnName("connection");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
