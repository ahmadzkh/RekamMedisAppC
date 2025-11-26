using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using RekamMedisAppBaru.Models;

namespace RekamMedisAppBaru.Data;

public partial class RekamMedisContext : DbContext
{
    public RekamMedisContext() { }

    public RekamMedisContext(DbContextOptions<RekamMedisContext> options) : base(options) { }

    public virtual DbSet<Pasien> Patients { get; set; }
    public virtual DbSet<Admin> Admins { get; set; }
    public virtual DbSet<Rekammedis> Rekammedis { get; set; }
    public virtual DbSet<Tenagamedis> Tenagamedis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=rekam-medis;user=root", 
            Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("admin");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Foto)
                .HasMaxLength(200)
                .HasColumnName("foto");
            entity.Property(e => e.Nama)
                .HasMaxLength(200)
                .HasColumnName("nama");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(120)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Pasien>(entity =>
        {
            entity.HasKey(e => e.IdPasien).HasName("PRIMARY");

            entity.ToTable("pasien");

            entity.HasIndex(e => e.NoTelp, "no_telp");

            entity.Property(e => e.IdPasien).HasColumnName("id_pasien");
            entity.Property(e => e.Agama)
                .HasMaxLength(100)
                .HasColumnName("agama");
            entity.Property(e => e.Alamat)
                .HasColumnType("text")
                .HasColumnName("alamat");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.JenisKelamin)
                .HasColumnType("enum('Laki-Laki','Perempuan')")
                .HasColumnName("jenis_kelamin");
            entity.Property(e => e.Nama)
                .HasMaxLength(255)
                .HasColumnName("nama");
            entity.Property(e => e.Nik)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("nik");
            entity.Property(e => e.NoTelp)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("no_telp");
            entity.Property(e => e.Pekerjaan)
                .HasMaxLength(100)
                .HasColumnName("pekerjaan");
            entity.Property(e => e.Pendidikan)
                .HasMaxLength(100)
                .HasColumnName("pendidikan");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TanggalLahir).HasColumnName("tanggal_lahir");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Rekammedis>(entity =>
        {
            entity.HasKey(e => e.IdReport).HasName("PRIMARY");

            entity.ToTable("rekammedis");

            entity.HasIndex(e => e.DokterId, "dokter_id");

            entity.HasIndex(e => e.PasienId, "pasien_id");

            entity.Property(e => e.IdReport).HasColumnName("id_report");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Diagnosa)
                .HasColumnType("text")
                .HasColumnName("diagnosa");
            entity.Property(e => e.DokterId).HasColumnName("dokter_id");
            entity.Property(e => e.Keluhan)
                .HasColumnType("text")
                .HasColumnName("keluhan");
            entity.Property(e => e.Kondisi)
                .HasMaxLength(100)
                .HasColumnName("kondisi");
            entity.Property(e => e.PasienId).HasColumnName("pasien_id");
            entity.Property(e => e.TanggalDiagnosa)
                .HasColumnType("datetime")
                .HasColumnName("tanggal_diagnosa");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Dokter).WithMany(p => p.Rekammedis)
                .HasForeignKey(d => d.DokterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rekammedis_ibfk_1");

            entity.HasOne(d => d.Pasien).WithMany(p => p.Rekammedis)
                .HasForeignKey(d => d.PasienId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rekammedis_ibfk_2");
        });

        modelBuilder.Entity<Tenagamedis>(entity =>
        {
            entity.HasKey(e => e.IdDokter).HasName("PRIMARY");

            entity.ToTable("tenagamedis");

            entity.Property(e => e.IdDokter).HasColumnName("id_dokter");
            entity.Property(e => e.Alamat)
                .HasColumnType("text")
                .HasColumnName("alamat");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.HariPraktek)
                .HasMaxLength(50)
                .HasColumnName("hari_praktek");
            entity.Property(e => e.JamPraktek)
                .HasMaxLength(50)
                .HasColumnName("jam_praktek");
            entity.Property(e => e.JenisKelamin)
                .HasColumnType("enum('Laki-Laki','Perempuan')")
                .HasColumnName("jenis_kelamin");
            entity.Property(e => e.Nama)
                .HasMaxLength(255)
                .HasColumnName("nama");
            entity.Property(e => e.NoTelp)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("no_telp");
            entity.Property(e => e.Spesialisasi)
                .HasMaxLength(100)
                .HasColumnName("spesialisasi");
            entity.Property(e => e.TanggalLahir).HasColumnName("tanggal_lahir");
            entity.Property(e => e.TanggalOut).HasColumnName("tanggal_out");
            entity.Property(e => e.TanggalRegist).HasColumnName("tanggal_regist");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
