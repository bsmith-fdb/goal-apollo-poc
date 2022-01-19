using Microsoft.EntityFrameworkCore;

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

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseNpgsql();
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_catalog", "azure")
                .HasPostgresExtension("pg_cron");

            modelBuilder.Entity<IptBasicColorA>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ipt_basic_color_a");

                entity.Property(e => e.AudCheckoutDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("aud_checkout_date");

                entity.Property(e => e.AudCheckoutUserId)
                    .HasPrecision(8)
                    .HasColumnName("aud_checkout_user_id");

                entity.Property(e => e.AudCreateDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("aud_create_date");

                entity.Property(e => e.AudCreateUserId)
                    .HasPrecision(8)
                    .HasColumnName("aud_create_user_id");

                entity.Property(e => e.AudLastModifyDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("aud_last_modify_date");

                entity.Property(e => e.AudLastModifyUserId)
                    .HasPrecision(8)
                    .HasColumnName("aud_last_modify_user_id");

                entity.Property(e => e.AudPublishDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("aud_publish_date");

                entity.Property(e => e.AudPublishUserId)
                    .HasPrecision(8)
                    .HasColumnName("aud_publish_user_id");

                entity.Property(e => e.FirstDeliveredDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("first_delivered_date");

                entity.Property(e => e.Id)
                    .HasPrecision(8)
                    .HasColumnName("id");

                entity.Property(e => e.LastDeliveredDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("last_delivered_date");

                entity.Property(e => e.PrevDeliveredDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("prev_delivered_date");

                entity.Property(e => e.WipStatusId)
                    .HasPrecision(8)
                    .HasColumnName("wip_status_id");
            });

            modelBuilder.Entity<IptBasicColorC>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ipt_basic_color_c");

                entity.Property(e => e.Abbreviation)
                    .HasMaxLength(7)
                    .HasColumnName("abbreviation");

                entity.Property(e => e.ChangeTimestamp)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("change_timestamp");

                entity.Property(e => e.ChangeType)
                    .HasMaxLength(1)
                    .HasColumnName("change_type");

                entity.Property(e => e.ChangeUserId)
                    .HasPrecision(8)
                    .HasColumnName("change_user_id");

                entity.Property(e => e.ConceptRevNbr)
                    .HasPrecision(4)
                    .HasColumnName("concept_rev_nbr");

                entity.Property(e => e.DcrNbr)
                    .HasPrecision(5)
                    .HasColumnName("dcr_nbr");

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .HasColumnName("description");

                entity.Property(e => e.DoNotUseInd)
                    .HasMaxLength(1)
                    .HasColumnName("do_not_use_ind");

                entity.Property(e => e.Id)
                    .HasPrecision(8)
                    .HasColumnName("id");

                entity.Property(e => e.LegacyChangeUser)
                    .HasMaxLength(9)
                    .HasColumnName("legacy_change_user");

                entity.Property(e => e.RevNbr)
                    .HasPrecision(4)
                    .HasColumnName("rev_nbr");

                entity.Property(e => e.ShortAbbreviation)
                    .HasMaxLength(4)
                    .HasColumnName("short_abbreviation");
            });

            modelBuilder.Entity<IptBasicColorH>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ipt_basic_color_h");

                entity.Property(e => e.ChangeTimestamp)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("change_timestamp");

                entity.Property(e => e.ChangeType)
                    .HasMaxLength(1)
                    .HasColumnName("change_type");

                entity.Property(e => e.ChangeUserId)
                    .HasPrecision(8)
                    .HasColumnName("change_user_id");

                entity.Property(e => e.DcrNbr)
                    .HasPrecision(5)
                    .HasColumnName("dcr_nbr");

                entity.Property(e => e.Id)
                    .HasPrecision(8)
                    .HasColumnName("id");

                entity.Property(e => e.LegacyChangeUser)
                    .HasMaxLength(9)
                    .HasColumnName("legacy_change_user");

                entity.Property(e => e.RevNbr)
                    .HasPrecision(4)
                    .HasColumnName("rev_nbr");
            });

            modelBuilder.Entity<IptBasicColorP>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ipt_basic_color_p");

                entity.Property(e => e.Abbreviation)
                    .HasMaxLength(7)
                    .HasColumnName("abbreviation");

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .HasColumnName("description");

                entity.Property(e => e.DoNotUseInd)
                    .HasMaxLength(1)
                    .HasColumnName("do_not_use_ind");

                entity.Property(e => e.Id)
                    .HasPrecision(8)
                    .HasColumnName("id");

                entity.Property(e => e.ShortAbbreviation)
                    .HasMaxLength(4)
                    .HasColumnName("short_abbreviation");
            });

            modelBuilder.Entity<IptBasicColorW>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ipt_basic_color_w");

                entity.Property(e => e.Abbreviation)
                    .HasMaxLength(7)
                    .HasColumnName("abbreviation");

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .HasColumnName("description");

                entity.Property(e => e.DoNotUseInd)
                    .HasMaxLength(1)
                    .HasColumnName("do_not_use_ind");

                entity.Property(e => e.Id)
                    .HasPrecision(8)
                    .HasColumnName("id");

                entity.Property(e => e.ShortAbbreviation)
                    .HasMaxLength(4)
                    .HasColumnName("short_abbreviation");
            });

            modelBuilder.Entity<IptColorA>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ipt_color_a");

                entity.Property(e => e.AudCheckoutDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("aud_checkout_date");

                entity.Property(e => e.AudCheckoutUserId)
                    .HasPrecision(8)
                    .HasColumnName("aud_checkout_user_id");

                entity.Property(e => e.AudCreateDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("aud_create_date");

                entity.Property(e => e.AudCreateUserId)
                    .HasPrecision(8)
                    .HasColumnName("aud_create_user_id");

                entity.Property(e => e.AudLastModifyDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("aud_last_modify_date");

                entity.Property(e => e.AudLastModifyUserId)
                    .HasPrecision(8)
                    .HasColumnName("aud_last_modify_user_id");

                entity.Property(e => e.AudPublishDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("aud_publish_date");

                entity.Property(e => e.AudPublishUserId)
                    .HasPrecision(8)
                    .HasColumnName("aud_publish_user_id");

                entity.Property(e => e.FirstDeliveredDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("first_delivered_date");

                entity.Property(e => e.Id)
                    .HasPrecision(8)
                    .HasColumnName("id");

                entity.Property(e => e.LastDeliveredDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("last_delivered_date");

                entity.Property(e => e.PrevDeliveredDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("prev_delivered_date");

                entity.Property(e => e.WipStatusId)
                    .HasPrecision(8)
                    .HasColumnName("wip_status_id");
            });

            modelBuilder.Entity<IptColorC>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ipt_color_c");

                entity.Property(e => e.Abbreviation)
                    .HasMaxLength(15)
                    .HasColumnName("abbreviation");

                entity.Property(e => e.BasicColorId)
                    .HasPrecision(8)
                    .HasColumnName("basic_color_id");

                entity.Property(e => e.ChangeTimestamp)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("change_timestamp");

                entity.Property(e => e.ChangeType)
                    .HasMaxLength(1)
                    .HasColumnName("change_type");

                entity.Property(e => e.ChangeUserId)
                    .HasPrecision(8)
                    .HasColumnName("change_user_id");

                entity.Property(e => e.ConceptRevNbr)
                    .HasPrecision(4)
                    .HasColumnName("concept_rev_nbr");

                entity.Property(e => e.DcrNbr)
                    .HasPrecision(5)
                    .HasColumnName("dcr_nbr");

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .HasColumnName("description");

                entity.Property(e => e.DoNotUseInd)
                    .HasMaxLength(1)
                    .HasColumnName("do_not_use_ind");

                entity.Property(e => e.Id)
                    .HasPrecision(8)
                    .HasColumnName("id");

                entity.Property(e => e.LegacyChangeUser)
                    .HasMaxLength(9)
                    .HasColumnName("legacy_change_user");

                entity.Property(e => e.RevNbr)
                    .HasPrecision(4)
                    .HasColumnName("rev_nbr");
            });

            modelBuilder.Entity<IptColorH>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ipt_color_h");

                entity.Property(e => e.ChangeTimestamp)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("change_timestamp");

                entity.Property(e => e.ChangeType)
                    .HasMaxLength(1)
                    .HasColumnName("change_type");

                entity.Property(e => e.ChangeUserId)
                    .HasPrecision(8)
                    .HasColumnName("change_user_id");

                entity.Property(e => e.DcrNbr)
                    .HasPrecision(5)
                    .HasColumnName("dcr_nbr");

                entity.Property(e => e.Id)
                    .HasPrecision(8)
                    .HasColumnName("id");

                entity.Property(e => e.LegacyChangeUser)
                    .HasMaxLength(9)
                    .HasColumnName("legacy_change_user");

                entity.Property(e => e.RevNbr)
                    .HasPrecision(4)
                    .HasColumnName("rev_nbr");
            });

            modelBuilder.Entity<IptColorP>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ipt_color_p");

                entity.Property(e => e.Abbreviation)
                    .HasMaxLength(15)
                    .HasColumnName("abbreviation");

                entity.Property(e => e.BasicColorId)
                    .HasPrecision(8)
                    .HasColumnName("basic_color_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .HasColumnName("description");

                entity.Property(e => e.DoNotUseInd)
                    .HasMaxLength(1)
                    .HasColumnName("do_not_use_ind");

                entity.Property(e => e.Id)
                    .HasPrecision(8)
                    .HasColumnName("id");
            });

            modelBuilder.Entity<IptColorW>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ipt_color_w");

                entity.Property(e => e.Abbreviation)
                    .HasMaxLength(15)
                    .HasColumnName("abbreviation");

                entity.Property(e => e.BasicColorId)
                    .HasPrecision(8)
                    .HasColumnName("basic_color_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .HasColumnName("description");

                entity.Property(e => e.DoNotUseInd)
                    .HasMaxLength(1)
                    .HasColumnName("do_not_use_ind");

                entity.Property(e => e.Id)
                    .HasPrecision(8)
                    .HasColumnName("id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
