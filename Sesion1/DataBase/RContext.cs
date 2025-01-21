using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sesion1.DataBase;

public partial class RContext : DbContext
{
    public RContext()
    {
    }

    public RContext(DbContextOptions<RContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Absence> Absences { get; set; }

    public virtual DbSet<Auth> Auths { get; set; }

    public virtual DbSet<Cabinet> Cabinets { get; set; }

    public virtual DbSet<Calendar> Calendars { get; set; }

    public virtual DbSet<Coment> Coments { get; set; }

    public virtual DbSet<Date> Dates { get; set; }

    public virtual DbSet<Departament> Departaments { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Doljnost> Doljnosts { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<Holiday> Holidays { get; set; }

    public virtual DbSet<Kursi> Kursis { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Otdel> Otdels { get; set; }

    public virtual DbSet<Reason> Reasons { get; set; }

    public virtual DbSet<Sotrudniki> Sotrudnikis { get; set; }

    public virtual DbSet<Vacation> Vacations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=.\\SQLexpress;DataBase=r;Trusted_Connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Absence>(entity =>
        {
            entity.ToTable("Absence");

            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.IdSotZameni).HasColumnName("idSotZameni");

            entity.HasOne(d => d.IdReasonNavigation).WithMany(p => p.Absences)
                .HasForeignKey(d => d.IdReason)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Absence_Reason");

            entity.HasOne(d => d.IdSotrudnikNavigation).WithMany(p => p.Absences)
                .HasForeignKey(d => d.IdSotrudnik)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Absence_Sotrudniki");
        });

        modelBuilder.Entity<Auth>(entity =>
        {
            entity.HasKey(e => e.Name);

            entity.ToTable("Auth");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        modelBuilder.Entity<Cabinet>(entity =>
        {
            entity.ToTable("Cabinet");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Number).HasMaxLength(50);
        });

        modelBuilder.Entity<Calendar>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Calendar");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<Coment>(entity =>
        {
            entity.ToTable("Coment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Author).HasMaxLength(50);
            entity.Property(e => e.DateCreate).HasColumnName("dateCreate");
            entity.Property(e => e.Text).HasMaxLength(50);

            entity.HasOne(d => d.Document).WithMany(p => p.Coments)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Coment_Document");
        });

        modelBuilder.Entity<Date>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Date");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Departament>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Podrazdelenie");

            entity.ToTable("Departament");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.ToTable("Document");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.DateCreate).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.HasComment)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Has_comment");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Doljnost>(entity =>
        {
            entity.ToTable("Doljnost");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdEventType).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.IdEventTypeNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdEventType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Events_EventType");
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.ToTable("EventType");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.EventName).HasMaxLength(50);
        });

        modelBuilder.Entity<Holiday>(entity =>
        {
            entity.ToTable("Holiday");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateOfStart).HasColumnName("dateOfStart");
        });

        modelBuilder.Entity<Kursi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Class");

            entity.ToTable("Kursi");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdSotrudnik).HasColumnName("idSotrudnik");
            entity.Property(e => e.NameClass).HasMaxLength(50);
            entity.Property(e => e.TypeOfTraining).HasMaxLength(50);
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Material");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Link).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Otdel>(entity =>
        {
            entity.ToTable("Otdel");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
        });

        modelBuilder.Entity<Reason>(entity =>
        {
            entity.ToTable("Reason");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Komand)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Missing).HasMaxLength(50);
            entity.Property(e => e.Otgyl).HasMaxLength(50);
        });

        modelBuilder.Entity<Sotrudniki>(entity =>
        {
            entity.ToTable("Sotrudniki");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Assistant).HasMaxLength(50);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Fio)
                .HasMaxLength(50)
                .HasColumnName("FIO");
            entity.Property(e => e.IdCabinet).HasColumnName("idCabinet");
            entity.Property(e => e.IdDepartament).HasColumnName("idDepartament");
            entity.Property(e => e.IdDoljnost).HasColumnName("idDoljnost");
            entity.Property(e => e.Other).HasMaxLength(50);
            entity.Property(e => e.RabPhone).HasMaxLength(50);

            entity.HasOne(d => d.IdCabinetNavigation).WithMany(p => p.Sotrudnikis)
                .HasForeignKey(d => d.IdCabinet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sotrudniki_Cabinet");

            entity.HasOne(d => d.IdDepartamentNavigation).WithMany(p => p.Sotrudnikis)
                .HasForeignKey(d => d.IdDepartament)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sotrudniki_Podrazdelenie");

            entity.HasOne(d => d.IdDoljnostNavigation).WithMany(p => p.Sotrudnikis)
                .HasForeignKey(d => d.IdDoljnost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sotrudniki_Doljnost");

            entity.HasOne(d => d.IdOtdelNavigation).WithMany(p => p.Sotrudnikis)
                .HasForeignKey(d => d.IdOtdel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sotrudniki_Otdel1");
        });

        modelBuilder.Entity<Vacation>(entity =>
        {
            entity.ToTable("Vacation");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
