﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Test.Model;

namespace Test.DAL
{
    public partial class TestContext : DbContext
    {
        public TestContext()
        {
        }

        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SessionSlot> SessionSlots { get; set; }
        public virtual DbSet<SessionSlotData> SessionSlotDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SessionSlot>(entity =>
            {
                entity.ToTable("session_slots", "test");

                entity.HasIndex(e => e.Guid, "ix_session_slots_guid")
                    .IsUnique();

                entity.HasIndex(e => e.Guid, "un_session_slots__guid")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApplicationName)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("application_name");

                entity.Property(e => e.Guid)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("guid");

                entity.Property(e => e.LastActiveAtUtc)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("last_active_at_utc");

                entity.Property(e => e.LastBrowserActiveAtUtc)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("last_browser_active_at_utc")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.LoginAtUtc)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("login_at_utc");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<SessionSlotData>(entity =>
            {
                entity.ToTable("session_slot_data", "test");

                entity.HasIndex(e => new { e.SessionSlotGuid, e.Key }, "un_session_slot_data__session_slot_guid_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("key");

                entity.Property(e => e.ModifiedAtUtc)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("modified_at_utc");

                entity.Property(e => e.SessionSlotGuid)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("session_slot_guid");

                entity.HasOne(d => d.SessionSlotGu)
                    .WithMany(p => p.SessionSlotDatas)
                    .HasPrincipalKey(p => p.Guid)
                    .HasForeignKey(d => d.SessionSlotGuid)
                    .HasConstraintName("fk_session_slot_data_session_slot_guid__");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
