using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace propertyapi.Models
{
    public partial class ACE42023Context : DbContext
    {
        public ACE42023Context()
        {
        }

        public ACE42023Context(DbContextOptions<ACE42023Context> options)
            : base(options)
        {
        }

        public virtual DbSet<BrijeshBuyer> BrijeshBuyers { get; set; }
        public virtual DbSet<BrijeshProperty> BrijeshProperties { get; set; }
        public virtual DbSet<BrijeshSeller> BrijeshSellers { get; set; }
        public virtual DbSet<BrijeshTran> BrijeshTrans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DEVSQL.corp.local;Database=ACE 4- 2023;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BrijeshBuyer>(entity =>
            {
                entity.HasKey(e => e.BuyerId)
                    .HasName("PK__Brijesh___BAD1715251431297");

                entity.ToTable("Brijesh_buyer");

                entity.Property(e => e.BuyerId)
                    .ValueGeneratedNever()
                    .HasColumnName("buyer_id");

                entity.Property(e => e.BuyerName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("buyer_name");

                entity.Property(e => e.BuyerPassword)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("buyer_password");

                entity.Property(e => e.InitBal)
                    .HasColumnName("init_bal")
                    .HasDefaultValueSql("((100))");
            });

            modelBuilder.Entity<BrijeshProperty>(entity =>
            {
                entity.HasKey(e => e.PropertyId)
                    .HasName("PK__Brijesh___735BA463E5D56375");

                entity.ToTable("Brijesh_property");

                entity.Property(e => e.PropertyId)
                    .ValueGeneratedNever()
                    .HasColumnName("property_id");

                entity.Property(e => e.Loc)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("loc");

                entity.Property(e => e.PName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("p_name");

                entity.Property(e => e.RentPd).HasColumnName("rent_pd");

                entity.Property(e => e.SellerpId).HasColumnName("sellerp_id");

                entity.HasOne(d => d.Sellerp)
                    .WithMany(p => p.BrijeshProperties)
                    .HasForeignKey(d => d.SellerpId)
                    .HasConstraintName("FK__Brijesh_p__selle__4C6B5938");
            });

            modelBuilder.Entity<BrijeshSeller>(entity =>
            {
                entity.HasKey(e => e.SellerId)
                    .HasName("PK__Brijesh___780A0A9702CCDD3D");

                entity.ToTable("Brijesh_seller");

                entity.Property(e => e.SellerId)
                    .ValueGeneratedNever()
                    .HasColumnName("seller_id");

                entity.Property(e => e.SellerName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("seller_name");

                entity.Property(e => e.SellerPassword)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("seller_password");
            });

            modelBuilder.Entity<BrijeshTran>(entity =>
            {
                entity.HasKey(e => e.TransId)
                    .HasName("PK__brijesh___438CAC186C2792EF");

                entity.ToTable("brijesh_trans");

                entity.Property(e => e.TransId).HasColumnName("trans_id");

                entity.Property(e => e.BuyertId).HasColumnName("buyert_id");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("date")
                    .HasColumnName("date_from");

                entity.Property(e => e.DateTo)
                    .HasColumnType("date")
                    .HasColumnName("date_to");

                entity.Property(e => e.PropId).HasColumnName("prop_id");

                entity.HasOne(d => d.Buyert)
                    .WithMany(p => p.BrijeshTrans)
                    .HasForeignKey(d => d.BuyertId)
                    .HasConstraintName("FK__brijesh_t__buyer__4E53A1AA");

                entity.HasOne(d => d.Prop)
                    .WithMany(p => p.BrijeshTrans)
                    .HasForeignKey(d => d.PropId)
                    .HasConstraintName("FK__brijesh_t__prop___4F47C5E3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
