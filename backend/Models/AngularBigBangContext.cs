using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AngularBigBang.Models;

public partial class AngularBigBangContext : DbContext
{
    public AngularBigBangContext()
    {
    }

    public AngularBigBangContext(DbContextOptions<AngularBigBangContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=.\\SQLEXPRESS;Database=AngularBigBang;integrated security=SSPI;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Appointmentid).HasName("PK__appointm__D0666126916D6C81");

            entity.ToTable("appointment");

            entity.Property(e => e.Appointmentid).HasColumnName("appointmentid");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Dusername).HasColumnName("dusername");
            entity.Property(e => e.Pusername).HasColumnName("pusername");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Doctor__3214EC0731AA1787");

            entity.ToTable("Doctor");

            entity.Property(e => e.Availability)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')")
                .HasColumnName("availability");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasDefaultValueSql("('')")
                .HasColumnName("password");
            entity.Property(e => e.RequestStatus)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')")
                .HasColumnName("requestStatus");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Specialization)
                .HasMaxLength(100)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasDefaultValueSql("('')")
                .HasColumnName("userName");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Feedbackid).HasName("PK__feedback__2612C14CB5997BB3");

            entity.ToTable("feedback");

            entity.Property(e => e.Feedbackid).HasColumnName("feedbackid");
            entity.Property(e => e.Details).HasColumnName("details");
            entity.Property(e => e.Dusername).HasColumnName("dusername");
            entity.Property(e => e.Pusername).HasColumnName("pusername");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Gender).HasDefaultValueSql("('')");
            entity.Property(e => e.Name).HasDefaultValueSql("('')");
            entity.Property(e => e.Role).HasDefaultValueSql("('')");
            entity.Property(e => e.UserName)
                .HasDefaultValueSql("('')")
                .HasColumnName("userName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
