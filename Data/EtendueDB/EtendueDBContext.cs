﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EtendueERP.Models.EtendueDB;

namespace EtendueERP.Data.EtendueDB
{
    public partial class EtendueDBContext : DbContext
    {
        public EtendueDBContext()
        {
        }

        public EtendueDBContext(DbContextOptions<EtendueDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<T_Societe> T_Societe { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=feedipet.com;Initial Catalog=EtendueERP;User ID=sa;Password=azer12TY");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("French_CI_AS");

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Role)
                    .WithMany(p => p.User)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRoles",
                        l => l.HasOne<AspNetRoles>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUsers>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");

                            j.HasIndex(new[] { "UserId" }, "IX_AspNetUserRoles_UserId");
                        });
            });

            modelBuilder.Entity<T_Societe>(entity =>
            {
                entity.Property(e => e.Abrege)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Adresse)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Base)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CNSS)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Capital).HasColumnType("decimal(27, 6)");

                entity.Property(e => e.Comptabilite)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateCreation).HasColumnType("smalldatetime");

                entity.Property(e => e.DateDebut).HasColumnType("smalldatetime");

                entity.Property(e => e.DateFin).HasColumnType("smalldatetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GestionCommercial)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ICE)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdF)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdTVA)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Intitule)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Passe)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Patente)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RC)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Serveur)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Superficie).HasColumnType("decimal(27, 6)");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tracabilite)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ville)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Web)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}