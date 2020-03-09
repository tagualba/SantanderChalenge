using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MeetupsApi.Data;

namespace MeetupsApi.Data
{
    public partial class SantanderChalengeContext : DbContext
    {
        public SantanderChalengeContext()
        {
        }

        public SantanderChalengeContext(DbContextOptions<SantanderChalengeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Meetups> Meetups { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=SantanderChalenge;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meetups>(entity =>
            {
                entity.ToTable("MEETUPS");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Canceled).HasColumnName("canceled");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UserOrganizer).HasColumnName("user_organizer");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Admin).HasColumnName("admin");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasColumnName("pass")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
