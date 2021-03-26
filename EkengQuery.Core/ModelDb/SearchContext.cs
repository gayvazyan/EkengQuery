using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EkengQuery.Core
{
    public partial class SearchContext : DbContext
    {
        public SearchContext()
        {
        }

        public SearchContext(DbContextOptions<SearchContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Applicant> Applicant { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Community> Community { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<MenuItem> MenuItem { get; set; }
        public virtual DbSet<OldCerteficate> OldCerteficate { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<Party> Party { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<TrainingCenter> TrainingCenter { get; set; }
        public virtual DbSet<TrainingCourse> TrainingCourse { get; set; }
        public virtual DbSet<TrainingCoursePart> TrainingCoursePart { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server= DESKTOP-9GM7NOP\\SQLEXPRESS;Database=cecsystemsdb;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applicant>(entity =>
            {
                entity.HasIndex(e => e.ApplicantLastName)
                    .HasName("_dta_index_Applicant_8_597577167__K3");

                entity.HasIndex(e => e.CommunityId);

                entity.HasIndex(e => e.GenderId);

                entity.HasIndex(e => e.Ssn)
                    .IsUnique()
                    .HasFilter("([SSN] IS NOT NULL)");

                entity.HasIndex(e => e.TrainingCenterCommunityId);

                entity.HasIndex(e => e.TrainingCourseCode)
                    .HasName("_dta_index_Applicant_8_597577167__K26");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");
            });

            modelBuilder.Entity<Community>(entity =>
            {
                entity.HasIndex(e => e.RegionId);
            });

            modelBuilder.Entity<OldCerteficate>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasIndex(e => e.MenuItemId);
            });

            modelBuilder.Entity<TrainingCenter>(entity =>
            {
                entity.HasIndex(e => e.CommunityId);
            });

            modelBuilder.Entity<TrainingCourse>(entity =>
            {
                entity.HasIndex(e => e.TrainingCenterId);

                entity.Property(e => e.SubGroups).HasDefaultValueSql("(CONVERT([tinyint],(0)))");
            });

            modelBuilder.Entity<TrainingCoursePart>(entity =>
            {
                entity.HasIndex(e => e.TrainingCourseId);

                entity.HasIndex(e => new { e.ParticipantId, e.TrainingCourseId })
                    .IsUnique();

                entity.HasIndex(e => new { e.TrainingCoursePartId, e.EmailSentTime, e.IsNotified, e.ParticipantId, e.TrainingCourseId })
                    .HasName("_dta_index_TrainingCoursePart_8_1077578877__K4_K2_K3_1_5");

                entity.HasIndex(e => new { e.TrainingCoursePartId, e.IsNotified, e.EmailSentTime, e.ParticipantId, e.TrainingCourseId })
                    .HasName("_dta_index_TrainingCoursePart_8_1077578877__K2_K3_1_4_5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
