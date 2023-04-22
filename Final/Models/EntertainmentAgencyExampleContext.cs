using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Final.Models
{
    public partial class EntertainmentAgencyExampleContext : DbContext
    {
        public EntertainmentAgencyExampleContext()
        {
        }

        public EntertainmentAgencyExampleContext(DbContextOptions<EntertainmentAgencyExampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agents> Agents { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Engagements> Engagements { get; set; }
        public virtual DbSet<EntertainerMembers> EntertainerMembers { get; set; }
        public virtual DbSet<EntertainerStyles> EntertainerStyles { get; set; }
        public virtual DbSet<Entertainers> Entertainers { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<MusicalPreferences> MusicalPreferences { get; set; }
        public virtual DbSet<MusicalStyles> MusicalStyles { get; set; }
        public virtual DbSet<ZtblDays> ZtblDays { get; set; }
        public virtual DbSet<ZtblMonths> ZtblMonths { get; set; }
        public virtual DbSet<ZtblSkipLabels> ZtblSkipLabels { get; set; }
        public virtual DbSet<ZtblWeeks> ZtblWeeks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source = EntertainmentAgencyExample.sqlite");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agents>(entity =>
            {
                entity.HasKey(e => e.AgentId);

                entity.Property(e => e.AgentId)
                    .HasColumnName("AgentID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CommissionRate).HasColumnType("NUMERIC");

                entity.Property(e => e.Salary).HasColumnType("NUMERIC");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Engagements>(entity =>
            {
                entity.HasKey(e => e.EngagementNumber);

                entity.Property(e => e.EngagementNumber).ValueGeneratedNever();

                entity.Property(e => e.AgentId).HasColumnName("AgentID");

                entity.Property(e => e.ContractPrice).HasColumnType("NUMERIC");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.EntertainerId).HasColumnName("EntertainerID");
            });

            modelBuilder.Entity<EntertainerMembers>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Entertainer_Members");

                entity.Property(e => e.EntertainerId).HasColumnName("EntertainerID");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");
            });

            modelBuilder.Entity<EntertainerStyles>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Entertainer_Styles");

                entity.Property(e => e.EntertainerId).HasColumnName("EntertainerID");

                entity.Property(e => e.StyleId).HasColumnName("StyleID");
            });

            modelBuilder.Entity<Entertainers>(entity =>
            {
                entity.HasKey(e => e.EntertainerId);

                entity.Property(e => e.EntertainerId)
                    .HasColumnName("EntertainerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EntEmailAddress).HasColumnName("EntEMailAddress");

                entity.Property(e => e.EntSsn).HasColumnName("EntSSN");
            });

            modelBuilder.Entity<Members>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.Property(e => e.MemberId)
                    .HasColumnName("MemberID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<MusicalPreferences>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Musical_Preferences");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.StyleId).HasColumnName("StyleID");
            });

            modelBuilder.Entity<MusicalStyles>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Musical_Styles");

                entity.Property(e => e.StyleId).HasColumnName("StyleID");
            });

            modelBuilder.Entity<ZtblDays>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ztblDays");
            });

            modelBuilder.Entity<ZtblMonths>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ztblMonths");
            });

            modelBuilder.Entity<ZtblSkipLabels>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ztblSkipLabels");
            });

            modelBuilder.Entity<ZtblWeeks>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ztblWeeks");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
