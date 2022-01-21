using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FDB.Apollo.IPT.Service.Models;

namespace FDB.Apollo.IPT.Service.Models.EF
{
    public partial class postgresContext : DbContext
    {
        public postgresContext()
        {
        }

        public postgresContext(DbContextOptions<postgresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<IptBasicColorA> IptBasicColorAs { get; set; } = null!;
        public virtual DbSet<IptBasicColorC> IptBasicColorCs { get; set; } = null!;
        public virtual DbSet<IptBasicColorH> IptBasicColorHs { get; set; } = null!;
        public virtual DbSet<IptBasicColorP> IptBasicColorPs { get; set; } = null!;
        public virtual DbSet<IptBasicColorW> IptBasicColorWs { get; set; } = null!;
        public virtual DbSet<IptColorA> IptColorAs { get; set; } = null!;
        public virtual DbSet<IptColorC> IptColorCs { get; set; } = null!;
        public virtual DbSet<IptColorH> IptColorHs { get; set; } = null!;
        public virtual DbSet<IptColorP> IptColorPs { get; set; } = null!;
        public virtual DbSet<IptColorW> IptColorWs { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseNpgsql("Name=ConnectionStrings:postgres");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("azure")
                .HasPostgresExtension("pg_cron");

            modelBuilder.Entity<IptBasicColorA>(entity =>
            {
                entity.ToTable("ipt_basic_color_a");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.AudCheckoutDate).HasColumnName("aud_checkout_date");

                entity.Property(e => e.AudCheckoutUserId).HasColumnName("aud_checkout_user_id");

                entity.Property(e => e.AudCreateDate).HasColumnName("aud_create_date");

                entity.Property(e => e.AudCreateUserId).HasColumnName("aud_create_user_id");

                entity.Property(e => e.AudLastModifyDate).HasColumnName("aud_last_modify_date");

                entity.Property(e => e.AudLastModifyUserId).HasColumnName("aud_last_modify_user_id");

                entity.Property(e => e.AudPublishDate).HasColumnName("aud_publish_date");

                entity.Property(e => e.AudPublishUserId).HasColumnName("aud_publish_user_id");

                entity.Property(e => e.FirstDeliveredDate).HasColumnName("first_delivered_date");

                entity.Property(e => e.LastDeliveredDate).HasColumnName("last_delivered_date");

                entity.Property(e => e.PrevDeliveredDate).HasColumnName("prev_delivered_date");

                entity.Property(e => e.WipStatusId).HasColumnName("wip_status_id");
            });

            modelBuilder.Entity<IptBasicColorC>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.RevNbr })
                    .HasName("ipt_basic_color_c_pk");

                entity.ToTable("ipt_basic_color_c");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RevNbr).HasColumnName("rev_nbr");

                entity.Property(e => e.Abbreviation)
                    .HasMaxLength(7)
                    .HasColumnName("abbreviation");

                entity.Property(e => e.ChangeTimestamp).HasColumnName("change_timestamp");

                entity.Property(e => e.ChangeType)
                    .HasMaxLength(1)
                    .HasColumnName("change_type");

                entity.Property(e => e.ChangeUserId).HasColumnName("change_user_id");

                entity.Property(e => e.ConceptRevNbr).HasColumnName("concept_rev_nbr");

                entity.Property(e => e.DcrNbr).HasColumnName("dcr_nbr");

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .HasColumnName("description");

                entity.Property(e => e.DoNotUseInd)
                    .HasMaxLength(1)
                    .HasColumnName("do_not_use_ind");

                entity.Property(e => e.LegacyChangeUser)
                    .HasMaxLength(9)
                    .HasColumnName("legacy_change_user");

                entity.Property(e => e.ShortAbbreviation)
                    .HasMaxLength(4)
                    .HasColumnName("short_abbreviation");
            });

            modelBuilder.Entity<IptBasicColorH>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.RevNbr })
                    .HasName("ipt_basic_color_h_pk");

                entity.ToTable("ipt_basic_color_h");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RevNbr).HasColumnName("rev_nbr");

                entity.Property(e => e.ChangeTimestamp).HasColumnName("change_timestamp");

                entity.Property(e => e.ChangeType)
                    .HasMaxLength(1)
                    .HasColumnName("change_type");

                entity.Property(e => e.ChangeUserId).HasColumnName("change_user_id");

                entity.Property(e => e.DcrNbr).HasColumnName("dcr_nbr");

                entity.Property(e => e.LegacyChangeUser)
                    .HasMaxLength(9)
                    .HasColumnName("legacy_change_user");
            });

            modelBuilder.Entity<IptBasicColorP>(entity =>
            {
                entity.ToTable("ipt_basic_color_p");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Abbreviation)
                    .HasMaxLength(7)
                    .HasColumnName("abbreviation");

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .HasColumnName("description");

                entity.Property(e => e.DoNotUseInd)
                    .HasMaxLength(1)
                    .HasColumnName("do_not_use_ind");

                entity.Property(e => e.ShortAbbreviation)
                    .HasMaxLength(4)
                    .HasColumnName("short_abbreviation");

                entity.HasOne(d => d.Audit)
                    .WithOne(p => p.IptBasicColorP)
                    .HasForeignKey<IptBasicColorP>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ipt_basic_color_p_fk1");
            });

            modelBuilder.Entity<IptBasicColorW>(entity =>
            {
                entity.ToTable("ipt_basic_color_w");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Abbreviation)
                    .HasMaxLength(7)
                    .HasColumnName("abbreviation");

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .HasColumnName("description");

                entity.Property(e => e.DoNotUseInd)
                    .HasMaxLength(1)
                    .HasColumnName("do_not_use_ind");

                entity.Property(e => e.ShortAbbreviation)
                    .HasMaxLength(4)
                    .HasColumnName("short_abbreviation");

                entity.HasOne(d => d.Audit)
                    .WithOne(p => p.IptBasicColorW)
                    .HasForeignKey<IptBasicColorW>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ipt_basic_color_w_fk1");
            });

            modelBuilder.Entity<IptColorA>(entity =>
            {
                entity.ToTable("ipt_color_a");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.AudCheckoutDate).HasColumnName("aud_checkout_date");

                entity.Property(e => e.AudCheckoutUserId).HasColumnName("aud_checkout_user_id");

                entity.Property(e => e.AudCreateDate).HasColumnName("aud_create_date");

                entity.Property(e => e.AudCreateUserId).HasColumnName("aud_create_user_id");

                entity.Property(e => e.AudLastModifyDate).HasColumnName("aud_last_modify_date");

                entity.Property(e => e.AudLastModifyUserId).HasColumnName("aud_last_modify_user_id");

                entity.Property(e => e.AudPublishDate).HasColumnName("aud_publish_date");

                entity.Property(e => e.AudPublishUserId).HasColumnName("aud_publish_user_id");

                entity.Property(e => e.FirstDeliveredDate).HasColumnName("first_delivered_date");

                entity.Property(e => e.LastDeliveredDate).HasColumnName("last_delivered_date");

                entity.Property(e => e.PrevDeliveredDate).HasColumnName("prev_delivered_date");

                entity.Property(e => e.WipStatusId).HasColumnName("wip_status_id");
            });

            modelBuilder.Entity<IptColorC>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.RevNbr })
                    .HasName("ipt_color_c_pk");

                entity.ToTable("ipt_color_c");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RevNbr).HasColumnName("rev_nbr");

                entity.Property(e => e.Abbreviation)
                    .HasMaxLength(15)
                    .HasColumnName("abbreviation");

                entity.Property(e => e.BasicColorId).HasColumnName("basic_color_id");

                entity.Property(e => e.ChangeTimestamp).HasColumnName("change_timestamp");

                entity.Property(e => e.ChangeType)
                    .HasMaxLength(1)
                    .HasColumnName("change_type");

                entity.Property(e => e.ChangeUserId).HasColumnName("change_user_id");

                entity.Property(e => e.ConceptRevNbr).HasColumnName("concept_rev_nbr");

                entity.Property(e => e.DcrNbr).HasColumnName("dcr_nbr");

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .HasColumnName("description");

                entity.Property(e => e.DoNotUseInd)
                    .HasMaxLength(1)
                    .HasColumnName("do_not_use_ind");

                entity.Property(e => e.LegacyChangeUser)
                    .HasMaxLength(9)
                    .HasColumnName("legacy_change_user");
            });

            modelBuilder.Entity<IptColorH>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.RevNbr })
                    .HasName("ipt_color_h_pk");

                entity.ToTable("ipt_color_h");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RevNbr).HasColumnName("rev_nbr");

                entity.Property(e => e.ChangeTimestamp).HasColumnName("change_timestamp");

                entity.Property(e => e.ChangeType)
                    .HasMaxLength(1)
                    .HasColumnName("change_type");

                entity.Property(e => e.ChangeUserId).HasColumnName("change_user_id");

                entity.Property(e => e.DcrNbr).HasColumnName("dcr_nbr");

                entity.Property(e => e.LegacyChangeUser)
                    .HasMaxLength(9)
                    .HasColumnName("legacy_change_user");
            });

            modelBuilder.Entity<IptColorP>(entity =>
            {
                entity.ToTable("ipt_color_p");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Abbreviation)
                    .HasMaxLength(15)
                    .HasColumnName("abbreviation");

                entity.Property(e => e.BasicColorId).HasColumnName("basic_color_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .HasColumnName("description");

                entity.Property(e => e.DoNotUseInd)
                    .HasMaxLength(1)
                    .HasColumnName("do_not_use_ind");

                entity.HasOne(d => d.BasicColor)
                    .WithMany(p => p.IptColorPs)
                    .HasForeignKey(d => d.BasicColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ipt_color_p_fk2");

                entity.HasOne(d => d.Audit)
                    .WithOne(p => p.IptColorP)
                    .HasForeignKey<IptColorP>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ipt_color_p_fk1");
            });

            modelBuilder.Entity<IptColorW>(entity =>
            {
                entity.ToTable("ipt_color_w");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Abbreviation)
                    .HasMaxLength(15)
                    .HasColumnName("abbreviation");

                entity.Property(e => e.BasicColorId).HasColumnName("basic_color_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .HasColumnName("description");

                entity.Property(e => e.DoNotUseInd)
                    .HasMaxLength(1)
                    .HasColumnName("do_not_use_ind");

                entity.HasOne(d => d.BasicColor)
                    .WithMany(p => p.IptColorWs)
                    .HasForeignKey(d => d.BasicColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ipt_color_w_fk2");

                entity.HasOne(d => d.Audit)
                    .WithOne(p => p.IptColorW)
                    .HasForeignKey<IptColorW>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ipt_color_w_fk1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<FDB.Apollo.IPT.Service.Models.Color> Color { get; set; } = null!;
    }
}
