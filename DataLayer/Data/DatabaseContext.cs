using Azure;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<NewsArticle> NewsArticles { get; set; }

        public virtual DbSet<SystemAccount> SystemAccounts { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//            => optionsBuilder.UseSqlServer("Server=LAPTOP-433H02QI\\NGHUY;Database=FUNewsManagement2;Trusted_Connection=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A2B149E0E87");

                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
                entity.Property(e => e.CategoryDescription).HasMaxLength(500);
                entity.Property(e => e.CategoryName).HasMaxLength(100);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.ParentCategoryId).HasColumnName("ParentCategoryID");

                entity.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory)
                    .HasForeignKey(d => d.ParentCategoryId)
                    .HasConstraintName("FK__Category__Parent__286302EC");
            });

            modelBuilder.Entity<NewsArticle>(entity =>
            {
                entity.HasKey(e => e.NewsArticleId).HasName("PK__NewsArti__4CD0926C1819EB3F");

                entity.ToTable("NewsArticle");

                entity.Property(e => e.NewsArticleId).HasColumnName("NewsArticleID");
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
                entity.Property(e => e.CreatedById).HasColumnName("CreatedByID");
                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.Headline).HasMaxLength(500);
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.NewsSource).HasMaxLength(200);
                entity.Property(e => e.NewsStatus).HasDefaultValue(true);
                entity.Property(e => e.NewsTitle).HasMaxLength(200);
                entity.Property(e => e.UpdatedById).HasColumnName("UpdatedByID");

                entity.HasOne(d => d.Category).WithMany(p => p.NewsArticles)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NewsArtic__Categ__300424B4");

                entity.HasOne(d => d.CreatedBy).WithMany(p => p.NewsArticleCreatedBies)
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NewsArtic__Creat__30F848ED");

                entity.HasOne(d => d.UpdatedBy).WithMany(p => p.NewsArticleUpdatedBies)
                    .HasForeignKey(d => d.UpdatedById)
                    .HasConstraintName("FK__NewsArtic__Updat__31EC6D26");

                entity.HasMany(d => d.Tags).WithMany(p => p.NewsArticles)
                    .UsingEntity<Dictionary<string, object>>(
                        "NewsTag",
                        r => r.HasOne<Tag>().WithMany()
                            .HasForeignKey("TagId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__NewsTag__TagID__35BCFE0A"),
                        l => l.HasOne<NewsArticle>().WithMany()
                            .HasForeignKey("NewsArticleId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__NewsTag__NewsArt__34C8D9D1"),
                        j =>
                        {
                            j.HasKey("NewsArticleId", "TagId").HasName("PK__NewsTag__9A875DC84F6FA309");
                            j.ToTable("NewsTag");
                            j.IndexerProperty<int>("NewsArticleId").HasColumnName("NewsArticleID");
                            j.IndexerProperty<int>("TagId").HasColumnName("TagID");
                        });
            });

            modelBuilder.Entity<SystemAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId).HasName("PK__SystemAc__349DA586ACB0FB8E");

                entity.ToTable("SystemAccount");

                entity.HasIndex(e => e.AccountEmail, "UQ__SystemAc__FC770D33DA9D6807").IsUnique();

                entity.Property(e => e.AccountId).HasColumnName("AccountID");
                entity.Property(e => e.AccountEmail).HasMaxLength(255);
                entity.Property(e => e.AccountName).HasMaxLength(100);
                entity.Property(e => e.AccountPassword).HasMaxLength(100);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(e => e.TagId).HasName("PK__Tag__657CFA4CA50096A8");

                entity.ToTable("Tag");

                entity.HasIndex(e => e.TagName, "UQ__Tag__BDE0FD1D03F93995").IsUnique();

                entity.Property(e => e.TagId).HasColumnName("TagID");
                entity.Property(e => e.Note).HasMaxLength(200);
                entity.Property(e => e.TagName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
